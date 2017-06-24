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
    class Instructions : I_Button_classes
    {
        public string name="Instructions";
        string class_name;
        SpriteFont Font;
        Texture2D texture;
        int X;
        int Y;
        GraphicsDeviceManager graphics;
        List<button> List_Instructions_Buttons;
        

        public Instructions(string name, SpriteFont Font, int X, int Y, GraphicsDeviceManager graphics,List<button>List_Instructions_Buttons)
        {
            this.name = name;
            this.Font = Font;
            this.X = X;
            this.Y = Y;
            this.graphics = graphics;
            this.List_Instructions_Buttons = List_Instructions_Buttons;

            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(100), (int)(100));
            Color[] data = new Color[(int)(100) * (int)(100)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
        }
        public List<button> Buttons
        {
            get
            {
                return List_Instructions_Buttons;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(100, 200), Color.White);
            spritebatch.DrawString(Font, this.name, new Vector2(this.X, this.Y), Color.Black);
            foreach(button BUT in Buttons)
            {
                BUT.draw(spritebatch);
            }
        }

        public void update()
        {

        }

        public string get_name()
        {
            class_name = this.name;
            return class_name;
        }
        public void action()
        {

        }
    }
}
