using System;
using System.Windows.Forms;

namespace Lab2_Mushroom_Bicycle
{
    public class ChooseForm : Form
    {
        public ChooseForm()
        {
            Ui.Prepare(this, "Lab 2 - Choose");

            Controls.Add(Ui.MakeTitle("CHOOSE AN APPLICATION", 70));

            Button bicycleButton = Ui.MakeButton("Bicycle Renting", 100, 160, 190);
            bicycleButton.Click += delegate { Ui.GoTo(this, new BicycleForm()); };
            Controls.Add(bicycleButton);

            Button mushroomButton = Ui.MakeButton("Mushroom Finder", 310, 160, 190);
            mushroomButton.Click += delegate { Ui.GoTo(this, new MushroomForm()); };
            Controls.Add(mushroomButton);

            Button logoutButton = Ui.MakeButton("Logout", 205, 250, 190);
            logoutButton.Click += delegate { Ui.Logout(this); };
            Controls.Add(logoutButton);
        }
    }
}
