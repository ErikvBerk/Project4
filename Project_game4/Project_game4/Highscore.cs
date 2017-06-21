using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.VisualBasic;


namespace Project_game4
{
    class Highscore
    {
        SpriteFont Font;

        public Highscore(SpriteFont font)
        {
            this.Font = font;

        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.Font, "Highscore", new Vector2(100, 200), Color.Red);
        }
    }
}
