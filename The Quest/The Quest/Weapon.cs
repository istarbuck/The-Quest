using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace The_Quest
{
    public abstract class Weapon : Mover
    {
        protected Game game;
        private bool pickedUp;
        public bool PickedUp { get { return pickedUp; } }
        private Point location;
        public Point Location { get { return location; } }

        public Weapon(Game game, Point location)
        {
            this.game = game;
            this.location = location;
            pickedUp = false;
        }
        
        public void PickUpWeapon()
        {
            pickedUp = true;
        }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        public bool Nearby(Point location1, Point location2, int distance)
        {
            if (Math.Abs(location2.X - location1.X) < distance && (Math.Abs(location2.Y - location1.Y) < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {

            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }

                }
                target = Move(direction, game.Boundaries);
            }
            return false;
        }
    }
}
