using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Quest
{
    class Ghoul :Enemy
    {
        public Ghoul(Game game, Point location) : base(game, location, 10)
        {

        }


        public override void Move(Random random)
        {
            int move = random.Next(1, 3);

            if (move != 1)
            {
                base.location = Move(FindPlayerDirection(location), game.Boundaries);

            }

            if (NearPlayer())
                game.HitPlayer(4, random);
            
        }
    }
}
