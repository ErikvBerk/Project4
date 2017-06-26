using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project_4_algemeen
{
    public interface game
    {
        gameElement current { get; set; }
        
    }
    public interface gameElement
    {
        void update(game game1);
        void draw(SpriteBatch spritebatch);
        //List<button> buttons { get; }
        List<textbox> textboxes { get; }
        
    }
    public class Menu : gameElement
    {
        public GraphicsDeviceManager graphics;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        public SpriteFont Font;
        public double screen_height, screen_width;
        public float relativeSize;
        public Action<game> exit;
        public game game1;
        
        
        public Menu(double screen_width, double screen_height, float relativeSize, SpriteFont Font, GraphicsDeviceManager graphics,game game1)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.relativeSize = relativeSize;            
            this.game1 = game1;

            this.Textboxes.Add(new textbox(10, 10, 500, 200, this.Font, graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.18), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Play("Play",this.screen_width,this.screen_height,this.relativeSize,this.Font,this.graphics,this.game1), this.graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Highscores!_instructions", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Instructions("Instructions",this.screen_width,this.screen_height,this.relativeSize,this.Font,this.graphics,this.game1),this.graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.34), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Instructions("Instructions", this.screen_width, this.screen_height, this.relativeSize, this.Font, this.graphics, this.game1), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.42), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, new Instructions("Instructions", this.screen_width, this.screen_height, this.relativeSize, this.Font, this.graphics, this.game1), graphics));
        }
        public void update(game game1)
        {
            foreach(button b in Buttons)
            {
                b.update(game1);
            }
            foreach (textbox t in Textboxes)
            {
                t.update();
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            foreach(button b in Buttons)
            {
                b.draw(spritebatch);
            }
            foreach (textbox t in Textboxes)
            {
                t.draw(spritebatch);
            }
        }
       
        public List<textbox> textboxes
        {
            get
            {
                return Textboxes;
            }
        }

        //List<button> gameElement.buttons
        //{
        //    get
        //    {
        //        return Buttons;
        //    }
        //}
    }
}
