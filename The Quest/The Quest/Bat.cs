using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace The_Quest
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location) : base(game, location, 6)
        {
        }


        public override void Move(Random random)
        {
            //this.Move(Direction.Left, game.Boundaries);

            int move = random.Next(1, 3);

            if (move == 2)
            {
                base.location = Move(FindPlayerDirection(location), game.Boundaries);

            }
            else
            {
                int direct = random.Next(1, 4);
                if (direct == 1)
                    base.location = Move(Direction.Up, game.Boundaries);
                else if (direct == 2)
                    base.location = Move(Direction.Right, game.Boundaries);
                else if (direct == 3)
                    base.location = Move(Direction.Down, game.Boundaries);
                else
                    base.location = Move(Direction.Left, game.Boundaries);

            }

            if (NearPlayer())
                game.HitPlayer(2, random);
        }
    }
}
