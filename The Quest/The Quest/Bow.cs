using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Quest
{
    class Bow : Weapon
    {
        public Bow(Game game, Point location) : base(game, location)
        {
        }

        public override string Name
        {
            get { { return "Bow"; } }
        }

        public override void Attack(Direction direction, Random random)
        {
            switch (direction)
            {
                case Direction.Up:
                    DamageEnemy(Direction.Up, 30, 1, random);
                    break;

                case Direction.Down:
                    DamageEnemy(Direction.Down, 30, 1, random);
                    break;

                case Direction.Left:
                    DamageEnemy(Direction.Left, 30, 1, random);
                    break;

                case Direction.Right:
                    DamageEnemy(Direction.Right, 30, 1, random);
                    break;
                default: break;
            }
            
        }
    }
}
