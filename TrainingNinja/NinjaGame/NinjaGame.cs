namespace NinjaGame
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using System.Windows.Forms;
    using NinjaGame.Properties;
    using WorldOfNinja;
    using WorldOfNinja.Buildings;
    using WorldOfNinja.Creatures;
    using WorldOfNinja.Interfaces;
    using WorldOfNinja.Item;

    public partial class FrmStart : Form
    {
        private bool fightForJob = false;

        private ICreature evil;
        private Ninja ninja;
        private Arena arena;
        private Job job;
        private JobOffice jobOffice;
        private bool isFirstClick = true;

        // DreamJob boss; 
        private CommercialBuilding mall;
        private CommercialBuilding fastFood;
        private CommercialBuilding playground;
        private PictureBox[] forcePowerButtons;
        private PictureBox[] mentalPowerButtons;
        private PictureBox[] speciaItemsButtons;
        private List<IUsable> temporaryBag;
        private List<IUsable> temporaryForceBag;
        private List<IUsable> temporaryMentalBag;

        public FrmStart()
        {
            this.InitializeComponent();
            ninja = new Ninja("Ninja");
            this.prgrsEnergy.Maximum = this.ninja.TotalEnergy;
            this.prgrsEnergy.Value = this.ninja.CurrentEnergy;
        }

        private void BtnHomeClick(object sender, EventArgs e)
        {
            this.pnlHome.Visible = true;

            this.lblCashValue.Text = this.ninja.Cash.ToString();
            this.prgrsForce.Maximum = this.ninja.TotalStepsToNextForceLevel;
            this.prgrsForce.Value = this.ninja.CurrentStepForceLevel;
            this.prgrsMental.Maximum = this.ninja.TotalStepsToNextMentalLevel;
            this.prgrsMental.Value = this.ninja.CurrentStepMentalLevel;
            this.prgrEnergy.Maximum = this.ninja.TotalEnergy;
            this.prgrEnergy.Value = this.ninja.CurrentEnergy;
            this.lblForceLevelValue.Text = this.ninja.ForceLevel.ToString();
            this.lblMentalLevelValue.Text = this.ninja.MentalLevel.ToString();
            this.lblMaxForce.Text = this.ninja.TotalStepsToNextMentalLevel.ToString();
            this.lblMaxMental.Text = this.ninja.TotalStepsToNextMentalLevel.ToString();
            this.lblMaxEnergy.Text = this.ninja.TotalEnergy.ToString();

            this.forcePowerButtons = new PictureBox[10]
            {
                this.picHomeForce1,
                this.picHomeForce2,
                this.picHomeForce3,
                this.picHomeForce4,
                this.picHomeForce5,
                this.picHomeForce6,
                this.picHomeForce7,
                this.picHomeForce8,
                this.picHomeForce9,
                this.picHomeForce10
            };

            this.mentalPowerButtons = new PictureBox[10] 
            {
               this.picHomeMental1,
               this.picHomeMental2,
               this.picHomeMental3,
               this.picHomeMental4,
               this.picHomeMental5,
               this.picHomeMental6, 
               this.picHomeMental7, 
               this.picHomeMental8, 
               this.picHomeMental9, 
               this.picHomeMental10 
            };

            this.speciaItemsButtons = new PictureBox[30] 
            {
                this.picHomeSpecialForce1, 
                this.picHomeSpecialForce2,
                this.picHomeSpecialForce3, 
                this.picHomeSpecialForce4, 
                this.picHomeSpecialForce5, 
                this.picHomeSpecialForce6, 
                this.picHomeSpecialForce7, 
                this.picHomeSpecialForce8, 
                this.picHomeSpecialForce9,
                this.picHomeSpecialForce10,
                this.picHomeSpecialMental1, 
                this.picHomeSpecialMental2, 
                this.picHomeSpecialMental3, 
                this.picHomeSpecialMental4, 
                this.picHomeSpecialMental5,
                this.picHomeSpecialMental6, 
                this.picHomeSpecialMental7, 
                this.picHomeSpecialMental8, 
                this.picHomeSpecialMental9,
                this.picHomeSpecialMental10,
                this.picHomeEnergizers1, 
                this.picHomeEnergizers2, 
                this.picHomeEnergizers3,
                this.picHomeEnergizers4,
                this.picHomeEnergizers5,
                this.picHomeEnergizers6,
                this.picHomeEnergizers7, 
                this.picHomeEnergizers8,
                this.picHomeEnergizers9,
                this.picHomeEnergizers10 
            };
            this.LoadButtons();
        }

        private void LoadButtons()
        {
            for (int i = 0; i < this.ninja.ListOfFightingSkills.Count; i++)
            {
                this.forcePowerButtons[i].Visible = true;
            }

            for (int i = 0; i < this.ninja.ListOfMentalSkills.Count; i++)
            {
                this.mentalPowerButtons[i].Visible = true;
            }

            var bagOfItems = this.ninja.BagOfItems
                    .OrderBy(it => it.GetType().Name)
                    .ThenBy(it => it.Price)
                    .ToList();

            int speciaItemsIndex = 0;

            foreach (var item in bagOfItems)
            {
                this.speciaItemsButtons[speciaItemsIndex].BackgroundImage = GiveBackgroundImage(item.Name);
                this.speciaItemsButtons[speciaItemsIndex].Visible = true;
                speciaItemsIndex++;
            }
        }

        private void DeclareFightButtons()
        {
            this.forcePowerButtons = new PictureBox[10] 
            { 
               this.btnFightForce1, 
               this.btnFightForce2, 
               this.btnFightForce3, 
               this.btnFightForce4, 
               this.btnFightForce5, 
               this.btnFightForce6, 
               this.btnFightForce7, 
               this.btnFightForce8, 
               this.btnFightForce9, 
               this.btnFightForce10 
            };

            this.mentalPowerButtons = new PictureBox[10] 
            {
                this.btnFightMental1, 
                this.btnFightMental2, 
                this.btnFightMental3, 
                this.btnFightMental4, 
                this.btnFightMental5,
                this.btnFightMental6,
                this.btnFightMental7, 
                this.btnFightMental8,
                this.btnFightMental9, 
                this.btnFightMental10
            };

            this.speciaItemsButtons = new PictureBox[30] 
            { 
                this.btnFightSpecialForce1, 
                this.btnFightSpecialForce2, 
                this.btnFightSpecialForce3,
                this.btnFightSpecialForce4, 
                this.btnFightSpecialForce5,
                this.btnFightSpecialForce6, 
                this.btnFightSpecialForce7,
                this.btnFightSpecialForce8, 
                this.btnFightSpecialForce9,
                this.btnFightSpecialForce10,
                this.btnSpecialMental1, 
                this.btnSpecialMental2,
                this.btnSpecialMental3,
                this.btnSpecialMental4, 
                this.btnSpecialMental5, 
                this.btnSpecialMental6,
                this.btnSpecialMental7,
                this.btnSpecialMental8,
                this.btnSpecialMental9, 
                this.btnSpecialMental10,
                this.btnFightEnergy1, 
                this.btnFightEnergy2,
                this.btnFightEnergy3,
                this.btnFightEnergy4, 
                this.btnFightEnergy5,
                this.btnFightEnergy6,
                this.btnFightEnergy7,
                this.btnFightEnergy8,
                this.btnFightEnergy9,
                this.btnFightEnergy10 
            };
        }

        private Bitmap GiveBackgroundImage(string name)
        {
            switch (name)
            {
                case "Dr.Peter's Cola": return Resources.Coke;
                case "Coffee LaVasioo": return Resources.Coffee;
                case "Ice Cream Icegida": return Resources.Icecream;
                case "Big Max Burger": return Resources.Burger;
                case "Pizza A La Programa": return Resources.Pizza1;
                case "Doberman Energy Drink": return Resources.Energydrink;
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

        private void BuyItem(CommercialBuilding building, ICommercialItem item, Button button)
        {
            try
            {
                int currentCash = this.ninja.Cash;
                building.Sell(item, ninja);
                if (currentCash == this.ninja.Cash)
                {
                    MessageBox.Show("You rich the maximum of items that you can hold (30 items)!");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            button.PerformClick();
        }

        private void BtnJobAgencyClick(object sender, EventArgs e)
        {
            this.pnlJobAgency.Visible = true;
            jobOffice = JobOffice.Instance;
        }

        private void BtnPizza_Click(object sender, EventArgs e)
        {
            this.fastFood = FastFood.Instance;

            this.pnlPizza.Visible = true;
            this.lblPizzaCashValue.Text = this.ninja.Cash.ToString();
            this.lblPizzaCokePrice.Text = "Price:" + this.fastFood.Goods[0].Price;
            this.lblPizzaCokeEnergy.Text = "Energy: " + ((IEnergizer)this.fastFood.Goods[0]).HealingPoints;
            this.lblPizzaCoffeePrice.Text = "Price:" + this.fastFood.Goods[1].Price;
            this.lblPizzaCoffeeEnergy.Text = "Energy: " + ((IEnergizer)this.fastFood.Goods[1]).HealingPoints;
            this.lblPizzaIceCreamPrice.Text = "Price:" + this.fastFood.Goods[2].Price;
            this.lblPizzaIceCreamEnergy.Text = "Energy: " + ((IEnergizer)this.fastFood.Goods[2]).HealingPoints;
            this.lblPizzaHamburgerPrice.Text = "Price:" + this.fastFood.Goods[3].Price;
            this.lblPizzaHamburgerEnergy.Text = "Energy: " + ((IEnergizer)this.fastFood.Goods[3]).HealingPoints;
            this.lblPizzaPizzaPrice.Text = "Price:" + this.fastFood.Goods[4].Price;
            this.lblPizzaPizzaEnergy.Text = "Energy: " + ((IEnergizer)this.fastFood.Goods[4]).HealingPoints;
            this.lblPizzaEnergydrinkPrice.Text = "Price:" + this.fastFood.Goods[5].Price;
            this.lblPizzaEnergydrinkEnergy.Text = "Energy: " + ((IEnergizer)this.fastFood.Goods[5]).HealingPoints;
        }

        private void BtnGym_Click(object sender, EventArgs e)
        {
            this.pnlGym.Visible = true;
        }

        private void BtnMall_Click(object sender, EventArgs e)
        {
            this.mall = ShoppingMall.Instance;

            this.pnlMall.Visible = true;
            this.lblMallCash.Text = this.ninja.Cash.ToString();
            this.lblMallShurikanPrice.Text = "Price:" + this.mall.Goods[2].Price;
            this.lblMallShurikanPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[2]).AttackPower;
            this.lblMallBaseballPrice.Text = "Price:" + this.mall.Goods[1].Price;
            this.lblMallBaseballPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[1]).AttackPower;
            this.lblMallHammerPrice.Text = "Price:" + this.mall.Goods[0].Price;
            this.lblMallHammerPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[0]).AttackPower;
            this.lblMallTomahawkPrice.Text = "Price:" + this.mall.Goods[3].Price;
            this.lblMallTomahawkPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[3]).AttackPower;
            this.lblMallPoisonDartPrice.Text = "Price:" + this.mall.Goods[4].Price;
            this.lblMallPoisonDartPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[4]).AttackPower;
            this.lblMallForumflagPrice.Text = "Price:" + this.mall.Goods[5].Price;
            this.lblMallForumflagPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[5]).AttackPower;
            this.lblCSharpBookPrice.Text = "Price:" + this.mall.Goods[7].Price;
            this.lblCSharpBookPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[7]).AttackPower;
            this.lblMallHelpFromTeamPrice.Text = "Price:" + this.mall.Goods[8].Price;
            this.lblHelpFromTeamPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[8]).AttackPower;
            this.lblHelpFromTrainerPrice.Text = "Price:" + this.mall.Goods[9].Price;
            this.lblHelpFromTrainerPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[9]).AttackPower;
            this.lblMallVirusPrice.Text = "Price:" + this.mall.Goods[6].Price;
            this.lblMallVirusPower.Text = "Power: " + ((SpecialPower)this.mall.Goods[6]).AttackPower;
        }

        private void BtnDreamJob_Click(object sender, EventArgs e)
        {
            this.pnlDreamJob.Visible = true;
        }

        private void BtnPlayground_Click(object sender, EventArgs e)
        {
            this.playground = Playground.Instance;
            this.pnlPlayground.Visible = true;
            this.lblPlaygroundCash.Text = this.ninja.Cash.ToString();
            this.lblPlaygroundPokerPrice.Text = "Price: " + this.playground.Goods[0].Price;
            this.lblPlaygroundPokerEnergy.Text = "Power: " + ((Recreation)this.playground.Goods[0]).UpgradeTotalEnergy;
            this.lblPlaygroundVideoPrice.Text = "Price: " + this.playground.Goods[1].Price;
            this.lblPlaygroundVideoEnergy.Text = "Power: " + ((Recreation)this.playground.Goods[1]).UpgradeTotalEnergy;
            this.lblPlaygroundBowlingPrice.Text = "Price: " + this.playground.Goods[2].Price;
            this.lblPlaygroundBowlingEnergy.Text = "Power: " + ((Recreation)this.playground.Goods[2]).UpgradeTotalEnergy;
            this.lblPlaygroundBilliardsPrice.Text = "Price: " + this.playground.Goods[3].Price;
            this.lblPlaygroundBilliardsEnergy.Text = "Power: " + ((Recreation)this.playground.Goods[3]).UpgradeTotalEnergy;
            this.lblPlaygroundDancePrice.Text = "Price: " + this.playground.Goods[4].Price;
            this.lblPlaygroundDanceEnergy.Text = "Power: " + ((Recreation)this.playground.Goods[4]).UpgradeTotalEnergy;
        }

        private void BtnSchool_Click(object sender, EventArgs e)
        {
            this.pnlSchool.Visible = true;
        }

        private void FrmStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string Message = "Do you want to save changes?";
            const string Caption = "Ninja";
            var result = MessageBox.Show(Message, Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.BtnSave_Click(sender, e);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Ninja Files | *.ninja";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream file = openDialog.OpenFile())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    this.ninja = (Ninja)formatter.Deserialize(file);
                    this.btnOK.Visible = false;
                    this.lblName.Text = ninja.Name;
                    this.txtName.Visible = false;
                    this.lblName.Visible = true;
                }
            }

            this.BtnHomeClick(sender, e);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Ninja files | *.ninja";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream file = saveDialog.OpenFile())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(file, ninja);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.pnlHome.Visible = false;
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            this.pnlMall.Visible = false;
        }

        private void BtnPizzaBackClick(object sender, EventArgs e)
        {
            this.pnlPizza.Visible = false;
        }

        private void BtnCinemaBackClick(object sender, EventArgs e)
        {
            this.pnlPlayground.Visible = false;
            this.prgrsEnergy.Maximum = ninja.TotalEnergy;
            this.prgrsEnergy.Value = ninja.CurrentEnergy;
        }

        private void BtnFightForce1_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[0]);
        }

        private void Fight(IUsable attack)
        {
            if (evil.GetType().Name == "Jedi")
            {
                this.Battle(Resources.EnemyJedi, Resources.EnemyJediHit, Resources.EnemyJediDead, attack);
            }
            else if (evil.GetType().Name == "Assassin" || evil.GetType().Name == "Boss")
            {
                this.Battle(Resources.EnemyGoblin, Resources.EnemyGoblinHitted, Resources.EnemyGoblinDead, attack);
            }
            else
            {
                this.Battle(Resources.EnemyRobo, Resources.EnemyRoboHit, Resources.EnemyRoboDead, attack);
            }
        }

        private void Battle(Bitmap image1, Bitmap image2, Bitmap image3, IUsable attack)
        {
            this.picEvil.BackgroundImage = image2;
            this.pnlFight.Refresh();
            Thread.Sleep(200);
            this.picEvil.BackgroundImage = image1;
            this.pnlFight.Refresh();
            Thread.Sleep(500);
            
            this.arena.Fight(attack);

            this.picNinja.BackgroundImage = Resources.NinjaFightHit;
            this.pnlFight.Refresh();
            Thread.Sleep(200);
            this.picNinja.BackgroundImage = Resources.NinjaFight;

            if (this.ninja.CurrentEnergy < 0)
            {
                this.prgrsFightNinja.Value = 0;
            }
            else
            {
                this.prgrsFightNinja.Value = this.ninja.CurrentEnergy;
            }

            if (this.evil.CurrentEnergy < 0)
            {
                this.prgrsFightEvil.Value = 0;
            }
            else
            {
                this.prgrsFightEvil.Value = this.evil.CurrentEnergy;
            }

            if (arena.IsHeroWinner)
            {
                this.picNinja.BackgroundImage = Resources.NinjaChampion;
                this.picEvil.BackgroundImage = image3;

                if (fightForJob)
                {
                    jobOffice.RewardNinja(ninja, job);
                }

                this.pnlFight.Refresh();
                Thread.Sleep(1000);
                MessageBox.Show("Congratilations! You Win!");
                this.pnlFight.Visible = false;
                fightForJob = false;
            }
            else if (this.prgrsFightNinja.Value <= 0)
            {
                this.picNinja.BackgroundImage = Resources.NinjaFightDead;
                this.ninja.CurrentEnergy = this.ninja.TotalEnergy;
                this.pnlFight.Visible = false;
                fightForJob = false;
            }

            this.pnlFight.Refresh();
            Thread.Sleep(200);
        }

        private void BtnFightEnergy8Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[27]);
            btnFightEnergy8.Visible = false;
        }

        private void BtnFightEnergy6Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[25]);
            btnFightEnergy6.Visible = false;
        }

        private void BtnFightEnergy4_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[23]);
            btnFightEnergy4.Visible = false;
        }

        private void BtnFightEnergy2_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[21]);
            btnFightEnergy2.Visible = false;
        }

        private void BtnFightEnergy9_Click(object sender, EventArgs e)
        {
           Fight(temporaryBag[28]);
            btnFightEnergy9.Visible = false;
        }

        private void BtnFightEnergy7_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[26]);
            btnFightEnergy7.Visible = false;
        }

        private void BtnFightEnergy5_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[24]);
            btnFightEnergy5.Visible = false;
        }

        private void BtnFightEnergy3_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[22]);
            btnFightEnergy3.Visible = false;
        }

        private void BtnFightEnergy1_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[20]);
            btnFightEnergy1.Visible = false;
        }

        private void BtnSpecialMental10_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[19]);
            btnSpecialMental10.Visible = false;
        }

        private void BtnSpecialMental8_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[17]);
            btnSpecialMental8.Visible = false;
        }

        private void BtnSpecialMental6_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[15]);
            btnSpecialMental6.Visible = false;
        }

        private void BtnSpecialMental4_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[13]);
            btnSpecialMental4.Visible = false;
        }

        private void BtnSpecialMental2_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[11]);
            btnSpecialMental2.Visible = false;
        }

        private void BtnSpecialMental9_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[18]);
            btnSpecialMental9.Visible = false;
        }

        private void BbtnSpecialMental7_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[16]);
            btnSpecialMental6.Visible = false;
        }

        private void BtnSpecialMental5_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[15]);
            btnSpecialMental5.Visible = false;
        }

        private void BtnSpecialMental3_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[12]);
            btnSpecialMental3.Visible = false;
        }

        private void BtnSpecialMental1_Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[10]);
            btnSpecialMental1.Visible = false;
        }

        private void BtnFightMental10_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[9]);
        }

        private void BtnFightMental8_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[7]);
        }

        private void BtnFightMental6_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[5]);
        }

        private void BtnFightMental4_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[3]);
        }

        private void BtnFightMental2_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[1]);
        }

        private void BtnFightMental9_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[8]);
        }

        private void BtnFightMental7_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[6]);
        }

        private void BtnFightMental5_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[4]);
        }

        private void BtnFightMental3_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[2]);
        }

        private void BtnFightMental1_Click(object sender, EventArgs e)
        {
            Fight(temporaryMentalBag[0]);
        }

        private void BtnFightForce10_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[9]);
        }

        private void BtnFightForce8_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[7]);
        }

        private void BtnFightForce6_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[5]);
        }

        private void BtnFightForce4_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[3]);
        }

        private void BtnFightForce2_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[1]);
        }

        private void BtnFightForce9_Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[8]);
        }

        private void BtnFightForce7Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[6]);
        }

        private void BtnFightForce5Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[4]);
        }

        private void BtnFightForce3Click(object sender, EventArgs e)
        {
            Fight(temporaryForceBag[2]);
        }

        private void BtnFightEnergy10Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[29]);
        }

        private void BtnFightSpecialForce1Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[0]);
            btnFightSpecialForce1.Visible = false;
        }

        private void BtnFightSpecialForce10Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[9]);
            btnFightSpecialForce10.Visible = false;
        }

        private void BtnFightSpecialForce8Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[7]);
            btnFightSpecialForce8.Visible = false;
        }

        private void BtnFightSpecialForce6Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[5]);
            btnFightSpecialForce6.Visible = false;
        }

        private void BtnFightSpecialForce4Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[3]);
            btnFightSpecialForce4.Visible = false;
        }

        private void BtnFightSpecialForce2Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[1]);
            btnFightSpecialForce2.Visible = false;
        }

        private void BtnFightSpecialForce9Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[8]);
            btnFightSpecialForce9.Visible = false;
        }

        private void BtnFightSpecialForce7Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[6]);
            btnFightSpecialForce7.Visible = false;
        }

        private void BtnFightSpecialForce5Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[4]);
            btnFightSpecialForce5.Visible = false;
        }

        private void BtnFightSpecialForce3Click(object sender, EventArgs e)
        {
            Fight(temporaryBag[2]);
            btnFightSpecialForce3.Visible = false;
        }

        private void BtnMallShurikanClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[2], this.btnMall);
        }

        private void BtnMallBaseballClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[1], this.btnMall);
        }

        private void BtnmallHammerClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[0], this.btnMall);
        }

        private void BtnMallTomahawkClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[3], this.btnMall);
        }

        private void BtnMallPoisonDartsClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[4], this.btnMall);
        }

        private void BtnMallForumFlagClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[5], this.btnMall);
        }

        private void BtnMallCSharpBookClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[7], this.btnMall);
        }

        private void BtnMallHelpFromTeammateClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[8], this.btnMall);
        }

        private void BtnMallHelpFromTrainerClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[9], this.btnMall);
        }

        private void BtnMallVirusClick(object sender, EventArgs e)
        {
            this.BuyItem(this.mall, this.mall.Goods[6], this.btnMall);
        }

        private void BtnPizzaCokeClick(object sender, EventArgs e)
        {
            this.BuyItem(this.fastFood, this.fastFood.Goods[0], this.btnPizza);
        }

        private void BtnPizzaCoffeeClick(object sender, EventArgs e)
        {
            this.BuyItem(this.fastFood, this.fastFood.Goods[1], this.btnPizza);
        }

        private void BtnPizzaIceCreamClick(object sender, EventArgs e)
        {
            this.BuyItem(fastFood, this.fastFood.Goods[2], this.btnPizza);
        }

        private void BtnPizzaBurgerClick(object sender, EventArgs e)
        {
            this.BuyItem(this.fastFood, this.fastFood.Goods[3], this.btnPizza);
        }

        private void BtnPizzaPizzaClick(object sender, EventArgs e)
        {
            this.BuyItem(this.fastFood, this.fastFood.Goods[4], this.btnPizza);
        }

        private void BtnPizzaEnergyDrinkClick(object sender, EventArgs e)
        {
            this.BuyItem(this.fastFood, this.fastFood.Goods[5], this.btnPizza);
        }

        private void BtnOKClick(object sender, EventArgs e)
        {
            try
            {
                //this.ninja.SetNinjaName(this.txtName.Text);
                ninja = new Ninja(txtName.Text);
                this.btnOK.Visible = false;
                this.lblName.Text = this.txtName.Text;
                this.txtName.Visible = false;
                this.lblName.Visible = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TxtNameClick(object sender, EventArgs e)
        {
            if (this.isFirstClick)
            {
                this.txtName.Text = "";
                this.isFirstClick = false;
            }
        }

        private void TxtNameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && this.txtName.Focused == true)
            {
                this.BtnOKClick(sender, e);
            }
        }

        private void BtnPlaygroundPokerClick(object sender, EventArgs e)
        {
            this.BuyItem(this.playground, this.playground.Goods[0], this.btnPlayground);
        }

        private void BtnPlaygroundVideoGameClick(object sender, EventArgs e)
        {
            this.BuyItem(this.playground, this.playground.Goods[1], this.btnPlayground);
        }

        private void BtnPlaygroundBilliardClick(object sender, EventArgs e)
        {
            this.BuyItem(this.playground, this.playground.Goods[3], this.btnPlayground);
        }

        private void BtnPlaygroundBowlingClick(object sender, EventArgs e)
        {
            this.BuyItem(this.playground, this.playground.Goods[2], this.btnPlayground);
        }

        private void BtnPlaygroundDanceClick(object sender, EventArgs e)
        {
            this.BuyItem(this.playground, this.playground.Goods[4], this.btnPlayground);
        }

        private void BtnJobAgencyBackClick(object sender, EventArgs e)
        {
            this.pnlJobAgency.Visible = false;
        }
        
        private void BtnJobAgencyFightClick(object sender, EventArgs e)
        {
            fightForJob = true;
            var list = jobOffice.GenerateJobsFor(ninja);

            ////this.ReturnCheckedButton();
            ////this.building = JobOffice.Instance;
            ////building.ApplyForJob(ninja, job);
            ////building.ApplyForJob(ninja, job, evil);
            arena = jobOffice.ApplyForJob(ninja, ReturnCheckedButton(list));
            evil = arena.Creature;

            this.pnlJobAgency.Visible = false;
            this.pnlFight.Visible = true;
            this.DeclareFightButtons();
            this.LoadButtons();
            if (evil.GetType().Name == "Jedi")
            {
                this.picEvil.BackgroundImage = Resources.EnemyJedi;
            }
            else if(evil.GetType().Name == "Assassin")
            {
                this.picEvil.BackgroundImage = Resources.EnemyGoblin;
            }
            else
            {
                this.picEvil.BackgroundImage = Resources.EnemyRobo;
            }

            this.lblFightNinja.Text = this.ninja.Name;
            this.lblFightEvil.Text = this.evil.Name;
            this.prgrsFightNinja.Maximum = this.ninja.TotalEnergy;
            this.prgrsFightEvil.Maximum = this.evil.TotalEnergy;
            this.prgrsFightEvil.Value = this.evil.CurrentEnergy;
            this.prgrsFightNinja.Value = this.ninja.CurrentEnergy;
            this.temporaryBag = new List<IUsable>(this.ninja.BagOfItems);
            this.temporaryForceBag = new List<IUsable>(this.ninja.ListOfFightingSkills);
            this.temporaryMentalBag = new List<IUsable>(this.ninja.ListOfMentalSkills);

            //arena = new Arena("Job Office", this.job.JobFightRules, this.ninja, this.evil);
        }
  
        private  IJob ReturnCheckedButton(IList<IJob> list)
        {
            if (radioButton1.Checked == true)
            {
                return list[0];
            }
            else if (radioButton2.Checked == true)
            {
                return list[1];
            }
            else if (radioButton3.Checked == true)
            {
                return list[2];
            }
            else if (radioButton4.Checked == true)
            {
                return list[3];
            }
            else if (radioButton5.Checked == true)
            {
                return list[4];
            }
            else if (radioButton6.Checked == true)
            {
                return list[5];
            }
            else if (radioButton7.Checked == true)
            {
                return list[6];
            }
            else if (radioButton8.Checked == true)
            {
                return list[7];
            }
            else if (radioButton9.Checked == true)
            {
                return list[8];
            }
            else if (radioButton10.Checked == true)
            {
                return list[9];
            }
            else if (radioButton11.Checked == true)
            {
                return list[10];
            }
            else if (radioButton12.Checked == true)
            {
                return list[11];
            }
            else if (radioButton13.Checked == true)
            {
                return list[12];
            }
            else if (radioButton14.Checked == true)
            {
                return list[13];
            }
            else 
            {
                return list[14];
            }
        }

        private void BtnGymBackClick(object sender, EventArgs e)
        {
            this.pnlGym.Visible = false;
        }

        private void BtnGymTraneClick(object sender, EventArgs e)
        {
            this.pnlGym.Visible = false;
            this.pnlFight.Visible = true;
            this.DeclareFightButtons();
            this.LoadButtons();
        }

        private void BtnSchoolBackClick(object sender, EventArgs e)
        {
            this.pnlSchool.Visible = false;
        }

        private void BtnSchoolFightClick(object sender, EventArgs e)
        {
            this.pnlSchool.Visible = false;
            this.pnlFight.Visible = true;
            this.DeclareFightButtons();
            this.LoadButtons();
        }

        private void BtnDreamJobBackClick(object sender, EventArgs e)
        {
            this.pnlDreamJob.Visible = false;
        }

        private void BtnDreamJobFightClick(object sender, EventArgs e)
        {
            arena = DreamJob.Apply(ninja);
            evil = arena.Creature;

            this.pnlDreamJob.Visible = false;
            this.pnlFight.Visible = true;
            this.DeclareFightButtons();
            this.LoadButtons();
            this.lblFightNinja.Text = this.ninja.Name;
            this.lblFightEvil.Text = this.evil.Name;
            this.prgrsFightNinja.Maximum = this.ninja.TotalEnergy;
            this.prgrsFightEvil.Maximum = this.evil.TotalEnergy;
            this.prgrsFightEvil.Value = this.evil.CurrentEnergy;
            this.prgrsFightNinja.Value = this.ninja.CurrentEnergy;
            this.temporaryBag = new List<IUsable>(this.ninja.BagOfItems);
            this.temporaryForceBag = new List<IUsable>(this.ninja.ListOfFightingSkills);
            this.temporaryMentalBag = new List<IUsable>(this.ninja.ListOfMentalSkills);
        }
    }
}
