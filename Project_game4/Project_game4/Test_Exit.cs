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
    class Test_Exit : I_Button_classes
    {
        public string name;
        string class_name;
        SpriteFont Font;
        Texture2D texture;
        int X;
        int Y;
        GraphicsDeviceManager graphics;
        public Action Exit;

        public List<button> Buttons
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Test_Exit(Action exit, string name, SpriteFont Font, int X, int Y, GraphicsDeviceManager graphics)
        {
            this.Exit = exit;
            this.name = name;
            this.Font = Font;
            this.X = X;
            this.Y = Y;
            this.graphics = graphics;
            
        }

        public void draw(SpriteBatch spritebatch)
        {
            
            
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
            this.Exit();
        }
        
    }
}
