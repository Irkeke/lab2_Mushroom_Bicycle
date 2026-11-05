using System;
using System.Windows.Forms;

namespace Lab2_Mushroom_Bicycle
{
    public class BicycleForm : Form
    {
        private readonly TextBox startBox;
        private readonly TextBox endBox;
        private readonly TextBox totalBox;

        public BicycleForm()
        {
            Ui.Prepare(this, "Lab 2 - Bicycle Renting");

            Controls.Add(Ui.MakeTitle("BICYCLE RENTING COST CALCULATOR", 30));

            Controls.Add(Ui.MakeLabel("Start time (0 to 23):", 75, 100, 190));
            startBox = Ui.MakeTextBox(275, 102);
            Controls.Add(startBox);

            Controls.Add(Ui.MakeLabel("End time (1 to 24):", 75, 155, 190));
            endBox = Ui.MakeTextBox(275, 157);
            Controls.Add(endBox);

            Button calculateButton = Ui.MakeButton("Calculate", 275, 210, 250);
            calculateButton.Click += CalculateButton_Click;
            Controls.Add(calculateButton);

            Controls.Add(Ui.MakeLabel("Total cost ($):", 75, 275, 190));
            totalBox = Ui.MakeTextBox(275, 277);
            totalBox.ReadOnly = true;
            totalBox.TabStop = false;
            Controls.Add(totalBox);

            Button backButton = Ui.MakeButton("Back", 115, 350);
            backButton.Click += delegate { Ui.GoTo(this, new ChooseForm()); };
            Controls.Add(backButton);

            Button logoutButton = Ui.MakeButton("Logout", 340, 350);
            logoutButton.Click += delegate { Ui.Logout(this); };
            Controls.Add(logoutButton);

            AcceptButton = calculateButton;
        }

        // Price of one complete hour that starts at the given hour (0-23).
        internal static int HourlyRate(int hour)
        {
            if (hour <= 6 || hour >= 21) return 500;    // 0-6 and 21-23
            if (hour <= 13 || hour >= 19) return 1000;  // 7-13 and 19-20
            return 1500;                                // 14-18
        }

        internal static int TotalCost(int start, int end)
        {
            int total = 0;
            for (int hour = start; hour < end; hour++)
            {
                total += HourlyRate(hour);
            }
            return total;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            totalBox.Clear();

            // TryParse prevents a crash when text is entered instead of a number.
            int start;
            if (!int.TryParse(startBox.Text.Trim(), out start))
            {
                MessageBox.Show("Start time must be a whole number from 0 to 23.",
                    "Invalid start time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startBox.Focus();
                startBox.SelectAll();
                return;
            }

            int end;
            if (!int.TryParse(endBox.Text.Trim(), out end))
            {
                MessageBox.Show("End time must be a whole number from 1 to 24.",
                    "Invalid end time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                endBox.Focus();
                endBox.SelectAll();
                return;
            }

            if (start < 0 || start > 23)
            {
                MessageBox.Show("Start time must be between 0 and 23.",
                    "Invalid start time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startBox.Focus();
                startBox.SelectAll();
                return;
            }

            if (end < 1 || end > 24)
            {
                MessageBox.Show("End time must be between 1 and 24.",
                    "Invalid end time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                endBox.Focus();
                endBox.SelectAll();
                return;
            }

            if (start >= end)
            {
                MessageBox.Show("Start time must be less than end time.",
                    "Invalid time range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startBox.Focus();
                startBox.SelectAll();
                return;
            }

            int totalCost = TotalCost(start, end);

            totalBox.Text = totalCost.ToString();
            MessageBox.Show(string.Format("The total rental cost is ${0}.", totalCost),
                "Calculation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
