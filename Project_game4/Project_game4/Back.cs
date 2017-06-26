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
        public string name="";
        string class_name;

        public Back(string name)
        {
           this.name = name;
            

            Console.WriteLine("Back constructor works");
        }

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

        public void action()
        {
            
        }

        public void draw(SpriteBatch spritebatch)
        {
            
        }

        public string get_name()
        {
            class_name = this.name;
            return class_name;
            
        }

        public void update()
        {
            
        }
    }
}
