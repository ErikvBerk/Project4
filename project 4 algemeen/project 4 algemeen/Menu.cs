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
    public interface gameElement
    {
        void update(Game1 game1);
        void draw(SpriteBatch spritebatch);
        List<button> buttons { get; }
    }
    public class Menu : gameElement
    {
        GraphicsDeviceManager graphics;
        public List<button> Buttons = new List<button>();
        SpriteFont Font;
        double screen_height;
        double screen_width;
        Action<Game1> exit;
        
        public Menu()
        {

        }
        public Menu(GraphicsDeviceManager graphics, SpriteFont Font, double screen_height, double screen_width, float relativeSize, Action<Game1> exit)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.exit = exit;
            
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.18), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, (game1) => Hi1(game1), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Highscores!", Font, relativeSize, Color.Khaki, Color.OliveDrab, (game1) => Hi2(game1), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.34), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, (game1) => toInstructions(game1), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.42), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, (game1) => exit(game1), graphics));
        }
        public void update(Game1 game1)
        {
            foreach(button b in Buttons)
            {
                b.update(game1);
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            foreach(button b in Buttons)
            {
                b.draw(spritebatch);
            }
        }
        public List<button> buttons
        {
            get
            {
                return this.Buttons;
            }
        }
        private void toInstructions(Game1 game1)
        {
            game1.Current = new Instructies(screen_width, screen_height, Font, game1.relativeSize, exit, graphics);
        }
        public void Hi1(Game game1)
        {
            
        }
        public void Hi2(Game game1)
        {
            
        }
        public void Hi3(Game game1)
        {
            
        }
    }
}
