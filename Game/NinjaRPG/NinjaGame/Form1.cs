using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NinjaGame.Properties;
using NinjaWorld;
using NinjaWorld.Buildings;
using NinjaWorld.Creatures;
using NinjaWorld.Items;
using NinjaWorld.Jobs;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NinjaGame
{
    public partial class frmStart : Form
    {
        static Evil evil;
        static Ninja ninja;
        static Arena arena;

        PictureBox[] forcePowerButtons;
        PictureBox[] mentalPowerButtons;
        PictureBox[] specialForcePowerButtons;
        PictureBox[] specialMentalPowerButtons;
        PictureBox[] energyButtons;
        public frmStart()
        {
            InitializeComponent();
            ninja = new Ninja("Ninja");
            prgrsEnergy.Maximum = ninja.TotalEnergy;
            prgrsEnergy.Value = ninja.CurrentEnergy;
        }
       
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = true;

            lblCashValue.Text = ninja.Cash.ToString();
            lblLevelValue.Text = ninja.ForceLevel.ToString();
            prgrsForce.Maximum = ninja.TotalStepsToNextForceLevel;
            prgrsForce.Value = ninja.CurrentStepForceLevel;
            prgrsMental.Maximum = ninja.TotalStepsToNextMentalLevel;
            prgrsMental.Value = ninja.CurrentStepMentalLevel;
            prgrEnergy.Maximum = ninja.TotalEnergy;
            prgrEnergy.Value = ninja.CurrentEnergy;
            lblForceLevelValue.Text = ninja.ForceLevel.ToString();
            lblMentalLevelValue.Text = ninja.MentalLevel.ToString();
            lblMaxForce.Text = ninja.TotalStepsToNextMentalLevel.ToString();
            lblMaxMental.Text = ninja.TotalStepsToNextMentalLevel.ToString();
            lblMaxEnergy.Text = ninja.TotalEnergy.ToString();


            forcePowerButtons = new PictureBox[10]
            {
                picHomeForce1,
                picHomeForce2,
                picHomeForce3, 
                picHomeForce4, 
                picHomeForce5,
                picHomeForce6,
                picHomeForce7,
                picHomeForce8, 
                picHomeForce9,
                picHomeForce10 
            };
           
            mentalPowerButtons = new PictureBox[10] 
            {
                picHomeMental1,
                picHomeMental2,
                picHomeMental3,
                picHomeMental4,
                picHomeMental5,
                picHomeMental6, 
                picHomeMental7, 
                picHomeMental8, 
                picHomeMental9, 
                picHomeMental10 
            };
            
            specialForcePowerButtons = new PictureBox[10] 
            {
                picHomeSpecialForce1, 
                picHomeSpecialForce2,
                picHomeSpecialForce3, 
                picHomeSpecialForce4, 
                picHomeSpecialForce5, 
                picHomeSpecialForce6, 
                picHomeSpecialForce7, 
                picHomeSpecialForce8, 
                picHomeSpecialForce9,
                picHomeSpecialForce10
            };
           
            specialMentalPowerButtons = new PictureBox[10]
            {
                picHomeSpecialMental1, 
                picHomeSpecialMental2, 
                picHomeSpecialMental3, 
                picHomeSpecialMental4, 
                picHomeSpecialMental5,
                picHomeSpecialMental6, 
                picHomeSpecialMental7, 
                picHomeSpecialMental8, 
                picHomeSpecialMental9,
                picHomeSpecialMental10
            };
           
            energyButtons = new PictureBox[10] 
            {
                picHomeEnergizers1, 
                picHomeEnergizers2, 
                picHomeEnergizers3,
                picHomeEnergizers4,
                picHomeEnergizers5,
                picHomeEnergizers6,
                picHomeEnergizers7, 
                picHomeEnergizers8,
                picHomeEnergizers9,
                picHomeEnergizers10 
            };
            LoadButtons();
        }

        private void LoadButtons()
        {

            for (int i = 0; i < ninja.ForcePowers.Count; i++)
            {
                forcePowerButtons[i].Visible = true;
            }

            for (int i = 0; i < ninja.MentalPowers.Count; i++)
            {
                mentalPowerButtons[i].Visible = true;
            }

            int forceIndex = 0;
            int mentalIndex = 0;
            int energyIndex = 0;

            foreach (var item in ninja.BagOfItems)
            {
                if (item is Energizer)
                {
                    energyButtons[energyIndex].BackgroundImage = GiveBackgroundImage(energyButtons[energyIndex].Name);
                    energyIndex++;
                }
                else
                {
                    if ((item as IAttack).AttackType == AttackTypeEnum.ForceAttack)
                    {
                        forcePowerButtons[forceIndex].BackgroundImage = GiveBackgroundImage(forcePowerButtons[forceIndex].Name);
                        forceIndex++;
                    }
                    else
                    {
                        mentalPowerButtons[mentalIndex].BackgroundImage = GiveBackgroundImage(mentalPowerButtons[mentalIndex].Name);
                        mentalIndex++;
                    }
                }
            }
        }

        private void LoadFight()
        {
            forcePowerButtons = new PictureBox[10] 
            { 
                btnFightForce1, 
                btnFightForce2, 
                btnFightForce3, 
                btnFightForce4, 
                btnFightForce5, 
                btnFightForce6, 
                btnFightForce7, 
                btnFightForce8, 
                btnFightForce9, 
                btnFightForce10 
            };
           
            mentalPowerButtons = new PictureBox[10] 
            {
                btnFightMental1, 
                btnFightMental2, 
                btnFightMental3, 
                btnFightMental4, 
                btnFightMental5,
                btnFightMental6,
                btnFightMental7, 
                btnFightMental8,
                btnFightMental9, 
                btnFightMental10
            };
            
            specialForcePowerButtons = new PictureBox[10] 
            { 
                btnFightSpecialForce1, 
                btnFightSpecialForce2, 
                btnFightSpecialForce3,
                btnFightSpecialForce4, 
                btnFightSpecialForce5,
                btnFightSpecialForce6, 
                btnFightSpecialForce7,
                btnFightSpecialForce8, 
                btnFightSpecialForce9,
                btnFightSpecialForce10
            };
           
            specialMentalPowerButtons = new PictureBox[10] 
            {
                btnSpecialMental1, 
                btnSpecialMental2,
                btnSpecialMental3,
                btnSpecialMental4, 
                btnSpecialMental5, 
                btnSpecialMental6,
                btnSpecialMental7,
                btnSpecialMental8,
                btnSpecialMental9, 
                btnSpecialMental10 
            };
           
            energyButtons = new PictureBox[10] 
            {
                btnFightEnergy1, 
                btnFightEnergy2,
                btnFightEnergy3,
                btnFightEnergy4, 
                btnFightEnergy5,
                btnFightEnergy6,
                btnFightEnergy7,
                btnFightEnergy8,
                btnFightEnergy9,
                btnFightEnergy10 
            };
        }
        private Bitmap GiveBackgroundImage(string name)
        {

            switch (name)
            {
                case "Coke": return Resources.Coke;
                case "Coffee": return Resources.Coffee;
                case "Icecream": return Resources.Icecream;
                case "Burger": return Resources.Burger;
                case "Pizza": return Resources.Pizza1;
                case "Energidrink": return Resources.Energydrink;
                case "Shuriken": return Resources.Shurikan;
                case "Baseball Bat": return Resources.BaseballBatt;
                case "Hammer": return Resources.Hammer1;
                case "Tomahawk": return Resources.Tomahawk;
                case "Poison Dart": return Resources.PoisonDart;
                case "Forum Flag": return Resources.ForumFlag;
                case "Csharp Book": return Resources.CSharpBook;
                case "Help from Teammate": return Resources.HelpFromTeamMate;
                case "Help from Trainer": return Resources.HelpFromTrainer;
                case "Virus": return Resources.Virus;
                default: return Resources.Empty;
            }
        }

        private void btnJobAgency_Click(object sender, EventArgs e)
        {
            pnlFight.Visible = true;
            LoadFight();
            LoadButtons();
        }
       
        private void btnPizza_Click(object sender, EventArgs e)
        {
            pnlPizza.Visible = true;
        }

        private void btnGym_Click(object sender, EventArgs e)
        {
            pnlFight.Visible = true;
            LoadFight();
            LoadButtons();

        }

        private void btnMall_Click(object sender, EventArgs e)
        {
          pnlMall.Visible = true;
        }

        private void btnDreamJob_Click(object sender, EventArgs e)
        {
            pnlFight.Visible = true;
            LoadFight();
            LoadButtons();

        }

        private void btnCinema_Click(object sender, EventArgs e)
        {
            pnlCinema.Visible = true;
        }

        private void btnSchool_Click(object sender, EventArgs e)
        {
            pnlFight.Visible = true;  
            LoadFight();
            LoadButtons();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream file = openDialog.OpenFile())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ninja = (Ninja)formatter.Deserialize(file);
                    btnOK.Visible = false;
                    lblName.Text = ninja.Name;
                    txtName.Visible = false;
                    lblName.Visible = true;
                }
            }
            btnHome_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream file = saveDialog.OpenFile())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(file, ninja);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            pnlMall.Visible = false;
        }

        private void btnPizzaBack_Click(object sender, EventArgs e)
        {
            pnlPizza.Visible = false;
        }

        private void btnCinemaPlayBilliard_Click(object sender, EventArgs e)
        {

        }

        private void btnCinemaWatchMovie_Click(object sender, EventArgs e)
        {

        }

        private void btnCinemaBack_Click(object sender, EventArgs e)
        {
            pnlCinema.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce1_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy8_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy6_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy4_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy2_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy9_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy7_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy5_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy3_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy1_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental10_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental8_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental6_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental4_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental2_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental9_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental7_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental5_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental3_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialMental1_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental10_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental8_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental6_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental4_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental2_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental9_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental7_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental5_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental3_Click(object sender, EventArgs e)
        {

        }

        private void btnFightMental1_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce10_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce8_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce6_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce4_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce2_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce9_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce7_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce5_Click(object sender, EventArgs e)
        {

        }

        private void btnFightForce3_Click(object sender, EventArgs e)
        {

        }

        private void btnFightEnergy10_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce10_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce8_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce6_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce4_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce2_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce9_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce7_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce5_Click(object sender, EventArgs e)
        {

        }

        private void btnFightSpecialForce3_Click(object sender, EventArgs e)
        {

        }

        private void btnMallShurikan_Click(object sender, EventArgs e)
        {

        }

        private void btnMallBaseball_Click(object sender, EventArgs e)
        {

        }

        private void btnmallHammer_Click(object sender, EventArgs e)
        {

        }

        private void btnMallTomahawk_Click(object sender, EventArgs e)
        {

        }

        private void btnMallPoisonDarts_Click(object sender, EventArgs e)
        {

        }

        private void btnMallForumFlag_Click(object sender, EventArgs e)
        {

        }

        private void btnMallCSharpBook_Click(object sender, EventArgs e)
        {

        }

        private void btnMallHelpFromTeammate_Click(object sender, EventArgs e)
        {

        }

        private void btnMallHelpFromTrainer_Click(object sender, EventArgs e)
        {

        }

        private void btnMallVirus_Click(object sender, EventArgs e)
        {

        }

        private void btnPizzaCoke_Click(object sender, EventArgs e)
        {

        }

        private void btnPizzaCoffee_Click(object sender, EventArgs e)
        {

        }

        private void btnPizzaIceCream_Click(object sender, EventArgs e)
        {

        }

        private void btnPizzaBurger_Click(object sender, EventArgs e)
        {

        }

        private void btnPizzaPizza_Click(object sender, EventArgs e)
        {

        }

        private void btnPizzaEnergyDrink_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ninja.SetNinjaName(txtName.Text);
                btnOK.Visible = false;
                lblName.Text = txtName.Text;
                txtName.Visible = false;
                lblName.Visible = true;
            }
            catch(ImproperlyDefinedCreatureException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        bool isFirstClick = true;
        private void txtName_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                txtName.Text = "";
                isFirstClick = false;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtName.Focused == true)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
