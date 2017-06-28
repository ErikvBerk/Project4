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
        bool LevelCleared = true;
        string endscreen = "";
        SpriteFont Font;
        double screen_width;
        double screen_height;
        int relativeSize;
        GraphicsDeviceManager graphics;
        game game1;
        platform platform;
        public List<button> Buttons = new List<button>();

        public EndScreen(bool Playerdead, bool Levelcleared, SpriteFont Font, double screen_width, double screen_height, GraphicsDeviceManager graphics, game game1, platform platform)
        {
            this.PlayerDead = Playerdead;
            this.LevelCleared = Levelcleared;
            this.Font = Font;
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.graphics = graphics;
            this.game1 = game1;
            this.platform = platform;

            Buttons.Add(new button((int)(screen_width * 0.8), (int)(this.screen_height * 0.26), (int)(screen_width * 0.4), (int)(screen_width * 0.1), "Highscores!", Font, relativeSize, Color.Khaki, Color.OliveDrab,
                new Highscores(screen_width, screen_height, relativeSize, Font, graphics, game1, this, platform), graphics));
        }

        
        

        public List<textbox> textboxes => throw new NotImplementedException();

        public List<button> buttons => throw new NotImplementedException();

        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(this.Font, endscreen, new Vector2((int)screen_width/3, (int)screen_height / 10), Color.White);

            foreach(button BUT in buttons) { BUT.draw(spritebatch); }
        }

        public void update(game game1)
        {
            foreach(button BUT in buttons) { BUT.update(game1); }
        }

        public void GameWon() //if player beats boss level
        {
            endscreen = "Congratulations, you beat the game!";
        }

        public void GameLose() //everytime player dies
        {
            endscreen = "Game Over!";
        }
    }
}
