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
        void resetButtons();
    }
    public interface gameElement
    {
        void update(game game1);
        void draw(SpriteBatch spritebatch);
        void updateScreenSize(int width, int height);
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
        Sound sound;

        public Menu()
        {

        }
        public Menu(GraphicsDeviceManager graphics, SpriteFont Font, double screen_height, double screen_width, float relativeSize, Action<game> exit, game game1, List<Texture2D> All_images, Sound sound, platform platform = platform.windows)
        {
            this.graphics = graphics;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.relativeSize = relativeSize;
            this.exit = exit;
            this.All_images = All_images;
            this.platform = platform;
            this.sound = sound;
            this.sound.background_music();

            Buttons.Add(new button(All_images[17], (int)(this.screen_width * 0.4), (int)(this.screen_height * 0.33), (int)(screen_width * 0.2), (int)(screen_height * 0.1), "Play!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Play(screen_width, screen_height, relativeSize, Font, graphics, game1, All_images, platform, sound, this), graphics));
            Buttons.Add(new button(All_images[18], (int)(this.screen_width * 0.4), (int)(this.screen_height * 0.48), (int)(screen_width * 0.2), (int)(screen_height * 0.1), "Instructions!", Font, relativeSize, Color.Khaki, Color.OliveDrab, new Instructions(screen_width, screen_height, relativeSize, Font, graphics, game1, sound, exit, All_images, platform, this), graphics));
            Buttons.Add(new button(All_images[19], (int)(this.screen_width * 0.4), (int)(this.screen_height * 0.63), (int)(screen_width * 0.2), (int)(screen_height * 0.1), "Exit!", Font, relativeSize, Color.Maroon, Color.Red, exit, graphics));
            
        }
        public void updateScreenSize(int width, int height)
        {
            //this.screen_width = 1000;
            //this.screen_height = 1000;
            //Buttons[0].X = (int)(screen_width * 0.4);
            //Buttons[0].Y = (int)(screen_height * 0.18);
            //Buttons[0].width = (int)(screen_width * 0.2);
            //Buttons[0].heigth = (int)(screen_height * 0.1);
            //// Buttons[0].createTexture(graphics);

            //Buttons[1].X = (int)(screen_width * 0.4);
            //Buttons[1].Y = (int)(this.screen_height * 0.33);
            //Buttons[1].width = (int)(screen_width * 0.2);
            //Buttons[1].heigth = (int)(screen_height * 0.1);
            ////  Buttons[1].createTexture(graphics);

            //Buttons[2].X = (int)(screen_width * 0.4);
            //Buttons[2].Y = (int)(this.screen_height * 0.48);
            //Buttons[2].width = (int)(screen_width * 0.2);
            //Buttons[2].heigth = (int)(screen_height * 0.1);
            //// Buttons[2].createTexture(graphics);

            /*Buttons[3].X = (int)(screen_width * 0.4);
            Buttons[3].Y = (int)(this.screen_height * 0.63);
            Buttons[3].width = (int)(screen_width * 0.2);
            Buttons[3].heigth = (int)(screen_height * 0.1);
            Buttons[3].createTexture(graphics);*/
        }
        public void update(game game1)
        {
            foreach(button b in Buttons)
            {
                b.update(game1);
            }
            //foreach (textbox t in Textboxes)
            //{
            //    t.update();
            //}
        }
        public void draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle(0, 0, (int)screen_width, (int)screen_height);
            spritebatch.Draw(All_images[13], destinationRectangle, Color.White);

            foreach (button b in Buttons)
            {
                b.draw(spritebatch);
            }
            //foreach(textbox t in Textboxes)
            //{
            //    t.draw(spritebatch);
            //}          

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
       
    }
}
