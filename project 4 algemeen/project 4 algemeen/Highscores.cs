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

namespace project_4_algemeen
{
    class Highscores : gameElement
    {
        public string name = "Highscores";
        string class_name;
        SpriteFont Font;
        Texture2D texture;
        double screen_width, screen_height;
        GraphicsDeviceManager graphics;
        List<button> list_highscore_buttons;
        float relativeSize;
        game game1;
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        Sound sound;
        
        public Highscores(double screen_width, double screen_height, float relativeSize, SpriteFont font, GraphicsDeviceManager graphics, game game1, gameElement origin, platform platform, Sound sound)
        {
            this.graphics = graphics;
            this.Font = font;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.relativeSize = relativeSize;
            this.game1 = game1;
            this.name = name;
            this.sound = sound;
        
            //not important creates a texture
            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(100), (int)(100));
            Color[] data = new Color[(int)(100) * (int)(100)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
            //
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

     

    public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.texture, new Vector2(100, 200), Color.White);
            spritebatch.DrawString(Font, this.name, new Vector2((int)this.screen_width/2, (int)this.screen_height/2), Color.Black);
            foreach (button But in Buttons)
            {
                But.draw(spritebatch);
            }


        }

        public void update()
        {

        }

        public string get_name()
        {
            class_name = this.name;
            return class_name;
        }
        public void action()
        {

        }

    public void update(game game1)
    {
        throw new NotImplementedException();
    }
}
}
