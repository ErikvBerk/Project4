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
        

        public Back(string name)
        {
            this.name = name;
            Console.WriteLine("Back works constructor");

        }
        public void action()
        {
            
        }

        public void draw(SpriteBatch spritebatch)
        {
            
        }

        public string get_name()
        {
            return this.name;
        }

        public void update()
        {
            
        }
    }
}
