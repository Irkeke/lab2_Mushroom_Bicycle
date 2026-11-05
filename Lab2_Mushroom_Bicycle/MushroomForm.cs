using System;
using System.Windows.Forms;

namespace Lab2_Mushroom_Bicycle
{
    public class MushroomForm : Form
    {
        // Which question is currently being asked.
        private enum Question
        {
            Ring,        // Q1
            Forest,      // Q2 (ring = yes)
            Gills,       // Q2 (ring = no)
            CupAfterForest,  // Q3 (ring = yes, forest = no)
            CupAfterGills    // Q3 (ring = no, gills = yes)
        }

        private readonly Label questionLabel;
        private readonly Label progressLabel;
        private readonly TextBox answerBox;
        private Question current;

        public MushroomForm()
        {
            Ui.Prepare(this, "Lab 2 - Mushroom Finder");

            Controls.Add(Ui.MakeTitle("MUSHROOM IDENTIFICATION", 30));

            progressLabel = Ui.MakeLabel("", 75, 100, 450);
            Controls.Add(progressLabel);

            questionLabel = Ui.MakeLabel("", 75, 140, 450, 45);
            Controls.Add(questionLabel);

            answerBox = Ui.MakeTextBox(75, 200, 300);
            Controls.Add(answerBox);

            Button submitButton = Ui.MakeButton("Submit Answer", 75, 250, 155);
            submitButton.Click += SubmitButton_Click;
            Controls.Add(submitButton);

            Button backButton = Ui.MakeButton("Back", 115, 350);
            backButton.Click += delegate { Ui.GoTo(this, new ChooseForm()); };
            Controls.Add(backButton);

            Button logoutButton = Ui.MakeButton("Logout", 340, 350);
            logoutButton.Click += delegate { Ui.Logout(this); };
            Controls.Add(logoutButton);

            AcceptButton = submitButton;
            Ask(Question.Ring);
        }

        private void Ask(Question question)
        {
            current = question;

            switch (question)
            {
                case Question.Ring:
                    progressLabel.Text = "Question 1";
                    questionLabel.Text = "Does your mushroom have a ring? (yes/no)";
                    break;
                case Question.Forest:
                    progressLabel.Text = "Question 2";
                    questionLabel.Text = "Does your mushroom grow in a forest? (yes/no)";
                    break;
                case Question.Gills:
                    progressLabel.Text = "Question 2";
                    questionLabel.Text = "Does your mushroom have gills? (yes/no)";
                    break;
                case Question.CupAfterForest:
                case Question.CupAfterGills:
                    progressLabel.Text = "Question 3";
                    questionLabel.Text = "Does your mushroom have a convex cup? (yes/no)";
                    break;
            }

            answerBox.Clear();
            answerBox.Focus();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string answer = answerBox.Text.Trim().ToLowerInvariant();

            // Reject blank and unexpected answers instead of treating them as "no".
            if (answer != "yes" && answer != "y" && answer != "no" && answer != "n")
            {
                MessageBox.Show("Please enter yes, y, no or n.",
                    "Invalid answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                answerBox.Focus();
                answerBox.SelectAll();
                return;
            }

            bool yes = answer == "yes" || answer == "y";

            switch (current)
            {
                case Question.Ring:
                    Ask(yes ? Question.Forest : Question.Gills);
                    break;

                case Question.Forest:
                    if (yes) ShowResult("Amanite tue-mouche");
                    else Ask(Question.CupAfterForest);
                    break;

                case Question.Gills:
                    if (!yes) ShowResult("Cepe de bordeaux");
                    else Ask(Question.CupAfterGills);
                    break;

                case Question.CupAfterForest:
                    ShowResult(yes ? "Agaric Jaunissant" : "Coprin chevelu");
                    break;

                case Question.CupAfterGills:
                    ShowResult(yes ? "Pied bleu" : "Girolle");
                    break;
            }
        }

        private void ShowResult(string mushroom)
        {
            MessageBox.Show("Your mushroom is: " + mushroom,
                "Mushroom identified", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult again = MessageBox.Show(
                "Would you like to identify another mushroom?",
                "Try again", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (again == DialogResult.Yes)
            {
                Ask(Question.Ring);
            }
            else
            {
                Ui.GoTo(this, new ChooseForm());
            }
        }
    }
}
