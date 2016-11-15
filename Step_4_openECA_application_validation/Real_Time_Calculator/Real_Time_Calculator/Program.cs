// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System;
using System.Windows.Forms;
using ECAClientFramework;
using Real_Time_Calculator.Model;

namespace Real_Time_Calculator
{
    static class Program
    {
        /// <summary>
        /// Main entry point for Real_Time_Calculator.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SignalLookup lookup = new SignalLookup();
            IMapper mapper = new Mapper(lookup);

            Algorithm.UpdateSystemSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainWindow mainWindow = new MainWindow(mapper);
            mainWindow.Text = "C# Real_Time_Calculator Test Harness";
            Application.Run(mainWindow);
        }
    }
}