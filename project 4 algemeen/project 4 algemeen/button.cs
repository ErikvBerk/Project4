using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4_algemeen
{
    public class androidButtonAdapter
    {
        button button;
        public androidButtonAdapter(button button)
        {
            this.button = button;
        }
        public void update(TouchCollection currenttouch)
        {
            foreach (TouchLocation t in currenttouch)
            {
                if (t.Position.X >= this.button.X && t.Position.X < this.button.X + this.button.width && t.Position.Y >= this.button.Y && t.Position.Y < this.button.Y + this.button.heigth)
                {
                    if (t.State == TouchLocationState.Pressed)
                    {
                        button.onclick();
                    }
                }
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            this.button.draw(spritebatch);
        }
    }
    public class button
    {
        public int X, Y, width, heigth;
        public bool visible;
        Texture2D texture;
        Color Color;
        public button(int x, int y, int width, int heigth, Texture2D texture)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            visible = true;
            this.texture = texture;
            this.Color = Color.White;
        }
        public void onclick()
        {
            if (this.visible)
                this.visible = false;
            else
                this.visible = true;
        }
        public void update()
        {
            var mousestate = Mouse.GetState();
            if (mousestate.X >= this.X && mousestate.X < this.X + this.width && mousestate.Y >= this.Y && mousestate.Y < this.Y + this.heigth)
            {
                this.Color = Color.LightGray;
                if (mousestate.LeftButton == ButtonState.Pressed)
                {
                    onclick();
                }
            }
            else
            {
                this.Color = Color.White;
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            if (this.visible)
            {
                spritebatch.Draw(texture, new Vector2(this.X, this.Y), this.Color);
            }
        }
    }
}
