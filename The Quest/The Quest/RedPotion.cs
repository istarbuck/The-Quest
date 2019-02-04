using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Quest
{
    class RedPotion : Weapon, IPotion
    {
        private bool used = false;
        public bool Used { get { return used; } }
        public RedPotion(Game game, Point location) : base(game, location)
        {
        }

        public override string Name
        {
            get { { return "RedPotion"; } }
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasedPlayerHealth(10, random);
            used = true;
            

        }
    }
}
