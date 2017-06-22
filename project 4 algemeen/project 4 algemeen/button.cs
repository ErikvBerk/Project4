﻿using Microsoft.Xna.Framework;
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
    }
    public class button
    {
        public int X, Y, width, heigth;
        Texture2D texture;
        Color Color, hoverColor, CurrentColor;
        Action Action;
        public bool visible;
        SpriteFont Font;
        string Text;
        float TextSize;
        public button()
        {

        }
        public button(int x, int y, int width, int heigth, string text, SpriteFont font, float textsize, Color color, Color hovercolor, Action action, GraphicsDeviceManager graphics)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.heigth = heigth;
            this.Color = color;
            this.hoverColor = hovercolor;
            this.Action = action;
            this.CurrentColor = this.Color;
            this.Font = font;
            this.Text = text;
            this.TextSize = textsize;
            createTexture(graphics);
            visible = true;
        }
        public void createTexture(GraphicsDeviceManager graphics)
        {
            this.texture = new Texture2D(graphics.GraphicsDevice, this.width, this.heigth);
            Color[] data = new Color[this.width * this.heigth];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
        }
        public void onclick()
        {
            this.Action();
        }
        public void update()
        {
            var mousestate = Mouse.GetState();
            if (mousestate.X >= this.X && mousestate.X < this.X + this.width && mousestate.Y >= this.Y && mousestate.Y < this.Y + this.heigth)
            {
                this.CurrentColor = this.hoverColor;
                if (mousestate.LeftButton == ButtonState.Pressed)
                {
                    this.CurrentColor = this.hoverColor;
                    onclick();
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
                spritebatch.Draw(texture, new Vector2(this.X, this.Y), this.CurrentColor);
                spritebatch.DrawString(Font, Text, new Vector2(this.X, this.Y), Color.Black, 0.0f, new Vector2(0, 0), TextSize, new SpriteEffects(), 0.0f);
            }

        }
    }
}