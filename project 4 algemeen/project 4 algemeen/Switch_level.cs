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
        EndScreen endScreen, endScreen2, endScreen3, endScreen4, endScreen5;
        int Score;
        public Sound sound;
        gameElement current, Origin;
        float relativeSize;
        Action<game> exit;
        
        public Switch_level() { }
        public Switch_level(List<Texture2D> All_images,game game1,double screen_width,double screen_height,float relativeSize, Action<game> exit, platform platform,SpriteFont font, GraphicsDeviceManager graphics, Sound sound, gameElement Origin)
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
            this.relativeSize = relativeSize;
            this.exit = exit;
            this.Origin = Origin;
            
            
            switch (platform)
            {
                case platform.android:
                    player1 = new AndroidPlayer(All_images, game1, screen_width, screen_height, font, graphics, platform,1000,25, sound);
                    break;
                case platform.windows:
                    player1 = new Player(this.All_images, this.game1, this.screen_width, this.screen_height, platform, 1000, 25, sound);
                    break;
                default:
                    break;
            }

            endScreen = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
            endScreen2 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
            endScreen3 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
            endScreen4 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Go back to menu", All_images[15]);
            endScreen5 = new EndScreen(true, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Go back to menu", All_images[12]);
            level1 = new Level_1("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
            level2 = new Level_2("Level 2", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
            level3 = new Level_3("Level 3", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
            levelBoss = new Level_Boss("Level Boss", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
            
            current = level1;


        }
        public void updateScreenSize(int width, int height)
        {
            this.screen_width = width;
            this.screen_height = height;
            current.updateScreenSize(width, height); 
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

            Score = player1.currentscore;
            current.update(game1);

            if (player1.dead == true)
            {
                endScreen5.UpdateScore(Score);
                current = endScreen5;
                endScreen5.GameLose();
                game1.resetButtons();
            }

            if (current == level1) //checks if current is level 1 and if level 1 is cleared and then changes the current to the first 'endscreen'
            {
                

                if (level1.levelcleared == true)
                {
                    endScreen.UpdateScore(Score);
                    current = endScreen;
                    game1.resetButtons();
                }
            }



            else if (current == endScreen)
            {
                if (endScreen.levelcleared == true)
                {
                    current.update(game1);
                    current = level2;
                    game1.resetButtons();
                }
            }

            else if (current == level2)
            {

                if (level2.levelcleared == true)
                {
                    endScreen2.UpdateScore(Score);
                    current = endScreen2;
                    game1.resetButtons();
                }
            }

            else if (current == endScreen2)
            {
                if (endScreen2.levelcleared == true)
                {
                    current = level3;
                    game1.resetButtons();
                }
            }
            else if (current == level3)
            {
                if (level3.levelcleared == true)
                {
                    endScreen3.UpdateScore(Score);
                    current = endScreen3;
                    game1.resetButtons();
                }
            }

            else if (current == endScreen3)
            {
                if (endScreen3.levelcleared == true)
                {
                    sound.UnicornSound();
                    current = levelBoss;
                    game1.resetButtons();
                }
            }
            else if (current == levelBoss)
            {
                if (levelBoss.levelcleared == true)
                {

                    endScreen4.UpdateScore(Score);
                    current = endScreen4;
                    endScreen4.GameWon();
                    game1.resetButtons();
                }
            }


            else if (current == endScreen4)
            {
                if (endScreen4.levelcleared == true)
                {

                    endScreen = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
                    endScreen2 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
                    endScreen3 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
                    endScreen4 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Go back to menu", All_images[15]);
                    endScreen5 = new EndScreen(true, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Go back to menu", All_images[12]);
                    level1 = new Level_1("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    level2 = new Level_2("Level 2", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    level3 = new Level_3("Level 3", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    levelBoss = new Level_Boss("Level Boss", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    player1.currentscore = 0;


                    game1.current = Origin;
                    game1.resetButtons();
                    current = level1;

                }


            }
            else if (current == endScreen5)
            {
                if (endScreen5.levelcleared == true)
                {
                    player1 = new Player(this.All_images, this.game1, this.screen_width, this.screen_height, platform, 1000, 500, sound);
                    endScreen = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
                    endScreen2 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
                    endScreen3 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Next level", All_images[14]);
                    endScreen4 = new EndScreen(false, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Go back to menu", All_images[15]);
                    endScreen5 = new EndScreen(true, Font, screen_width, screen_height, graphics, game1, platform, Score, this.sound, "Go back to menu", All_images[12]);
                    level1 = new Level_1("Level 1", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    level2 = new Level_2("Level 2", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    level3 = new Level_3("Level 3", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    levelBoss = new Level_Boss("Level Boss", this.screen_width, this.screen_height, this.All_images, this.game1, this.platform, this.Font, this.graphics, this.player1, projectiles, sound);
                    player1.currentscore = 0;
                    
                    
                    game1.current = Origin;
                    game1.resetButtons();
                    current = level1;
                }
            }




        }
        public void draw(SpriteBatch spritebatch)
        {
            current.draw(spritebatch);
        }

        

    }
}
