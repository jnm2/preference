using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Preference
{
    public sealed class PreferenceComponent
    {
        private readonly IRandomnessSource randomnessSource;
        private readonly ImmutableArray<string> options;
        private readonly ImmutableList<(int preferredIndex, int lowerIndex)> choices;

        public PreferenceComponent(IRandomnessSource randomnessSource, IEnumerable<string> options)
        {
            this.randomnessSource = randomnessSource ?? throw new ArgumentNullException(nameof(randomnessSource));

            if (options is null) throw new ArgumentNullException(nameof(options));
            this.options = options.Distinct().ToImmutableArray();

            if (this.options.Length < 2)
            {
                Results = new ResultsComponent(this.options, ImmutableArray<(string preferred, string lower)>.Empty);
            }
            else
            {
                choices = ImmutableList<(int preferredIndex, int lowerIndex)>.Empty;

                var (leftIndex, rightIndex) = GetRandomPair();
                Choice = CreateChoice(leftIndex, rightIndex);
            }
        }

        public ChoiceComponent Choice { get; }
        public ResultsComponent Results { get; }

        public PreferenceComponent Reduce(object action)
        {
            switch (action)
            {
                case ChooseOptionAction choice:
                    return Choose(choice);

                default:
                    throw new ArgumentException("Unrecognized action.", nameof(action));
            }
        }

        private PreferenceComponent Choose(ChooseOptionAction choice)
        {
            var choices = this.choices.Add(choice == ChooseOptionAction.Left
                ? (Choice.LeftIndex, Choice.RightIndex)
                : (Choice.RightIndex, Choice.LeftIndex));

            if (TryCalculateTotalOrdering(options.Length, choices, out var ordering))
            {
                return new PreferenceComponent(
                    randomnessSource,
                    options,
                    choices,
                    choice: null,
                    results: new ResultsComponent(
                        ImmutableArray.CreateRange(ordering, index => options[index]),
                        choices.Select(c => (options[c.preferredIndex], options[c.lowerIndex])).ToImmutableArray()));
            }
            else
            {
                return new PreferenceComponent(
                    randomnessSource,
                    options,
                    choices,
                    CreateNextChoice(choices),
                    results: null);
            }
        }

        private ChoiceComponent CreateNextChoice(ImmutableList<(int preferredIndex, int lowerIndex)> previousChoices)
        {
            while (true)
            {
                var (leftIndex, rightIndex) = GetRandomPair();

                if (!CanTransitivelyProve(preferredIndex: leftIndex, lowerIndex: rightIndex, previousChoices)
                    && !CanTransitivelyProve(preferredIndex: rightIndex, lowerIndex: leftIndex, previousChoices))
                {
                    return CreateChoice(leftIndex, rightIndex);
                }
            }
        }

        private static bool CanTransitivelyProve(int preferredIndex, int lowerIndex, ImmutableList<(int preferredIndex, int lowerIndex)> choices)
        {
            // Do a depth-first search for lowerIndex starting from preferredIndex

            foreach (var choice in choices)
            {
                if (choice.preferredIndex != preferredIndex) continue;
                if (choice.lowerIndex == lowerIndex
                    || CanTransitivelyProve(choice.lowerIndex, lowerIndex, choices))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TryCalculateTotalOrdering(int totalCount, ImmutableList<(int preferredIndex, int lowerIndex)> choices, out ImmutableArray<int> ordering)
        {
            if (choices.Count < totalCount - 1)
            {
                ordering = default;
                return false;
            }

            var builder = ImmutableArray.CreateBuilder<int>(totalCount);
            var isRuledOutByIndex = new bool[totalCount];

            for (var i = 0; i < totalCount; i++)
            {
                Array.Clear(isRuledOutByIndex, 0, isRuledOutByIndex.Length);

                foreach (var alreadyTaken in builder)
                    isRuledOutByIndex[alreadyTaken] = true;

                foreach (var choice in choices)
                {
                    if (builder.Contains(choice.preferredIndex)) continue;
                    isRuledOutByIndex[choice.lowerIndex] = true;
                }

                var mostPreferredRemainingIndex = -1;

                for (var index = 0; index < totalCount; index++)
                {
                    if (isRuledOutByIndex[index]) continue;

                    if (mostPreferredRemainingIndex != -1)
                    {
                        mostPreferredRemainingIndex = -1;
                        break;
                    }
                    mostPreferredRemainingIndex = index;
                }

                if (mostPreferredRemainingIndex == -1)
                {
                    ordering = default;
                    return false;
                }

                builder.Add(mostPreferredRemainingIndex);
            }

            ordering = builder.MoveToImmutable();
            return true;
        }

        private (int leftIndex, int rightIndex) GetRandomPair()
        {
            var leftIndex = randomnessSource.ChooseIndex(options.Length);

            var rightIndex = randomnessSource.ChooseIndex(options.Length - 1);
            if (rightIndex >= leftIndex) rightIndex++;

            return (leftIndex, rightIndex);
        }

        private ChoiceComponent CreateChoice(int leftIndex, int rightIndex)
        {
            return new ChoiceComponent(leftIndex, options[leftIndex], rightIndex, options[rightIndex]);
        }

        private PreferenceComponent(
            IRandomnessSource randomnessSource,
            ImmutableArray<string> options,
            ImmutableList<(int preferredIndex, int lowerIndex)> choices,
            ChoiceComponent choice,
            ResultsComponent results)
        {
            this.randomnessSource = randomnessSource;
            this.options = options;
            this.choices = choices;
            Choice = choice;
            Results = results;
        }
    }
}
