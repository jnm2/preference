using System;
using System.Linq;
using System.Windows.Forms;

namespace Preference
{
    public partial class Form1 : Form
    {
        private readonly Action<object> dispatch;

        public Form1(Action<object> dispatch)
        {
            this.dispatch = dispatch ?? throw new ArgumentNullException(nameof(dispatch));

            InitializeComponent();
        }

        public void Render(PreferenceComponent state)
        {
            choicePanel.Visible = state.Choice != null;
            leftButton.Text = state.Choice?.LeftOption;
            rightButton.Text = state.Choice?.RightOption;
            leftWebBrowser.Url = GetUrl(state.Choice?.LeftOption);
            rightWebBrowser.Url = GetUrl(state.Choice?.RightOption);

            resultsPanel.Visible = state.Results != null;
            resultsTextBox.Text = state.Results is null ? null :
                string.Join(Environment.NewLine, state.Results.SortedResults)
                + Environment.NewLine
                + Environment.NewLine
                + "Choices made:" + Environment.NewLine
                + string.Join(Environment.NewLine, state.Results.Choices.Select(c => $"{c.preferred} > {c.lower}"));
        }

        private static Uri GetUrl(string name)
        {
            if (name is null) return null;

            var nameSlug = name.ToLowerInvariant().Replace(' ', '-');

            return new Uri($"https://election.dotnetfoundation.org/campaign-2019/{nameSlug}.html#site_container");
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            dispatch(ChooseOptionAction.Left);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            dispatch(ChooseOptionAction.Right);
        }
    }
}
