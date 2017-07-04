using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.VisualBasic;
using project_4_algemeen;
using Microsoft.Xna.Framework.Content;

namespace project_4_algemeen
{
    class Play : gameElement
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
        List<Texture2D> All_images;        
        platform platform;
        Sound sound;
        gameElement Origin;
        
        public Play(double screen_width, double screen_height, float relativeSize, SpriteFont font, GraphicsDeviceManager graphics, game game1,List<Texture2D> All_images, platform platform, Sound sound, gameElement Origin)

        {
            this.graphics = graphics;
            this.Font = font;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.relativeSize = relativeSize;
            this.game1 = game1;
            this.All_images = All_images;
            this.platform = platform;
            this.sound = sound;
            this.Origin = Origin;



           
            Buttons.Add(new button((int)(screen_width * 0.4), (int)(this.screen_height*0.5), (int)this.screen_width / 8, (int)this.screen_height / 8, "Start!", this.Font, this.relativeSize, Color.White, Color.LightGray,  new Switch_level(this.All_images,this.game1,this.screen_width,this.screen_height, this.relativeSize, this.exit, this.platform,this.Font,this.graphics, this.sound, this.Origin), graphics));
            
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
