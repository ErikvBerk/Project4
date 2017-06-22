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
        public List<button> Buttons = new List<button>();
        public Instructies()
        {

        }
        public Instructies(double screen_width, double screen_height, SpriteFont font, float relativeSize, Action<Game1> Exit, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;

            Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "next", font, relativeSize, Color.White, Color.LightGray, (game1) => hi5(game1), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "previous", font, relativeSize, Color.White, Color.LightGray, (game1) => hi6(game1), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "exit", font, relativeSize, Color.White, Color.LightGray, (game1) => Exit(game1), graphics));
            Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "return", font, relativeSize, Color.White, Color.LightGray, (game1) => hi7(game1), graphics));
        }

        public void update(Game1 game1)
        {
            foreach (button b in Buttons)
            {
                b.update(game1);
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            foreach (button b in Buttons)
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
        private void hi5(Game game1)
        {

        }
        private void hi6(Game game1)
        {

        }
        private void hi7(Game game1)
        {

        }
    }
}
