namespace Preference
{
    public sealed class ChoiceComponent
    {
        public ChoiceComponent(int leftIndex, string leftOption, int rightIndex, string rightOption)
        {
            LeftIndex = leftIndex;
            LeftOption = leftOption;
            RightIndex = rightIndex;
            RightOption = rightOption;
        }

        public int LeftIndex { get; }
        public string LeftOption { get; }
        public int RightIndex { get; }
        public string RightOption { get; }
    }
}
