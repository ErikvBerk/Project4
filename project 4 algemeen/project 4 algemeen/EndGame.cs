using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Microsoft.VisualBasic;
using project_4_algemeen;
using Microsoft.Xna.Framework.Content;

namespace project_4_algemeen
{
    class EndGame
    {
        string endscreen = "Level cleared!";
        string gameoverscreen = "Game Over!";

        public EndGame()
        {            
            // draws endscreens
            //if (Player.Dead == true) {gameoverscreen.draw(SpriteBatch spritebatch) } 
            //else if (Level_Boss.LevelCleared == true){endscreen.draw(SpriteBatch spritebatch) }
        }
    }
}
