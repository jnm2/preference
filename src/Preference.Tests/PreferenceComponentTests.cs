using NUnit.Framework;
using System.Collections.Immutable;
using Shouldly;

namespace Preference.Tests
{
    public static class PreferenceComponentTests
    {
        [Test]
        public static void Same_pair_is_not_shown_a_second_time()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    2, 2, // C, D
                    0, 0, // A, B (should be skipped)
                    0, 1), // A, C
                ImmutableArray.Create("A", "B", "C", "D"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Left);

            component.Choice.LeftOption.ShouldBe("A");
            component.Choice.RightOption.ShouldBe("C");
        }

        [Test]
        public static void Same_pair_is_not_shown_reversed()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    2, 2, // C, D
                    1, 0, // B, A (should be skipped)
                    0, 1), // A, C
                ImmutableArray.Create("A", "B", "C", "D"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Left);

            component.Choice.LeftOption.ShouldBe("A");
            component.Choice.RightOption.ShouldBe("C");
        }

        [Test]
        public static void Same_option_appears_as_many_times_as_necessary()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    0, 1, // A, C
                    1, 1, // B, C
                    3, 2, // D, C
                    3, 1, // D, B
                    3, 0), // D, A
                ImmutableArray.Create("A", "B", "C", "D"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Left);

            component = component.Reduce(ChooseOptionAction.Left);
            component.Choice.LeftOption.ShouldBe("D");
            component.Choice.RightOption.ShouldBe("C");

            component = component.Reduce(ChooseOptionAction.Left);
            component.Choice.LeftOption.ShouldBe("D");
            component.Choice.RightOption.ShouldBe("B");

            component = component.Reduce(ChooseOptionAction.Left);
            component.Choice.LeftOption.ShouldBe("D");
            component.Choice.RightOption.ShouldBe("A");
        }

        [Test]
        public static void Comparison_is_not_done_if_the_answer_is_transitively_known()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    0, 1, // A, C
                    1, 1, // B, C
                    1, 2), // B, D
                ImmutableArray.Create("A", "B", "C", "D"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Right);

            component.Choice.LeftOption.ShouldBe("B");
            component.Choice.RightOption.ShouldBe("D");
        }

        [Test]
        public static void Comparison_is_done_if_the_answer_is_not_transitively_known()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    0, 1, // A, C
                    1, 1, // B, C
                    1, 2), // B, D
                ImmutableArray.Create("A", "B", "C", "D"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Left);

            component.Choice.LeftOption.ShouldBe("B");
            component.Choice.RightOption.ShouldBe("C");
        }

        [Test]
        public static void Results_are_given_when_all_pairs_are_transitively_known()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    0, 1), // A, C
                ImmutableArray.Create("A", "B", "C"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Right);

            component.Results.ShouldNotBeNull();
            component.Results.SortedResults.ShouldBe(new[] { "C", "A", "B" });
        }

        [Test]
        public static void Results_are_not_given_until_all_pairs_are_transitively_known()
        {
            var component = new PreferenceComponent(
                new FakeRandomnessSource(
                    0, 0, // A, B
                    0, 1, // A, C
                    1, 1), // B, C
                ImmutableArray.Create("A", "B", "C"));

            component = component.Reduce(ChooseOptionAction.Left);
            component = component.Reduce(ChooseOptionAction.Left);

            component.Results.ShouldBeNull();
            component.Choice.LeftOption.ShouldBe("B");
            component.Choice.RightOption.ShouldBe("C");
        }
    }
}
