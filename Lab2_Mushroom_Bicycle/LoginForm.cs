using System;
using System.Windows.Forms;

namespace Lab2_Mushroom_Bicycle
{
    public class LoginForm : Form
    {
        private readonly TextBox usernameBox;
        private readonly TextBox passwordBox;

        public LoginForm()
        {
            Ui.Prepare(this, "Lab 2 - Login");

            Controls.Add(Ui.MakeTitle("BICYCLE RENTING & MUSHROOM FINDER", 55));

            Controls.Add(Ui.MakeLabel("Username:", 100, 140, 120));
            usernameBox = Ui.MakeTextBox(230, 142);
            Controls.Add(usernameBox);

            Controls.Add(Ui.MakeLabel("Password:", 100, 200, 120));
            passwordBox = Ui.MakeTextBox(230, 202, 250, true);
            Controls.Add(passwordBox);

            Button loginButton = Ui.MakeButton("Login", 230, 270, 250);
            loginButton.Click += LoginButton_Click;
            Controls.Add(loginButton);

            AcceptButton = loginButton;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Lab 2: the only login validation is that neither field may be empty.
            if (string.IsNullOrWhiteSpace(usernameBox.Text))
            {
                MessageBox.Show("Username cannot be empty.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordBox.Text))
            {
                MessageBox.Show("Password cannot be empty.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordBox.Focus();
                return;
            }

            Ui.GoTo(this, new ChooseForm());
        }
    }
}
