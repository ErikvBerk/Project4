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
        string name;
        Sound sound;


        public Instructions(string name,double screen_width, double screen_height, float relativeSize, SpriteFont font, GraphicsDeviceManager graphics, game game1, Sound sound)
        {
            this.graphics = graphics;
            this.Font = font;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.relativeSize = relativeSize;
            this.game1 = game1;
            this.name = name;
            this.sound = sound;
            
            //Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "next", font, relativeSize, Color.White, Color.LightGray,new Play("Play",this.screen_width,this.screen_height,this.relativeSize,this.Font,this.graphics,this.game1), graphics));
            //Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height - screen_height / 6), (int)screen_width / 8, (int)screen_height / 8, "previous", font, relativeSize, Color.White, Color.LightGray, (game1) => hi6(game1), graphics));
            //Buttons.Add(new button((int)(screen_width - (screen_width / 6)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "exit", font, relativeSize, Color.White, Color.LightGray, (game1) => Exit(game1), graphics));
            //Buttons.Add(new button((int)(screen_width - (screen_width / 3)), (int)(screen_height / 20), (int)screen_width / 8, (int)screen_height / 8, "back", font, relativeSize, Color.White, Color.LightGray, new Menu(this.screen_width,this.screen_height,this.relativeSize,this.Font,this.graphics,this.game1),graphics));
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
