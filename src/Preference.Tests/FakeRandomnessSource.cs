using System;
using System.Collections.Generic;

namespace Preference.Tests
{
    internal sealed class FakeRandomnessSource : IRandomnessSource
    {
        private readonly IEnumerator<int> enumerator;

        public FakeRandomnessSource(IEnumerable<int> sequence)
        {
            enumerator = sequence.GetEnumerator();
        }

        public FakeRandomnessSource(params int[] sequence)
            : this((IEnumerable<int>)sequence)
        {
        }

        public int ChooseIndex(int totalCount)
        {
            if (!enumerator.MoveNext())
                throw new InvalidOperationException(nameof(ChooseIndex) + " was called more times than the length of the sequence.");

            return enumerator.Current;
        }
    }
}
