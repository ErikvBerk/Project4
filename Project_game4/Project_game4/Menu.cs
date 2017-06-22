using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


using Microsoft.VisualBasic;
using project_4_algemeen;

namespace Project_game4
{
    //public interface gameElement
    //{
    //    void update(Project_game4.Game1 game1);
    //    void draw(SpriteBatch spritebatch);
    //    List<button> buttons { get; }
    //}
    public class Menu 
    {
        GraphicsDeviceManager graphics;
        public List<button> list_buttons_menu;
        SpriteFont Font;
        double screen_height;
        double screen_width;
        

        public Menu()
        {

        }
        public Menu(GraphicsDeviceManager graphics, SpriteFont Font, double screen_height, double screen_width, float relativeSize,List<button> list_buttons_menu)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            //this.exit = exit;
            this.list_buttons_menu = list_buttons_menu;

            
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Highscores!", Font, relativeSize, Color.Khaki, Color.OliveDrab, graphics));
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.34), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, graphics));
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.42), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, graphics));
        }
        public void update()
        {
            foreach (button b in list_buttons_menu) 
            {
                b.update();
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            foreach (button b in list_buttons_menu)
            {
                b.draw(spritebatch);
            }
        }
        public List<button> buttons
        {
            get
            {
                return this.list_buttons_menu;
            }
        }     
    }
}
