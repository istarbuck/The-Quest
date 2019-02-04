using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace The_Quest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location)
        {
        }

        public override string Name
        {
            get { { return "Sword"; } }
        }

        public override void Attack(Direction direction, Random random)
        {
            switch (direction)
            {
                case Direction.Up:
                    DamageEnemy(Direction.Up, 30, 3, random);
                       
                    DamageEnemy(Direction.Left, 30, 3, random);

                    DamageEnemy(Direction.Right, 30, 3, random);
                    break;
                        

                case Direction.Down:
                     DamageEnemy(Direction.Up, 30, 3, random);

                     DamageEnemy(Direction.Left, 30, 3, random);

                     DamageEnemy(Direction.Right, 30, 3, random);
                     break;


                case Direction.Left:
                        DamageEnemy(Direction.Left, 30, 3, random);
                        DamageEnemy(Direction.Down, 30, 3, random);

                        DamageEnemy(Direction.Up, 30, 3, random);
                    break;


                case Direction.Right:
                    DamageEnemy(Direction.Right, 30, 3, random);

                    DamageEnemy(Direction.Up, 30, 3, random);

                    DamageEnemy(Direction.Down, 30, 3, random);
                    break;

                       
            }
            
        }
    }
}
