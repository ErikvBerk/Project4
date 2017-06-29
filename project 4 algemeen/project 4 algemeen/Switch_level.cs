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
        bool level1Started, level2Started, level3Started, levelBossStarted;
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
        public Switch_level() { }

        public Switch_level(List<Texture2D> All_images,game game1,double screen_width,double screen_height,platform platform,SpriteFont font, GraphicsDeviceManager graphics)
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
            endScreen = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score);
            endScreen2 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score);
            endScreen3 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score);
            endScreen4 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score);


            switch (platform)
            {
                case platform.android:
                    player1 = new AndroidPlayer(All_images, game1, screen_width, screen_height, font, graphics, platform);
                    break;
                case platform.windows:
                    player1 = new Player(this.All_images, this.game1, this.screen_width, this.screen_height, platform);
                    break;
                default:
                    break;
            }

            level1 = new Level_1("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1, projectiles);
            level2 = new Level_2("Level 2", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1, projectiles);
            level3 = new Level_3("Level 3", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1, projectiles);
            //levelBoss = new Level_Boss("Level Boss", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform,this.Font, this.graphics, this.player1, projectiles);


            //public Level_Boss(string name, double screen_width, double screen_height, List<Texture2D> All_images,game game1, platform platform, SpriteFont font, GraphicsDeviceManager graphics)


        }



        public List<button> buttons
        {
            get
            {
                if (level1.LevelCleared() == false)
                {
                    return level1.buttons;
                }
                else if (level2.LevelCleared() == false)
                {
                    return level2.buttons;
                }
                else if (level3.LevelCleared() == false)
                {
                    return level3.buttons;
                }
                else
                {
                    return levelBoss.buttons;
                }
            }
        }

        public List<textbox> textboxes
        {
            get
            {
                if (level1.LevelCleared() == false)
                {
                    return level1.textboxes;
                }
                else if (level2.LevelCleared() == false)
                {
                    return level2.textboxes;
                }
                else if (level3.LevelCleared() == false)
                {
                    return level3.textboxes;
                }
                else
                {
                return levelBoss.textboxes;
                }
            }
        }
        public int GetPlayerposX()
        {
            return PlayerposX;
        }
        public int GetPlayerposY()
        {
            return PlayerposY;
        }

        public void update(game game1)
        {
            projectiles = player1.projectiles;
            this.PlayerposX = player1.GetPositionX();
            this.PlayerposY = player1.GetPositionY();
            Score = player1.currentscore;
            endScreen.update(game1);
            if (level1.LevelCleared() == false)
            {
                if (player1.Dead() == true)
                {
                    endScreen2.GameLose();
                    game1.resetButtons();
                }

                if (!level1Started)
                {
                    game1.resetButtons();
                    level1Started = true;
                }
                level1.update(game1);
            }
            else if(level2.LevelCleared() == false)
            {
                if (player1.Dead() == true)
                {
                    endScreen2.GameLose();
                    game1.resetButtons();
                }
                if (!level2Started)
                {
                    game1.resetButtons();
                    level2Started = true;
                }
                level2.update(game1);
            }
            else if(level3.LevelCleared() == false)
            {
                if (player1.Dead() == true)
                {
                    endScreen3.GameLose();
                    game1.resetButtons();
                }

                if (!level3Started)
                {
                    game1.resetButtons();
                    level3Started = true;
                }
                level3.update(game1);
            }
            else
            {
                if (!levelBossStarted)
                {
                    if (player1.Dead() == true)
                    {
                        endScreen4.GameLose();
                        game1.resetButtons();
                    }
                    else
                    {
                        endScreen4.GameWon();
                        game1.resetButtons();
                    }

                    game1.resetButtons();
                    levelBossStarted = false;
                }
                levelBoss.update(game1);
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            if (level1.LevelCleared() == false)
            {               
                level1.draw(spritebatch);
            }

            else if(endScreen.levelcleared == false)
            {
                endScreen.draw(spritebatch);
            }

            else if (level2.LevelCleared() == false)
            {
                
                level2.draw(spritebatch);
            }

            else if (endScreen2.levelcleared == false)
            {
                endScreen2.draw(spritebatch);
            }
            else if (level3.LevelCleared() == false)
            {
               
                level3.draw(spritebatch);
            }

            else if (endScreen3.levelcleared == false)
            {
                endScreen3.draw(spritebatch);
            }
            else if(levelBoss.LevelCleared() == false)
            {                
                levelBoss.draw(spritebatch);
            }

            else if (endScreen4.levelcleared == false)
            {
                endScreen4.draw(spritebatch);
            }

        }

        

    }
}
