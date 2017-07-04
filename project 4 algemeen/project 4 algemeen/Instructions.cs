using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using project_4_algemeen;

namespace project_4_algemeen
{
    public class Instructions : gameElement
    {
        GraphicsDeviceManager graphics;
        
        SpriteFont Font;
        double screen_width, screen_height;
        float relativeSize;
        Action<game> exit;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        game game1;
        Sound sound;
        List<Texture2D> All_images = new List<Texture2D>();
        Texture2D Texture;
        platform platform;

        public Instructions(double screen_width, double screen_height, float relativeSize, SpriteFont font, GraphicsDeviceManager graphics, game game1, Sound sound, Action<game> Exit, List<Texture2D> All_images, platform platform, gameElement origin)
        {
            this.graphics = graphics;
            this.Font = font;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.relativeSize = relativeSize;
            this.game1 = game1;
            this.sound = sound;
            this.All_images = All_images;
            this.Texture = this.All_images[7];
            this.platform = platform;

            Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "next", font, relativeSize, Color.White, Color.LightGray, (game)=>Next(game), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "previous", font, relativeSize, Color.White, Color.LightGray, (game) => Previous(game), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "exit", font, relativeSize, Color.White, Color.LightGray, Exit, graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "back", font, relativeSize, Color.White, Color.LightGray, origin, graphics));
            Buttons[1].visible = false;
        }

        public void update(game game1)
        {
            foreach (button b in Buttons)
            {
                b.update(game1);
            }
            foreach (textbox t in textboxes)
            {
                t.update();
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            Rectangle rectangle;
            if (platform == platform.android)
            {
                rectangle = new Rectangle((int)(screen_width / 24), (int)((screen_height / 4) - (Texture.Height / 4)), Texture.Width * 2, Texture.Height * 2);
            }
            else
            {
                rectangle = new Rectangle((int)(screen_width / 6), (int)((screen_height / 2) - (Texture.Height / 2)), Texture.Width, Texture.Height);
            }
            spritebatch.Draw(Texture, rectangle, Color.White);
            foreach (button b in Buttons)
            {
                b.draw(spritebatch);
            }
            foreach (textbox t in textboxes)
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
        private void Next(game game1)
        {
            Texture = All_images[8];
            buttons[0].visible = false;
            buttons[1].visible = true;
        }
        private void Previous(game game1)
        {
            Texture = All_images[7];
            buttons[0].visible = true;
            buttons[1].visible = false;
        
        }

       
    }
}
