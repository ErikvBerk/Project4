using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_game4
{
    class Menu :IGUIelement
    {
        GraphicsDeviceManager graphics;
        Button Play;
        Button Highscore;
        Button Instructions;
        Button Exit;
        SpriteBatch spriteBatch;
        SpriteFont Font;
        Texture2D rect;

        public Menu (GraphicsDeviceManager graphics,Texture2D rect,SpriteFont Font)
            {
            this.graphics = graphics;
            this.Font = Font;

            Play = new Button("Play", rect, 100, 200, this.Font,200,30,Color.Red);
        }
        public void Update(float dt)
        {
            
        }
        public void Draw(SpriteBatch spritebatch)
        {
            
            Play.Draw(spritebatch);
                //
                //rect = new Texture2D(graphics.GraphicsDevice, 200, 30);

        }
    }
}
