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
    class Play : I_Button_classes
    {
        public string name="Play";
        string class_name;
        SpriteFont Font, Big_Font;
        Texture2D texture;
        int X;
        int Y;
        GraphicsDeviceManager graphics;
        int currentscore;
        string currentscorestring = "";
        List<button> List_Play_Buttons;

        

        public Play(string name,SpriteFont Font, SpriteFont Big_Font,int X , int Y ,GraphicsDeviceManager graphics,List<button> List_Play_Buttons)
        {
            this.name = name;
            this.Font = Font;
            this.Big_Font = Big_Font;
            this.X = X;
            this.Y = Y;
            this.graphics = graphics;
            this.currentscore = 0;
            this.List_Play_Buttons = List_Play_Buttons;
            

            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(100), (int)(100));
            Color[] data = new Color[(int)(100) * (int)(100)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
            

            CurrentScore();
            CurrentScoreString();
        }
        public List<button> Buttons
        {
            get
            {
                return this.List_Play_Buttons;
            }

            set
            {
                throw new NotImplementedException();
            }
        }



        public void draw(SpriteBatch spritebatch)
        {                    
            spritebatch.Draw(texture, new Vector2(100, 200), Color.White);
            spritebatch.DrawString(Big_Font, this.name, new Vector2(this.X, this.Y), Color.Black);
            spritebatch.DrawString(Font, currentscorestring, new Vector2(1700, 15), Color.White);

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

        public int CurrentScore()
        {            
            currentscore = 0;
            //code to calculate the score comes here.
            return currentscore;            
        }

        public void CurrentScoreString()
        {           
           currentscorestring = String.Format("Current score: {0}", currentscore);           
        }
            

    } 
}
