using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace project_4_algemeen
{
    public class Switch_level : gameElement
    {
        List<Texture2D> All_images = new List<Texture2D>();
        List<button> Buttons = new List<button>();
        List<textbox> Textboxes = new List<textbox>();
        public List<projectile> projectiles = new List<projectile>();
        game game1;
        double screen_width, screen_height;
        bool level1Cleared, level2Cleared, level3Cleared, levelBossCleared, endscreenCleared, endscreen2Cleared, endscreen3Cleared, endscreen4Cleared;
        Player player1;
        public Level_1 level1;
        Level_2 level2;
        Level_3 level3;
        Level_Boss levelBoss;
        platform platform;
        SpriteFont Font;
        GraphicsDeviceManager graphics;
        int PlayerposX, PlayerposY;
        EndScreen endScreen, endScreen2, endScreen3, endScreen4;
        int Score;
        Sound sound;
        gameElement current;

        public Switch_level() { }
        public Switch_level(List<Texture2D> All_images,game game1,double screen_width,double screen_height,platform platform,SpriteFont font, GraphicsDeviceManager graphics, Sound sound)
        {
            this.All_images = All_images;
            this.game1 = game1;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.platform = platform;
            this.Font = font;
            this.graphics = graphics;
            this.PlayerposX = 0;
            this.PlayerposY = 0;
            this.sound = sound;
            
            switch (platform)
            {
                case platform.android:
                    player1 = new AndroidPlayer(All_images, game1, screen_width, screen_height, font, graphics, platform,1000,25, sound);
                    break;
                case platform.windows:
                    player1 = new Player(this.All_images, this.game1, this.screen_width, this.screen_height, platform,1000,50, sound);
                    break;
                default:
                    break;
            }

            endScreen = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, sound);
            endScreen2 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, sound);
            endScreen3 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, sound);
            endScreen4 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, sound);
            level1 = new Level_1("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles);
            level2 = new Level_2("Level 2", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles);
            level3 = new Level_3("Level 3", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles);
            levelBoss = new Level_Boss("Level Boss", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles);

            current = level1;

        }
        public List<button> buttons
        {
            get
            {
                return current.buttons;
            }
        }
        public List<textbox> textboxes
        {
            get
            {
                return current.textboxes;
            }
        }
        public void update(game game1)
        {
            current.update(game1);
            Score = player1.currentscore;
            if (current==level1 && level1.levelcleared==true) //checks if current is level 1 and if level 1 is cleared and then changes the current to the first 'endscreen'
            {
                    current = endScreen;
                    game1.resetButtons();
            }
            else if (current == endScreen && endScreen.levelcleared == true)
            {
                    current = level2;
                    game1.resetButtons();
            }
            else if (current == level2 && level2.levelcleared == true)
            {
                    current = endScreen2;
                    game1.resetButtons();
            }
            else if (current== endScreen2 && endScreen2.levelcleared == true)
            {
                    current = level3;
                    game1.resetButtons();
            }
            else if (current == level3&& level3.levelcleared == true)
            {
                    current = endScreen3;
                    game1.resetButtons();
            }
            else if (current == endScreen3 && endScreen3.levelcleared==true)
            {
                    current = levelBoss;
                    game1.resetButtons();
            }
            else if (current == levelBoss && levelBoss.levelcleared == true)
            {
                    current = endScreen4;
                    game1.resetButtons();
            }
            else if (current == endScreen4 && endScreen4.levelcleared == true)
            {
                    current = endScreen4;
                    game1.resetButtons();
            }
        }
        public void draw(SpriteBatch spritebatch)
        {
            current.draw(spritebatch);
        }

        

    }
}
