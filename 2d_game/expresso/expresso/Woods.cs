using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Timers;

namespace Project2
{
    class Woods
    {

        public bool homeStart = false;
        public bool canFire = true;
        Texture2D player;
        Rectangle playerRect;
        Rectangle door;
        Texture2D house;
        Rectangle woodsBoundary;
        Rectangle boss1;
        Rectangle boss2;
        List<Badguy> enemies;
        List<Attack> projec;
        public Timer timer;
        float moveTimer = 0f;
        float moveInterval = 100f;
        int currentFrame = 1;
        int bearWidth = 52;
        int bearHeight = 52;
        Rectangle sourceRect;
        Vector2 origin;
        Vector2 location;
        Texture2D bear;
        Texture2D backGround;
        Rectangle woodsBackground;
        Texture2D tear;
        Rectangle toaster;
        Rectangle boss1Advice;
        Rectangle boss2Advice;
        Texture2D toast;
        public bool toasterPickedUp = false;
        SpriteFont tips;
        //public bool timerNotEnable = true;

        public Woods(Texture2D player, Texture2D house, Texture2D bear, Texture2D backGround, Texture2D tear, Texture2D toast, SpriteFont tips)
        {

            //player = Content.Load<Texture2D>("player");
            door = new Rectangle(500, 400, 50, 50);
            this.player = player;
            this.house = house;
            playerRect = new Rectangle(370, 440, 52, 52);
            woodsBoundary = new Rectangle(360, 400, 70, 90);
            boss1Advice = new Rectangle(550, 400, 70, 70);
            boss2Advice = new Rectangle(150, 400, 70, 70);

            boss1 = new Rectangle(-600, 440, 50, 50);
            boss2 = new Rectangle(1320, 440, 50, 50);
            enemies = new List<Badguy>();
            projec = new List<Attack>();
            this.bear = bear;
            location = new Vector2(395, 465);
            woodsBackground = new Rectangle(-800, 0, 2400, 600);
            this.backGround = backGround;
            this.tear = tear;
            this.toast = toast;
            this.tips = tips;
            toaster = new Rectangle(1200, 420, 30, 30);
            
            timer = new Timer(4000);
            timer.Elapsed += new ElapsedEventHandler(triggerSpawn);
            //timer.Enabled = true;
            
 

        }

        public void update(KeyboardState k, GameTime gameTime)
        {



            foreach (Badguy i in enemies)
            {

                i.enemyPos.X--;
                

            }
            foreach (Attack j in projec)
            {

                j.attackPos.X+=4;

            }
            
            foreach (Badguy i in enemies)
            {
                foreach (Attack j in projec)
                {

                    if (i.enemyPos.Intersects(j.attackPos) && j.isAlive && i.isAlive)
                    {
                       
                        i.isAlive = false;
                        j.isAlive = false;
                        

                    }

                }

            }

            moveTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (k.GetPressedKeys().Length == 0)
            {

                currentFrame = 1;

            }
            else if (moveTimer > moveInterval)
            {
                //Show the next frame
                currentFrame++;
                //Reset the timer
                moveTimer = 0f;
            }

            sourceRect = new Rectangle(currentFrame * bearWidth, 0, bearWidth, bearHeight);
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

            if (k.IsKeyDown(Keys.A))
            {
                if (playerRect.X < 50)
                {

                    woodsBackground.X += 2;
                    woodsBoundary.X += 2;
                    boss1.X += 2;
                    boss2.X += 2;
                    toaster.X += 2;
                    boss1Advice.X += 2;
                    boss2Advice.X += 2;

                    if (woodsBackground.X > 0)
                    {
                        woodsBackground.X = 0;
                        woodsBoundary.X = 1060;
                        boss1.X = 100;
                        boss2.X = 2300;
                    }
                }
                else
                {
                    location.X -= 2;
                    playerRect.X -= 2;

                }
                    currentFrame = 18;
                
                if (currentFrame == 20)
                {
                    currentFrame = 18;
                }

                


            }

            if(k.IsKeyUp(Keys.Space)){

                canFire = true;

            }

            if (k.IsKeyDown(Keys.Space))
            {

                currentFrame = 12;

                if (canFire)
                {

                    projec.Add(new Attack(playerRect.X, playerRect.Y));
                    canFire = false;

                }

            }

            if (k.IsKeyDown(Keys.D))
            {
                if (playerRect.X > 700)
                {

                    woodsBackground.X -= 2;
                    woodsBoundary.X -= 2;
                    boss1.X -= 2;
                    boss2.X -= 2;
                    toaster.X -= 2;
                    boss1Advice.X -= 2;
                    boss2Advice.X -= 2;

                    if (woodsBackground.X < -1600)
                    {
                        woodsBackground.X = -1600;
                        woodsBoundary.X = -340;
                        boss1.X = -1400;
                        boss2.X = 700;
                    }
                }
                else
                {
                    location.X += 2;
                    playerRect.X += 2;

                }
                
                currentFrame = 12;
                if (currentFrame == 14)
                {
                    currentFrame = 12;
                }


            }

            /*
            if (door.Intersects(playerRect))
            {

                MainGame.atHome = false;

            }
            */

            if (woodsBoundary.Intersects(playerRect) && k.IsKeyDown(Keys.LeftShift))
            {
                //woodsBackground.X = -800;
                MainGame.atBackyard = true;
                MainGame.atWoods = false;

            }
            if (boss1.Intersects(playerRect) && !k.IsKeyDown(Keys.LeftShift))
            {
                location.X = 155;
                playerRect.X = 130;
                MainGame.atBoss1 = true;
                MainGame.atWoods = false;
                

            }
            if (boss2.Intersects(playerRect) && !k.IsKeyDown(Keys.LeftShift))
            {
                location.X = 675;
                playerRect.X = 650;
                MainGame.atBoss2 = true;
                MainGame.atWoods = false;
                timer.Enabled = false;

            }
            if (toaster.Intersects(playerRect) && k.IsKeyDown(Keys.LeftShift))
            {
                toasterPickedUp = true;
                MainGame.toasterPickedUp = true;
                toaster.Y = 0;

            }




        }

        public void draw(SpriteBatch sprite, GraphicsDevice brush)
        {


            sprite.Begin();

            brush.Clear(Color.Turquoise);



            sprite.Draw(backGround, woodsBackground, Color.White);

            if (!toasterPickedUp)
            {

                sprite.Draw(toast, toaster, Color.White);
            }

            //sprite.Draw(house, woodsBoundary, Color.White);

            //sprite.Draw(house, boss1, Color.White);

            //sprite.Draw(house, boss2, Color.White);

            foreach (Badguy i in enemies)
            {
                if (i.isAlive)
                {

                    sprite.Draw(player, i.enemyPos, Color.Brown);
                }

            }

            foreach (Attack j in projec)
            {
                if (j.isAlive)
                {

                    sprite.Draw(tear, j.attackPos, Color.White);
                }

            }

            sprite.Draw(bear, location, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);

            if (playerRect.Intersects(woodsBoundary))
            {
                sprite.DrawString(tips, "Nice! You can go back to the yard", new Vector2(250.0f, 500.0f), Color.White);

            }
            if (playerRect.Intersects(toaster))
            {
                sprite.DrawString(tips, "That could come in handy", new Vector2(250.0f, 500.0f), Color.White);

            }
            if (playerRect.Intersects(boss1Advice))
            {
                sprite.DrawString(tips, "The boss over there is the easiest, DO IT BRO", new Vector2(250.0f, 500.0f), Color.White);

            }
            if (playerRect.Intersects(boss2Advice))
            {
                sprite.DrawString(tips, "That boss can be tricky..", new Vector2(250.0f, 500.0f), Color.White);

            }

            //sprite.Draw(player, playerRect, Color.White);


            sprite.End();


        }
        public void triggerSpawn(Object o, ElapsedEventArgs e)
        {

            enemies.Add(new Badguy());

        }

        public void moveEnemy(Rectangle enemy)
        {

            enemy.X -= 2;
            

        }



    }
}
