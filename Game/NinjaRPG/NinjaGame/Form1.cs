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
        CommercialBuilding mall;
        CommercialBuilding fastFood;

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
                    energyButtons[energyIndex].BackgroundImage = GiveBackgroundImage(item.Name);
                    energyButtons[energyIndex].Visible = true;
                    energyIndex++;
                }
                else
                {
                    if ((item as IAttack).AttackType == AttackTypeEnum.ForceAttack)
                    {
                        specialForcePowerButtons[forceIndex].BackgroundImage = GiveBackgroundImage(item.Name);
                        specialForcePowerButtons[forceIndex].Visible = true;
                        forceIndex++;
                    }
                    else
                    {
                        specialMentalPowerButtons[mentalIndex].BackgroundImage = GiveBackgroundImage(item.Name);
                        specialMentalPowerButtons[mentalIndex].Visible = true;
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
                case "dr.Peter": return Resources.Coke;
                case "LaVisio": return Resources.Coffee;
                case "Icegida": return Resources.Icecream;
                case "Big Max": return Resources.Burger;
                case "A la Programa": return Resources.Pizza1;
                case "Doberman": return Resources.Energydrink;
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
        
        private void BuyItem(ICommercial item, Button button)
        {
            try
            {
                ninja.PayForItem(item);                                          //must to fix it with the real method
                MessageBox.Show("You bought " + ninja.BagOfItems[ninja.BagOfItems.Count - 1].Name);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            button.PerformClick();
        }

        private void btnJobAgency_Click(object sender, EventArgs e)
        {
            pnlFight.Visible = true;
            LoadFight();
            LoadButtons();
        }
       
        private void btnPizza_Click(object sender, EventArgs e)
        {
            fastFood = FastFood.Instance;

            pnlPizza.Visible = true;
            lblPizzaCashValue.Text = ninja.Cash.ToString();
            lblPizzaCokePrice.Text = "Price:" + fastFood.Goods[0].Price;
            lblPizzaCokeEnergy.Text = "Energy: " + ((Energizer)fastFood.Goods[0]).HealingPoints;
            lblPizzaCoffeePrice.Text = "Price:" + fastFood.Goods[1].Price;
            lblPizzaCoffeeEnergy.Text = "Energy: " + ((Energizer)fastFood.Goods[1]).HealingPoints;
            lblPizzaIceCreamPrice.Text = "Price:" + fastFood.Goods[2].Price;
            lblPizzaIceCreamEnergy.Text = "Energy: " + ((Energizer)fastFood.Goods[2]).HealingPoints; ;
            lblPizzaHamburgerPrice.Text = "Price:" + fastFood.Goods[3].Price;
            lblPizzaHamburgerEnergy.Text = "Energy: " + ((Energizer)fastFood.Goods[3]).HealingPoints;
            lblPizzaPizzaPrice.Text = "Price:" + fastFood.Goods[4].Price;
            lblPizzaPizzaEnergy.Text = "Energy: " + ((Energizer)fastFood.Goods[4]).HealingPoints;
            lblPizzaEnergydrinkPrice.Text = "Price:" + fastFood.Goods[5].Price;
            lblPizzaEnergydrinkEnergy.Text = "Energy: " + ((Energizer)fastFood.Goods[5]).HealingPoints;
        }

        private void btnGym_Click(object sender, EventArgs e)
        {
            pnlFight.Visible = true;
            LoadFight();
            LoadButtons();

        }

        private void btnMall_Click(object sender, EventArgs e)
        {
            mall = ShoppingMall.Instance;

            pnlMall.Visible = true;
            lblMallCash.Text = ninja.Cash.ToString();
            lblMallShurikanPrice.Text = "Price:" + mall.Goods[2].Price;
            lblMallShurikanPower.Text = "Power: " + ((Power)mall.Goods[2]).AttackPower;
            lblMallBaseballPrice.Text = "Price:" + mall.Goods[1].Price;
            lblMallBaseballPower.Text = "Power: " + ((Power)mall.Goods[1]).AttackPower;
            lblMallHammerPrice.Text = "Price:" + mall.Goods[0].Price;
            lblMallHammerPower.Text = "Power: " + ((Power)mall.Goods[0]).AttackPower; ;
            lblMallTomahawkPrice.Text = "Price:" + mall.Goods[3].Price;
            lblMallTomahawkPower.Text = "Power: " + ((Power)mall.Goods[3]).AttackPower;
            lblMallPoisonDartPrice.Text = "Price:" + mall.Goods[4].Price;
            lblMallPoisonDartPower.Text = "Power: " + ((Power)mall.Goods[4]).AttackPower;
            lblMallForumflagPrice.Text = "Price:" + mall.Goods[5].Price;
            lblMallForumflagPower.Text = "Power: " + ((Power)mall.Goods[5]).AttackPower;
            lblCSharpBookPrice.Text = "Price:" + mall.Goods[7].Price;
            lblCSharpBookPower.Text = "Power: " + ((Power)mall.Goods[7]).AttackPower;
            lblMallHelpFromTeamPrice.Text = "Price:" + mall.Goods[8].Price;
            lblHelpFromTeamPower.Text = "Power: " + ((Power)mall.Goods[8]).AttackPower;
            lblHelpFromTrainerPrice.Text = "Price:" + mall.Goods[9].Price;
            lblHelpFromTrainerPower.Text = "Power: " + ((Power)mall.Goods[9]).AttackPower;
            lblMallVirusPrice.Text = "Price:" + mall.Goods[6].Price;
            lblMallVirusPower.Text = "Power: " + ((Power)mall.Goods[6]).AttackPower;
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
            BuyItem(mall.Goods[2], btnMall);
        }

        private void btnMallBaseball_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[1], btnMall);
        }

        private void btnmallHammer_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[0], btnMall);
        }

        private void btnMallTomahawk_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[3], btnMall);
        }

        private void btnMallPoisonDarts_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[4], btnMall);
        }

        private void btnMallForumFlag_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[5], btnMall);
        }

        private void btnMallCSharpBook_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[7], btnMall);
        }

        private void btnMallHelpFromTeammate_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[8], btnMall);
        }

        private void btnMallHelpFromTrainer_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[9], btnMall);
        }

        private void btnMallVirus_Click(object sender, EventArgs e)
        {
            BuyItem(mall.Goods[6], btnMall);
        }

        private void btnPizzaCoke_Click(object sender, EventArgs e)
        {
            BuyItem(fastFood.Goods[0], btnPizza);
        }

        private void btnPizzaCoffee_Click(object sender, EventArgs e)
        {
            BuyItem(fastFood.Goods[1], btnPizza);
        }

        private void btnPizzaIceCream_Click(object sender, EventArgs e)
        {
            BuyItem(fastFood.Goods[2], btnPizza);
        }

        private void btnPizzaBurger_Click(object sender, EventArgs e)
        {
            BuyItem(fastFood.Goods[3], btnPizza);
        }

        private void btnPizzaPizza_Click(object sender, EventArgs e)
        {
            BuyItem(fastFood.Goods[4], btnPizza);
        }

        private void btnPizzaEnergyDrink_Click(object sender, EventArgs e)
        {
            BuyItem(fastFood.Goods[5], btnPizza);
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
