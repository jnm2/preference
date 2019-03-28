using System;

namespace Preference
{
    public sealed class SystemRandomnessSource : IRandomnessSource
    {
        private readonly Random random = new Random();

        public int ChooseIndex(int totalCount)
        {
            return random.Next(totalCount);
        }
    }
}
