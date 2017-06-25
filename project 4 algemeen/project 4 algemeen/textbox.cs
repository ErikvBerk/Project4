using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Android.Views;
using Android.Views.InputMethods;
using Android.App;
using System.Runtime.Remoting.Contexts;
using Android;
using Android.Widget;
using System.Runtime.CompilerServices;
using Android.InputMethodServices;
using Org.XmlPull.V1;
using Android.Util;
using inputFields;

namespace project_4_algemeen
{
    public class androidTextBoxAdapter : Activity
    {
        public textbox textbox;
        public androidTextBoxAdapter(textbox textbox)
        {
            this.textbox = textbox;
        }    
        public void update(TouchCollection currentTouch)
        {
            foreach (TouchLocation t in currentTouch)
            {
                if (t.Position.X >= this.textbox.x && t.Position.X < this.textbox.x + this.textbox.width && t.Position.Y >= this.textbox.y && t.Position.Y < this.textbox.y + this.textbox.heigth)
                {
                    if (t.State == TouchLocationState.Pressed)
                    {
                        textbox.pressed = true;
                    }
                }
                if (textbox.pressed)
                {
                    textbox.pressed = false;
                    textbox.beenPressed = true;
                }
                else if (textbox.beenPressed)
                {
                    textbox.beenPressed = false;
                    textbox.hasBeenPressed = !(textbox.hasBeenPressed);
                    var textField = new TextField();
                    textField.ShowDialog();
                }
                if (textbox.hasBeenPressed)
                {

                }
            }
        }
    }
    public class textbox
    {
        string currentText = "hi";
        Texture2D texture;
        public int x, y, width, heigth;
        SpriteFont font;
        public bool pressed, beenPressed, hasBeenPressed;
        bool keyPress, keyPressed;
        Keys lastPressed;
        public textbox()
        {

        }
        public textbox(int x, int y, int width, int heigth, SpriteFont font, GraphicsDeviceManager graphics)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.heigth = heigth;
            this.font = font;
            createTexture(graphics);
        }
        public void createTexture(GraphicsDeviceManager graphics)
        {
            this.texture = new Texture2D(graphics.GraphicsDevice, (int)(this.width), (int)(this.heigth));
            Color[] data = new Color[(int)(this.width) * (int)(this.heigth)];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            this.texture.SetData(data);
        }
        public void inputText()
        {
            var keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            var pressedKeys = keyboard.GetPressedKeys();
            Keys k = Keys.Escape;
            if (pressedKeys.Length > 0)
            {
                k = pressedKeys[0];
                keyPress = true;
            }
            if (keyPress)
            {
                keyPress = false;
                keyPressed = true;
                lastPressed = k;
            }
            else if (keyPressed)
            {
                keyPressed = false;
                if (lastPressed != Keys.Escape)
                {
                    if (lastPressed == Keys.Back)
                    {
                        string newText = "";
                        int length = currentText.Length;
                        int i = 0;
                        foreach (char c in currentText)
                        {
                            if (i < length - 1)
                            {
                                newText += c;
                                i++;
                            }
                            else
                            {
                                currentText = newText;
                            }
                        }
                    }
                    else
                    {
                        currentText += lastPressed.ToString();
                    }
                }
            }
        }
        public void update()
        {
            var mousestate = Mouse.GetState();

            if (mousestate.X >= this.x && mousestate.X < (this.x + this.width) && mousestate.Y >= this.y && mousestate.Y < (this.y + this.heigth))
            {
                if (mousestate.LeftButton == ButtonState.Pressed)
                {
                    pressed = true;
                }
            }
            if (pressed)
            {
                pressed = false;
                beenPressed = true;
            }
            else if (beenPressed)
            {
                beenPressed = false;
                hasBeenPressed = !(hasBeenPressed);
            }
            if (hasBeenPressed)
            {
                inputText();
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Vector2(x, y), Color.White);
            if (hasBeenPressed)
            {
                spritebatch.DrawString(font, currentText, new Vector2(x, y), Color.Black);
            }
        }
    }
}
