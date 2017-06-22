using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project_4_algemeen
{
    public class Instructies
    {
        GraphicsDeviceManager graphics;
        public button next, prev, exit, ret;
        public Instructies()
        {

        }
        public Instructies(int screen_width, int screen_height, SpriteFont font, float relativeSize, Action Exit, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;

            next = new button((int)(screen_width - (screen_width / 6)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "next", font, relativeSize, Color.White, Color.LightGray, () => hi5(), graphics);
            prev = new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "previous", font, relativeSize, Color.White, Color.LightGray, () => hi6(), graphics);
            exit = new button((int)(screen_width - (screen_width / 6)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "exit", font, relativeSize, Color.White, Color.LightGray, () => Exit(), graphics);
            ret = new button((int)(screen_width - (screen_width / 3)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "return", font, relativeSize, Color.White, Color.LightGray, () => hi7(), graphics);
        }

        public void update()
        {
            next.update();
            prev.update();
            exit.update();
            ret.update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            next.draw(spriteBatch);
            prev.draw(spriteBatch);
            exit.draw(spriteBatch);
            ret.draw(spriteBatch);
        }
        private void hi5()
        {
            next.visible = !(next.visible);
        }
        private void hi6()
        {
            prev.visible = !(prev.visible);
        }
        private void hi7()
        {
            ret.visible = !(ret.visible);
        }
    }
}
