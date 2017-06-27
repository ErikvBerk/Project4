using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project_4_algemeen
{
    public class Instructies : gameElement
    {
        GraphicsDeviceManager graphics;
        gameElement origin;
        SpriteFont font;
        double screen_width, screen_height;
        float relativeSize;
        Action<game> exit;
        public List<button> Buttons = new List<button>();
        public List<textbox> Textboxes = new List<textbox>();
        List<Texture2D> All_images = new List<Texture2D>();
        public Instructies()
        {

        }
        public Instructies(double screen_width, double screen_height, SpriteFont font, float relativeSize, Action<game> Exit, GraphicsDeviceManager graphics, gameElement origin)
        {
            this.graphics = graphics;
            this.origin = origin;
            this.font = font;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.relativeSize = relativeSize;
            this.exit = Exit;

            Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "next", font, relativeSize, Color.White, Color.LightGray, new Menu(), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "previous", font, relativeSize, Color.White, Color.LightGray, new Menu(), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "exit", font, relativeSize, Color.White, Color.LightGray, (game1) => Exit(game1), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "back", font, relativeSize, Color.White, Color.LightGray, origin, graphics));
        }

        public void update(game game1)
        {
            foreach (button b in Buttons)
            {
                b.update(game1);
            }
            foreach(textbox t in textboxes)
            {
                t.update();
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
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
    }
}
