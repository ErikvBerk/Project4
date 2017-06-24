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
    public interface I_Button_classes   //interface for all gameElement classes to instantiate in the button class.
    {

        void draw(SpriteBatch spritebatch);
        void update();
        string get_name();
        void action();
        List<button> Buttons{get; set; }
    }
}
