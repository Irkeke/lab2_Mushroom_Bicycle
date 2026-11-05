using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2_Mushroom_Bicycle
{
    // Shared styling and navigation helpers.
    internal static class Ui
    {
        public const int FormWidth = 600;
        public const int FormHeight = 430;

        public static readonly Font MainFont = new Font("Segoe UI", 10F);
        public static readonly Font TitleFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Color Blue = Color.FromArgb(35, 95, 155);

        private static int openForms;

        public static void Prepare(Form form, string title)
        {
            form.AutoScaleDimensions = new SizeF(96F, 96F);
            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.Text = title;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ClientSize = new Size(FormWidth, FormHeight);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Font = MainFont;
            form.BackColor = Color.WhiteSmoke;
        }

        public static Label MakeTitle(string text, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(20, y),
                Size = new Size(FormWidth - 40, 36),
                Font = TitleFont,
                ForeColor = Blue,
                TextAlign = ContentAlignment.MiddleCenter,
                UseMnemonic = false,   // otherwise "&" in a title is swallowed as a keyboard shortcut
                AutoSize = false
            };
        }

        public static Label MakeLabel(string text, int x, int y, int width = 460, int height = 32)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Font = MainFont,
                TextAlign = ContentAlignment.MiddleLeft,
                UseMnemonic = false,
                AutoSize = false
            };
        }

        public static Button MakeButton(string text, int x, int y, int width = 145)
        {
            var button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 38),
                Font = MainFont,
                BackColor = Blue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        public static TextBox MakeTextBox(int x, int y, int width = 250, bool password = false)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Width = width,
                Font = MainFont,
                UseSystemPasswordChar = password
            };
        }

        // Shows a form and keeps count, so the program exits once every form is closed.
        public static void Open(Form form)
        {
            openForms++;
            form.FormClosed += delegate
            {
                openForms--;
                if (openForms == 0)
                {
                    Application.ExitThread();
                }
            };
            form.Show();
        }

        // Opens the next form first, then closes the current one (no hidden forms pile up).
        public static void GoTo(Form current, Form next)
        {
            Open(next);
            current.Close();
        }

        public static void Logout(Form current)
        {
            GoTo(current, new LoginForm());
        }
    }
}
