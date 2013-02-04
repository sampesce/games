using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Project2
{
    class Attack
    {

        static public int attackX = 0;
        static public int attackY = 0;
        public Rectangle attackPos;
        public bool isAlive = true;

        public Attack(int xPos, int yPos)
        {

            attackX = xPos;
            attackY = yPos;
            attackPos = new Rectangle(attackX+30,attackY,30,30);

        }

        



    }
}
