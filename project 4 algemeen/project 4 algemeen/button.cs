using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_4_algemeen;


namespace project_4_algemeen
{
    public class androidButtonAdapter
    {
        public button button;
        public androidButtonAdapter(button button)
        {
            this.button = button;
        }
        public virtual void update(TouchCollection currenttouch, game game1)
        {
            foreach (TouchLocation t in currenttouch)
            {
                if (t.Position.X >= this.button.X && t.Position.X < this.button.X + this.button.width && t.Position.Y >= this.button.Y && t.Position.Y < this.button.Y + this.button.heigth)
                {
                    if (t.State == TouchLocationState.Pressed)
                    {
                        button.onclick(game1);
                    }
                }
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            this.button.draw(spritebatch);
        }
    }
    public class moveButton : androidButtonAdapter
    {
        bool pressed;
        public moveButton(button button) : base(button)
        {
            pressed = false;
        }
        public override void update(TouchCollection currenttouch, game game1)
        {
            if (pressed)
            {
                button.onclick(game1);
                pressed = false;
            }
            foreach (TouchLocation t in currenttouch)
            {
                if (t.Position.X >= this.button.X && t.Position.X< this.button.X + this.button.width && t.Position.Y >= this.button.Y && t.Position.Y< this.button.Y + this.button.heigth)
                {
                    pressed = true;
                }
            }
        }
    }
    public class button
    {
        public int X, Y, width=100, heigth=100;
        Texture2D texture;
        Color Color, hoverColor, CurrentColor;
        public Action<game> action;
        public bool visible;
        String Text;
        SpriteFont Font;
        public gameElement Current_class;
        GraphicsDeviceManager graphics;
        float transparancy;
        

        public button(int x, int y, int width, int heigth, String text, SpriteFont font, float textsize, Color color, Color hovercolor, gameElement current_class, GraphicsDeviceManager graphics, float transparancy = 1)
        {
            createTexture(graphics);
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.Current_class = current_class;
            this.CurrentColor = this.Color;
            visible = true;
            this.Text = text;
            this.Font = font;
            this.graphics = graphics;
            this.transparancy = transparancy;
            

            createTexture(graphics);
        }
        public button(int x, int y, int width, int heigth, String text, SpriteFont font, float textsize, Color color, Color hovercolor, Action<game> action, GraphicsDeviceManager graphics, float transparancy = 1)
        {
            
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.CurrentColor = this.Color;
            visible = true;
            this.Text = text;
            this.Font = font;
            this.action = action;
            this.graphics = graphics;
            this.transparancy = transparancy;

            createTexture(graphics);

        }

        public button(Texture2D buttonbackground, int x, int y, int width, int heigth, String text, SpriteFont font, float textsize, Color color, Color hovercolor, gameElement current_class, GraphicsDeviceManager graphics, float transparancy = 1)
        {
            
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.Current_class = current_class;
            this.CurrentColor = this.Color;
            visible = true;
            this.Text = text;
            this.Font = font;
            this.graphics = graphics;
            this.transparancy = transparancy;
            this.texture = buttonbackground;

            

            
        }
        public button(Texture2D buttonbackground, int x, int y, int width, int heigth, String text, SpriteFont font, float textsize, Color color, Color hovercolor, Action<game> action, GraphicsDeviceManager graphics, float transparancy = 1)
        {
            
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.CurrentColor = this.Color;
            visible = true;
            this.Text = text;
            this.Font = font;
            this.action = action;
            this.graphics = graphics;
            this.transparancy = transparancy;
            this.texture = buttonbackground;

            
        }

        public void createTexture(GraphicsDeviceManager graphics)
        {
            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(this.width), (int)(this.heigth));
            Color[] data = new Color[(int)(this.width) * (int)(this.heigth)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
        }
        public void onclick(game game1)
        {
            if (Current_class != null)
            {
                game1.current = Current_class;
            }
            else
            {
                action(game1);
            }
        }
        public void update(game game1)
        {
            var mousestate = Mouse.GetState();
            
            if (mousestate.X >= this.X && mousestate.X < (this.X + this.width) && mousestate.Y >= this.Y && mousestate.Y < (this.Y + this.heigth))
            {
                this.CurrentColor = hoverColor;
                if (mousestate.LeftButton == ButtonState.Pressed)
                {
                    
                    onclick(game1);
                    this.CurrentColor = this.hoverColor;
                }
            }
            else
            {
                this.CurrentColor = this.Color;
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
           if (visible)
            {
                //spritebatch.Draw(texture, new Vector2(this.X, this.Y), this.CurrentColor * this.transparancy);
                //spritebatch.DrawString(Font, Text, new Vector2(this.X, this.Y), Color.Black);
                Rectangle destinationRectangle = new Rectangle(this.X, this.Y, (int)this.width, (int)this.heigth);
                //Console.WriteLine(texture.Bounds);
                spritebatch.Draw(texture, destinationRectangle, Color.White);
            }
        }
    }
}
