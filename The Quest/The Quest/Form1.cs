using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace The_Quest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;
        private Player user;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }



        public void UpdateCharacters()
        {
            player.Location = game.PlayerLocation;
            playerHitPoints.Text = game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }

                else if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }

                else if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }

            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;

            iSword.Visible = false;
            iBow.Visible = false;
            iRedPotion.Visible = false;
            iBluePotion.Visible = false;
            iMace.Visible = false;

            Control weaponControl = new Control();
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword; break;
                case "Bow":
                    weaponControl = bow; break;
                case "Mace":
                    weaponControl = mace; break;
                case "RedPotion":
                    weaponControl = redPotion; break;
                case "BluePotion":
                    weaponControl = bluePotion; break;

            }
            weaponControl.Visible = true;

            
            if (game.CheckPlayerInventory("Sword"))
            {
                iSword.Visible = true;
            }
           
            if(game.CheckPlayerInventory("Mace"))
                iMace.Visible=true;
            
            if(game.CheckPlayerInventory("Bow"))           
                iBow.Visible=true;

            if(game.CheckPlayerInventory("RedPotion"))
                iRedPotion.Visible=true;

            if(game.CheckPlayerInventory("BluePotion"))
                iBluePotion.Visible=true;
            

            if (showBat)
                bat.Visible = true;
            else
                bat.Visible = false;
            if (showGhost)
                ghost.Visible = true;
            else
                ghost.Visible = false;
            if (showGhoul)
                ghoul.Visible = true;
            else
                ghoul.Visible = false;

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visible = false;
            }
            else
                weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        public void EquipWeapon(string weapon)
        {
            if ("Sword" != weapon)
                iSword.BorderStyle = BorderStyle.None;
            if ("Mace" != weapon)
                iMace.BorderStyle = BorderStyle.None;
            if ("Bow" != weapon)
                iBow.BorderStyle = BorderStyle.None;
            if ("RedPotion" != weapon)
                iRedPotion.BorderStyle = BorderStyle.None;
            if ("BluePotion" != weapon)
                iBluePotion.BorderStyle = BorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Move(The_Quest.IDirection.Direction.Up, random);
            UpdateCharacters();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.Move(The_Quest.IDirection.Direction.Left, random);
            UpdateCharacters();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.Move(The_Quest.IDirection.Direction.Down, random);
            UpdateCharacters();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.Move(The_Quest.IDirection.Direction.Right, random);
            UpdateCharacters();
        }

        private void iSword_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                EquipWeapon("Sword");
                iSword.BorderStyle = BorderStyle.FixedSingle;
            }
         
        }

        private void iBow_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                EquipWeapon("Bow");
                iBow.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void iMace_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                EquipWeapon("Mace");
                iMace.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void iBluePotion_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("BluePotion"))
            {
                game.Equip("BluePotion");
                EquipWeapon("BluePotion");
                iBluePotion.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void iRedPotion_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("RedPotion"))
            {
                game.Equip("RedPotion");
                EquipWeapon("RedPotion");
                iRedPotion.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            game.Attack(IDirection.Direction.Up, random);
            UpdateCharacters();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            game.Attack(IDirection.Direction.Left, random);
            UpdateCharacters();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            game.Attack(IDirection.Direction.Down, random);
            UpdateCharacters();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            game.Attack(IDirection.Direction.Right, random);
            UpdateCharacters();
        }



    }
}
