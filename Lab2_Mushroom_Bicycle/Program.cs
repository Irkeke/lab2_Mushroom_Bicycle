using System;
using System.Windows.Forms;

namespace Lab2_Mushroom_Bicycle
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NavigationContext());
        }

        // Starts on the login form and ends the program when the last form is closed.
        private sealed class NavigationContext : ApplicationContext
        {
            public NavigationContext()
            {
                Ui.Open(new LoginForm());
            }
        }
    }
}
