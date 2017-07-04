using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System;

using Microsoft.VisualBasic;
using project_4_algemeen;

using System.Collections.Generic;



namespace project_4_algemeen
{
    public class Player : gameElement
    {
        public Location shootDirection;
        public List<Texture2D> All_images;
        public List<projectile> projectiles=new List<projectile>();
        public Location[] position;
        Keys[] activeKeys;
        public Location direction;
        Random random;
        public int X, Y;
        public int lenght;
        public int texdirection;
        public int mouseX, mouseY;
        public int size_x, size_y;
        KeyboardState keyboard;
        game game1;
        public double screen_width, screen_height;
        public List<button> Buttons = new List<button>();
        public List<textbox> Textboxes = new List<textbox>();
        public List<projectile> enemy_projectiles = new List<projectile> ();
        List<Texture2D> healthBar = new List<Texture2D>();
        List<Rectangle> healthLocation = new List<Rectangle>();
        public int damage = 0;
        platform platform;
        public int projectilesPS, projectileCNTMAX, projectileCNT;
        public int currentscore;
        public int HP, maxHP;
        public bool dead = false;
        public Sound sound;
        int hp19, hp18, hp17, hp16, hp15, hp14, hp13, hp12, hp11, hp10, hp9, hp8, hp7, hp6, hp5, hp4, hp3, hp2, hp1, hp0;

        public Player(List<Texture2D> All_images, game game1, double screen_width, double screen_height, platform platform,int HP,int damage, Sound sound)
        {
            this.All_images = All_images;
            this.lenght = 1;
            this.position = new Location[lenght];
            this.position[0] = new Location(0, 0);
            this.direction = new Location(1, 0);
            this.random = new Random();
            this.texdirection = 1;
            this.game1 = game1;
            this.screen_width = screen_width;
            this.screen_height = screen_height;
            this.damage = damage;
            this.HP = HP;
            this.maxHP = HP;
            this.hp19 = (int)(maxHP * (19f / 20f));
            this.hp18 = (int)(maxHP * (18f / 20f));
            this.hp17 = (int)(maxHP * (17f / 20f));
            this.hp16 = (int)(maxHP * (16f / 20f));
            this.hp15 = (int)(maxHP * (15f / 20f));
            this.hp14 = (int)(maxHP * (14f / 20f));
            this.hp13 = (int)(maxHP * (13f / 20f));
            this.hp12 = (int)(maxHP * (12f / 20f));
            this.hp11 = (int)(maxHP * (11f / 20f));
            this.hp10 = (int)(maxHP * (10f / 20f));
            this.hp9 = (int)(maxHP * (9f / 20f));
            this.hp8 = (int)(maxHP * (8f / 20f));
            this.hp7 = (int)(maxHP * (7f / 20f));
            this.hp6 = (int)(maxHP * (6f / 20f));
            this.hp5 = (int)(maxHP * (5f / 20f));
            this.hp4 = (int)(maxHP * (4f / 20f));
            this.hp3 = (int)(maxHP * (3f / 20f));
            this.hp2 = (int)(maxHP * (2f / 20f));
            this.hp1 = (int)(maxHP * (1f / 20f));
            this.hp0 = (int)(maxHP * (0f / 20f));
            this.platform = platform;
            this.projectilesPS = 3;
            this.projectileCNTMAX = 60 / projectilesPS;
            this.projectileCNT = 0;
            this.sound = sound;
            for(int i = 0; i < 10; i++)
            {
                healthBar.Add(All_images[9]);
                healthLocation.Add(new Rectangle(40 * i, 0, 40, 40));
            }
        }
        public virtual void update(game game1)
        {
            Dead();
            for (int i = lenght - 1; i > 0; i--)
            {
                if (i == 0)
                    position[i] = position[i] + direction;
                else
                    position[i] = position[i - 1];
            }

            foreach (projectile p in projectiles)
            {
                p.update(game1);
            }

            keyboard = Keyboard.GetState();
            Keys[] keys = keyboard.GetPressedKeys();
            if (platform == platform.windows)
                Move(keys);
            Shoot();

            if (HP > hp19)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[9];
                healthBar[8] = All_images[9];
                healthBar[9] = All_images[9];
            }
            else if (HP > hp18)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[9];
                healthBar[8] = All_images[9];
                healthBar[9] = All_images[10];
            }
            else if (HP > hp17)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[9];
                healthBar[8] = All_images[9];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp16)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[9];
                healthBar[8] = All_images[10];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp15)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[9];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp14)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[10];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp13)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[9];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp12)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[10];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp11)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[9];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp10)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[10];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp9)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[9];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp8)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[10];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp7)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[9];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp6)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[10];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp5)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[9];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp4)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[10];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp3)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[9];
                healthBar[2] = All_images[11];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp2)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[10];
                healthBar[2] = All_images[11];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp1)
            {
                healthBar[0] = All_images[9];
                healthBar[1] = All_images[11];
                healthBar[2] = All_images[11];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else if (HP > hp0)
            {
                healthBar[0] = All_images[10];
                healthBar[1] = All_images[11];
                healthBar[2] = All_images[11];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }
            else
            {
                healthBar[0] = All_images[11];
                healthBar[1] = All_images[11];
                healthBar[2] = All_images[11];
                healthBar[3] = All_images[11];
                healthBar[4] = All_images[11];
                healthBar[5] = All_images[11];
                healthBar[6] = All_images[11];
                healthBar[7] = All_images[11];
                healthBar[8] = All_images[11];
                healthBar[9] = All_images[11];
            }

            //if (texdirection == 1)
            //    this.playertex = playertex;
            //            if (texdirection == 2)
            //                this.playertex = playertex2;
            //            if (texdirection == 3)
            //                this.playertex = playertex3;
            //            if (texdirection == 4)
            //                this.playertex = playertex4;

            position[0] = position[0] + direction;
            direction = new Location(0, 0);

        }
        public void CurrentScore(int Score)
        {
            currentscore = currentscore + Score;
            
        }
        public bool Dead()
        {
            if (this.HP <= 0)
            {
                sound.PlayerDeadSound();
                 dead= true;
                return dead;
            }

            else
            {
                dead = false;
                return dead;
            }
        }
        public virtual void draw(SpriteBatch spritebatch)
        {
            size_x = (int)this.screen_width / 12;
            size_y = (int)this.screen_height / 10;
            Rectangle destinationRectangle = new Rectangle(this.X, this.Y, size_x, size_y);
            //spritebatch.Draw(All_images[0], destinationRectangle, Color.White);
            // for (int i = 0; i < lenght; i++)
            spritebatch.Draw(All_images[5], destinationRectangle, Color.White);
            foreach(projectile p in projectiles)
            {
                p.draw(spritebatch);
            }
            for(int i = 0; i < 10; i++)
            {
                spritebatch.Draw(healthBar[i], healthLocation[i], Color.White);
            }
        }
        public void GetHitProjectile(List<projectile> enemy_projectiles)
        {
            
            foreach (projectile PRO in enemy_projectiles)
            {
                if (PRO.position.X >= X && PRO.position.X < X + size_x && PRO.position.Y >= Y && PRO.position.Y < size_y)
                {
                    
                    PRO.update(game1);
                    this.HP -= PRO.damage;
                }
            }
        }
        public void GetHitMelee(int damage)
        {
            this.HP -= damage;
        }
        public virtual void Shoot()
        {
            if (projectileCNT < projectileCNTMAX)
            {
                projectileCNT++;
            }
            else if (projectileCNT >= projectileCNTMAX)
            {
                MouseState mouse = Mouse.GetState();
                if(mouse.LeftButton== ButtonState.Pressed)
                {
                    mouseX = mouse.X;
                    mouseY = mouse.Y;
                    sound.GunSound();
                    projectiles.Add(new projectile(this.damage,this.X+ (int)(size_x/2), this.Y+(int)(size_y / 2), this.mouseX, this.mouseY, this.screen_width, this.screen_height, this.All_images,this));
                }
                projectileCNT = 0;
            }
        }
        public int GetPositionX()
        {
            return this.X;
        }
        public int GetPositionY()
        {
            return this.Y;
        }
        public virtual void Move(Keys[] keys)
        {
            activeKeys = keys;
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

            if (this.X > (int)this.screen_width - size_x) { this.X = (int)this.screen_width - size_x; }
            if (this.Y > (int)this.screen_height - size_y) { this.Y = (int)this.screen_height - size_y; }
            if (this.X < 1) { this.X = 1; }
            if (this.Y < 1) { this.Y = 1; }
            foreach (Keys k in keys)
            {
                if (k == Keys.Right || k == Keys.D)
                {

                    this.X += 10;
                    this.texdirection = 1;

                }
                if (k == Keys.Down || k == Keys.S)
                {
                    this.Y += 10;
                    this.texdirection = 2;
                }
                if (k == Keys.Left || k == Keys.A)
                {

                    this.X -= 10;
                    this.texdirection = 3;
                }
                if (k == Keys.Up || k == Keys.W)
                {
                    this.Y -= 10;
                    this.texdirection = 4;
                }

            }
            //if (cnt == 0)
            //{
            //    this.update();
            //    cnt = 1;
            //}
            //else
            //    cnt--;
        }
        public Keys[] ActiveKeys
        {
            get
            {
                return activeKeys;
            }
            set
            {
                activeKeys = value;
            }
        }
        public List<button> buttons
        {
            get
            {
                return Buttons;
            }
        }
        public List<textbox> textboxes
        {
            get
            {
                return Textboxes;
            }
        }
    }
    public class AndroidPlayer : Player
    {
        Keys[] keys = new Keys[2];
        public AndroidPlayer(List<Texture2D> All_images, game game, double screen_width, double screen_height, SpriteFont font, GraphicsDeviceManager graphics, platform platform,int HP,int damage, Sound sound) : base(All_images, game, screen_width, screen_height,platform,HP,damage, sound)
        {
            shootDirection = new Location(0, 0);
        }
        public override void update(game game1)
        {
            
            for (int i = lenght - 1; i > 0; i--)
            {
                if (i == 0)
                    position[i] = position[i] + direction;
                else
                    position[i] = position[i - 1];
            }

            foreach (projectile p in projectiles)
            {
                p.update(game1);
            }
            position[0] = position[0] + direction;
            direction = new Location(0, 0);
        }
        public override void Move(Keys[] keys)
        {
            base.Move(keys);
        }
        public override void Shoot()
        {
            if(projectileCNT < projectileCNTMAX)
            {
                projectileCNT++;
            }
            else if(projectileCNT>= projectileCNTMAX)
            {
                projectiles.Add(new androidProjectile(damage, X + (int)(size_x / 2), Y + (int)(size_y / 2), shootDirection.X, shootDirection.Y, screen_width, screen_height, All_images, this));
                projectileCNT = 0;
                sound.GunSound();
            }
        }
        public override void draw(SpriteBatch spritebatch)
        {
            base.draw(spritebatch);
        }
    }
    public class Location
    {
        public int X, Y;
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public static Location operator +(Location l1, Location l2)
        {
            int x = l1.X + l2.X;
            int y = l1.Y + l2.Y;
            return new Location(x, y);
        }
    }
}
