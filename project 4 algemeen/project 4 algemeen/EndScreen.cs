﻿using System;
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
    class EndScreen : gameElement  // used for all our switching screens , and win and loss screens , shows your current points and contains a button to continue to the next level or back to menu
    {
        bool PlayerDead = false;
        string endscreen = "Switching levels";
        SpriteFont Font;
        double screen_width;
        double screen_height;
        int relativeSize;
        GraphicsDeviceManager graphics;
        game game1;
        platform platform;
        public List<button> Buttons = new List<button>();
        public List<textbox> Textboxes = new List<textbox>();
        int Score;
        string currentscorestring = " ";
        public bool levelcleared = false;
        Sound sound;
        bool isplayedvictory = false;
        bool isplayedlose = false;
        string namebutton;
        Texture2D background, buttontexture;

        public EndScreen(bool Playerdead, SpriteFont Font, double screen_width, double screen_height, GraphicsDeviceManager graphics, game game1, platform platform, int Score, Sound sound, string namebutton, Texture2D background,Texture2D buttontexture)
        {
            this.PlayerDead = Playerdead;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.graphics = graphics;
            this.game1 = game1;
            this.platform = platform;
            this.Score = Score;
            this.sound = sound;
            this.namebutton = namebutton;
            this.background = background;
            this.buttontexture = buttontexture;

            Buttons.Add(new button(buttontexture,(int)(screen_width * 0.7), (int)(this.screen_height * 0.7), (int)(screen_width * 0.4), (int)(screen_width * 0.1), namebutton, Font, relativeSize, Color.Khaki, Color.OliveDrab,
               (game)=>LevelCleared(), graphics));
        }



        public void updateScreenSize(int width, int height) // updates the sizes when the screen size is altered (full screen)
        {
            this.screen_width = width;
            this.screen_height = height;
            Buttons[0].X = (int)(width * 0.6);
            Buttons[0].Y = (int)(height * 0.8);
            Buttons[0].width = (int)(width * 0.4);
            Buttons[0].heigth = (int)(width * 0.1);
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
                return this.Textboxes;
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            Rectangle destinationRectangle = new Rectangle(0, 0, (int)screen_width, (int)screen_height);

            spritebatch.DrawString(this.Font, endscreen, new Vector2((int)(screen_width * 0.4), (int)(screen_height * 0.2)), Color.White);
            spritebatch.DrawString(this.Font, currentscorestring, new Vector2((int)(screen_width * 0.4), (int)(screen_height * 0.3)), Color.White);
            spritebatch.Draw(background, destinationRectangle, Color.White);

            foreach (button BUT in buttons) { BUT.draw(spritebatch); }
        }
        public void UpdateScore(int score) //updates score in the endscreen
        {
            this.Score = score;
        }

        public void update(game game1)
        {
            foreach(button BUT in buttons) { BUT.update(game1); }
            CurrentScoreString();
           
        }

        public void GameWon() //if player beats boss level
        {
            endscreen = "Congratulations, you beat the game! Yes, Yes indeed. That was a zombie unicorn you just killed";
            if (isplayedvictory == false)
            {
                // throw new Exception();
                sound.VictorySound();
                isplayedvictory = true;
            }


        }

        public void GameLose() //everytime player dies
        {
            endscreen = "Game Over!";
            if (isplayedlose == false)
            {
                sound.GameOverSound();
                isplayedlose = true;
            }
        }

        public void LevelCleared() // decides if the endscreen is "cleared"  so it switches to the next screen in switch_levels
        {
            levelcleared = true;
        }

        public void CurrentScoreString() // draws the score on the endscreen
        {
            currentscorestring = String.Format("Current score: {0}", Score);
        }
    }
}
