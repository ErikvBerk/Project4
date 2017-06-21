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
        Texture2D texture;
        Color Color, hoverColor, CurrentColor;
        Action Action;
        public bool visible;
        public button(int x, int y, int width, int heigth, Color color, Color hovercolor, Action action)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.Action = action;
            this.CurrentColor = this.Color;
            visible = true;
        }
        public void createTexture(GraphicsDeviceManager graphics)
        {
            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(this.width / 2), (int)(this.heigth / 2));
            Color[] data = new Color[(int)(this.width / 2) * (int)(this.heigth / 2)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
        }
        public void onclick()
        {
            this.Action(visible);
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
            if(visible)
                spritebatch.Draw(texture, new Vector2(this.X, this.Y), this.CurrentColor);
        }
    }
}
