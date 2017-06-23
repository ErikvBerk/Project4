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

namespace Project_game4
{
    class Back : I_Button_classes
    {
        string name;
        Texture2D texture;
        GraphicsDeviceManager graphics;
        int X, Y, Width, Height;
        string text;
        Color Color, Hovercolor;
        SpriteFont Font;

        public Back(string name,int x, int y, int width, int height, String text, SpriteFont font, float textsize, Color color, Color hovercolor, GraphicsDeviceManager graphics)
        {
            this.name = name;
            this.graphics = graphics;
            this.graphics = graphics;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.text = text;
            this.Color = color;
            this.Hovercolor = hovercolor;


            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(100), (int) (100));
            Color[] data = new Color[(int)(100) * (int)(100)];
            for (int i = 0; i<data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);

            Console.WriteLine("Back works constructor");

        }
        public void action()
        {
            throw new NotImplementedException();
        }

        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(100, 200), Color.White);
            spritebatch.DrawString(Font, this.name, new Vector2(this.X, this.Y), Color.Black);

            Console.WriteLine("Back draw works");
        }

        public string get_name()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
