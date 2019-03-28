using System.Collections.Immutable;

namespace Preference
{
    public sealed class ResultsComponent
    {
        public ResultsComponent(ImmutableArray<string> sortedResults, ImmutableArray<(string preferred, string lower)> choices)
        {
            SortedResults = sortedResults;
            Choices = choices;
        }

        public ImmutableArray<string> SortedResults { get; }

        public ImmutableArray<(string preferred, string lower)> Choices { get; }
    }
}
