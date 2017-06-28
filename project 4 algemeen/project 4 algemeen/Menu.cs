using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_4_android;

namespace project_4_algemeen
{
    public enum platform
    {
        android,
        windows
    }
    public interface game
    {
        gameElement current { get; set; }
    }
    public interface gameElement
    {
        void update(game game1);
        void draw(SpriteBatch spritebatch);
        List<button> buttons { get; }
        List<textbox> textboxes { get; }
    }
    public class Menu : gameElement
    {
        GraphicsDeviceManager graphics;
        public List<button> Buttons = new List<button>();
        public List<textbox> Textboxes = new List<textbox>();
        List<Texture2D> All_images;
        SpriteFont Font;
        double screen_height;
        double screen_width;
        float relativeSize;
        Action<game> exit;
        platform platform;

        public Menu()
        {

        }
        public Menu(GraphicsDeviceManager graphics, SpriteFont Font, double screen_height, double screen_width, float relativeSize, Action<game> exit, game game1, List<Texture2D> All_images, platform platform = platform.windows)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.relativeSize = relativeSize;
            this.exit = exit;
            this.All_images = All_images;
            this.platform = platform;

            this.Textboxes.Add(new textbox(10, 10, 500, 200, Font, graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.18), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Play(screen_width, screen_height, relativeSize, Font, graphics, game1, All_images,platform), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Highscores!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Highscores(screen_width, screen_height, relativeSize, Font, graphics, game1,this,platform), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.34), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Instructies(screen_width, screen_height, Font, relativeSize, exit, graphics, this,platform), graphics));
            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.42), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, exit, graphics));
            //Buttons.Add(new button(500, 500, (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Endscreen_Test!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new EndScreen(true, false, Font, screen_width, screen_height, graphics, game1, platform), graphics));
        }
        public Menu(GraphicsDeviceManager graphics, SpriteFont Font, double screen_height, double screen_width, float relativeSize, Action<game> exit, List<button> list_buttons_menu, game game1)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.relativeSize = relativeSize;
            this.exit = exit;
            this.Textboxes.Add(new textbox(10, 10, 500, 200, Font, graphics));
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.18), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, (game1) => (game1), graphics));
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Highscores!", Font, relativeSize, Color.Khaki, Color.OliveDrab, (game1) => (game1), graphics));
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.34), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, (game1) => toInstructions(game1), graphics));
            //Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.42), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, (game1) => exit(game1), graphics));
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
            foreach(textbox t in Textboxes)
            {
                t.draw(spritebatch);
            }
        }
        public List<button> buttons
        {
            get
            {
                return this.Buttons;
            }
        }
        public List<textbox> textboxes
        {
            get
            {
                return Textboxes;
            }
        }
        private void toInstructions(game game1)
        {
            game1.current = new Instructies(screen_width, screen_height, Font, relativeSize, exit, graphics, this, platform);
        }
    }
}
