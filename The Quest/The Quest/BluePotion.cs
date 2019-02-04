using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Quest
{
    class BluePotion : Weapon, IPotion
    {
        private bool used = false;
        public bool Used { get { return used; } }
        public BluePotion(Game game, Point location) : base(game, location)
        {
        }

        public override string Name
        {
            get { { return "BluePotion"; } }
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasedPlayerHealth(5, random);
            used = true;

        }
    }
}
