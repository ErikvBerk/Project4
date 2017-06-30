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
    class EndScreen : gameElement
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
        int Score;
        string currentscorestring;
        public bool levelcleared = false;

        public EndScreen(bool Playerdead, SpriteFont Font, double screen_width, double screen_height, GraphicsDeviceManager graphics, game game1, platform platform, int Score)
        {
            this.PlayerDead = Playerdead;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.graphics = graphics;
            this.game1 = game1;
            this.platform = platform;
            this.Score = Score;

            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Next Level!", Font, relativeSize, Color.Khaki, Color.OliveDrab,
               (game)=>LevelCleared(), graphics));
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
                return null;
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(this.Font, endscreen, new Vector2((int)screen_width/3, (int)screen_height / 10), Color.White);
            //spritebatch.DrawString(this.Font, currentscorestring, new Vector2((int)screen_width / 4, (int)screen_height / 12), Color.White);

            foreach (button BUT in buttons) { BUT.draw(spritebatch); }
        }

        public void update(game game1)
        {
            foreach(button BUT in buttons) { BUT.update(game1); }
            CurrentScoreString();
        }

        public void GameWon() //if player beats boss level
        {
            endscreen = "Congratulations, you beat the game!";
        }

        public void GameLose() //everytime player dies
        {
            endscreen = "Game Over!";
        }

        public bool LevelCleared()
        {
            levelcleared = true;
            
            return (levelcleared);
        }

        public void CurrentScoreString()
        {
            currentscorestring = String.Format("Current score: {0}", Score);
        }
    }
}
