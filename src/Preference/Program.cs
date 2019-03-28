using System;
using System.IO;
using System.Windows.Forms;

namespace Preference
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var options = File.ReadAllLines("CandidateNames.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(Redux.Bootstrap(
                new PreferenceComponent(
                    new SystemRandomnessSource(),
                    options),
                dispatch => new Form1(dispatch)));
        }
    }
}
