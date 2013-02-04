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

namespace Project2
{
    class Boss1
    {

        public int playerHealth = 100;
        public int bossHealth = 100;
        Texture2D player;
        Rectangle playerRect;
        Rectangle door;
        Texture2D bossDoor;
        Texture2D actions;
        Rectangle bossArea;
        Rectangle boss;
        Rectangle player_BossFight;
        Rectangle boss_BossFight;
        Rectangle actionBar;
        public bool fightingBoss = false;
        public bool yourTurn = false;
        public bool bossTurn = true;
        float interval = 3000f;
        float timer = 0f;
        List<Attack> bossAttacks;
        List<Attack> yourAttacks;
        List<Attack> bossAttack2;
        List<Attack> toasterThrow;
        List<Attack> finisher;
        public bool ableToAttack = true;
        SpriteFont courierNew;
        public bool bossDead = false;
        public bool youLost = false;
        float moveTimer = 0f;
        float moveInterval = 100f;
        int currentFrame = 1;
        int bearWidth = 52;
        int bearHeight = 52;
        Rectangle sourceRect;
        Vector2 origin;
        Vector2 location;
        Texture2D bear;
        Texture2D stump;
        Rectangle backGround;
        Texture2D bossArt;
        Texture2D punch;
        Texture2D roar;
        Texture2D tear;
        Texture2D toaster;
        Texture2D heart;
        Texture2D bossDeath;
        Texture2D acorn;
        Texture2D action2;
        Rectangle acorn_BossFight;
        public int roarUsed = 0;
        public bool acornAlive = true;
        SpriteFont tips;




        public Boss1(Texture2D player, Texture2D bossDoor, Texture2D actions, SpriteFont font, Texture2D bear, Texture2D stump, Texture2D bossArt, Texture2D punch, Texture2D roar, Texture2D tear, Texture2D toaster, Texture2D heart, Texture2D bossDeath, Texture2D acorn, Texture2D action2, SpriteFont tips)
        {

            //player = Content.Load<Texture2D>("player");
            door = new Rectangle(710, 220, 70, 110);
            this.player = player;
            playerRect = new Rectangle(600, 230, 52, 52);
            this.bossDoor = bossDoor;
            bossArea = new Rectangle(0, 300, 300, 300);
            boss = new Rectangle(100, 400, 100, 120);
            this.actions = actions;
            location = new Vector2(625, 255);

            this.bear = bear;
            this.stump = stump;
            this.bossArt = bossArt;
            this.punch = punch;
            this.roar = roar;
            this.tear = tear;
            this.toaster = toaster;
            this.heart = heart;
            this.bossDeath = bossDeath;
            this.action2 = action2;
            this.acorn = acorn;
            this.tips = tips;
            backGround = new Rectangle(0, 0, 800, 600);
            acorn_BossFight = new Rectangle(180, 150, 35, 35);

            player_BossFight = new Rectangle(600, 300, 43, 54);
            boss_BossFight = new Rectangle(170, 300, 100, 120);
            bossAttacks = new List<Attack>();
            bossAttack2 = new List<Attack>();
            yourAttacks = new List<Attack>();
            toasterThrow = new List<Attack>();
            finisher = new List<Attack>();
            actionBar = new Rectangle(300, 500, 200, 70);
            courierNew = font;


        }

        public void update(KeyboardState k, GameTime gameTime)
        {

            if (bossArea.Intersects(playerRect) && !bossDead)
            {

                fightingBoss = true;
                playerRect.X += 20;

            }

            if(boss_BossFight.Intersects(acorn_BossFight)){

                bossHealth = 0;
                acornAlive = false;

            }


            foreach (Attack j in bossAttacks)
            {

                if (player_BossFight.Intersects(j.attackPos) && j.isAlive)
                {

                    playerHealth -= 30;
                    j.isAlive = false;
                    bossTurn = false;
                    yourTurn = true;
                    ableToAttack = true;


                }

            }
            foreach (Attack j in bossAttack2)
            {


                if (player_BossFight.Intersects(j.attackPos) && j.isAlive)
                {

                    playerHealth -= 30;
                    j.isAlive = false;
                    bossTurn = false;
                    yourTurn = true;
                    ableToAttack = true;


                }

            }
            foreach (Attack v in yourAttacks)
            {

                if (boss_BossFight.Intersects(v.attackPos) && v.isAlive)
                {

                    bossHealth -= 10;
                    v.isAlive = false;
                    yourTurn = false;
                    bossTurn = true;


                }

            }
            foreach (Attack v in toasterThrow)
            {

                if (boss_BossFight.Intersects(v.attackPos) && v.isAlive)
                {

                    bossHealth -= 15;
                    v.isAlive = false;
                    yourTurn = false;
                    bossTurn = true;


                }

            }

            foreach (Attack v in finisher)
            {

                if (boss_BossFight.Intersects(v.attackPos) && v.isAlive)
                {

                    bossHealth = 0;
                    v.isAlive = false;
                    yourTurn = false;
                    bossTurn = true;


                }

            }

            if (bossHealth < 1)
            {

                fightingBoss = false;
                bossDead = true;
                MainGame.boss2beat = true;


            }

            if (playerHealth < 1)
            {

                fightingBoss = false;
                playerHealth = 100;
                bossHealth = 100;
                yourTurn = false;
                bossTurn = true;
                ableToAttack = true;
                playerRect.X = 600;
                location.X = 625;
                MainGame.atWoods = true;
                MainGame.atBoss1 = false;



            }

            if (!fightingBoss)
            {

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

                if (playerRect.X < 0)
                {
                    playerRect.X = 0;
                    location.X = 25;
                }
                if (playerRect.X > 750)
                {

                    playerRect.X = 750;
                    location.X = 775;
                }
                if (playerRect.Y < 330)
                {
                    playerRect.Y = 330;
                    location.Y = 355;

                }
                if (playerRect.Y > 550)
                {
                    playerRect.Y = 550;
                    location.Y = 575;


                }

                if (k.IsKeyDown(Keys.W))
                {


                    location.Y -= 2;
                    playerRect.Y -= 2;
                    currentFrame = 15;
                    if (currentFrame == 17)
                    {
                        currentFrame = 15;
                    }


                }
                if (k.IsKeyDown(Keys.A))
                {

                    location.X -= 2;
                    playerRect.X -= 2;
                    currentFrame = 18;
                    if (currentFrame == 20)
                    {
                        currentFrame = 18;
                    }


                }
                if (k.IsKeyDown(Keys.S))
                {

                    location.Y += 2;
                    playerRect.Y += 2;
                    currentFrame = 9;
                    if (currentFrame == 11)
                    {
                        currentFrame = 9;
                    }


                }
                if (k.IsKeyDown(Keys.D))
                {

                    location.X += 2;
                    playerRect.X += 2;
                    currentFrame = 12;
                    if (currentFrame == 14)
                    {
                        currentFrame = 12;
                    }


                }

                if (door.Intersects(playerRect))
                {
                    playerRect.X = 600;
                    location.X = 625;
                    MainGame.atWoods = true;
                    MainGame.atBoss1 = false;

                }






            }

            else if (fightingBoss)
            {

                if (roarUsed > 2)
                {
                    acorn_BossFight.Y += 3;

                }
                foreach (Attack i in bossAttacks)
                {

                    i.attackPos.X += 3;

                }
                foreach (Attack i in bossAttack2)
                {

                    i.attackPos.X += 3;

                }

                foreach (Attack j in yourAttacks)
                {

                    j.attackPos.X -= 3;

                }
                foreach (Attack j in toasterThrow)
                {

                    j.attackPos.X -= 3;

                }
                foreach (Attack j in finisher)
                {

                    j.attackPos.X -= 3;

                }

                if (bossTurn)
                {

                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                    //Check the timer is more than the chosen interval
                    if (timer > interval)
                    {
                        if (playerHealth > 70)
                        {

                            bossAttacks.Add(new Attack(boss_BossFight.X + 40, boss_BossFight.Y + 20));


                            timer = 0f;


                        }
                        else
                        {

                            bossAttack2.Add(new Attack(boss_BossFight.X + 40, boss_BossFight.Y + 20));


                            timer = 0f;

                        }

                    }


                }
                else if (yourTurn)
                {
                    if (ableToAttack)
                    {
                        if (k.IsKeyDown(Keys.D1))
                        {

                            yourAttacks.Add(new Attack(player_BossFight.X - 25, player_BossFight.Y));


                            ableToAttack = false;



                        }
                        if (k.IsKeyDown(Keys.D2) && bossHealth < 26)
                        {

                            finisher.Add(new Attack(player_BossFight.X - 25, player_BossFight.Y));


                            ableToAttack = false;

                        }
                        if (k.IsKeyDown(Keys.D4) && MainGame.boss1beat)
                        {

                            toasterThrow.Add(new Attack(player_BossFight.X - 25, player_BossFight.Y));

                            roarUsed++;

                            ableToAttack = false;

                        }
                    }

                }

            }


        }

        public void draw(SpriteBatch sprite, GraphicsDevice brush)
        {

            sprite.Begin();

            if (!fightingBoss)
            {



                brush.Clear(Color.Transparent);

                sprite.Draw(stump, backGround, Color.White);

                if (bossDead)
                {
                    sprite.Draw(bossDeath, boss, Color.White);
                }
                else
                {
                    sprite.Draw(bossArt, boss, Color.Yellow);
                }

                sprite.Draw(bear, location, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);

                //sprite.Draw(player, playerRect, Color.White);

                //sprite.Draw(bossDoor, door, Color.White);



            }
            else if (fightingBoss)
            {



                brush.Clear(Color.Tomato);

                sprite.Draw(stump, backGround, Color.White);

                sprite.Draw(player, player_BossFight, Color.White);

                sprite.Draw(bossArt, boss_BossFight, Color.White);

                if (acornAlive)
                {

                    sprite.Draw(acorn, acorn_BossFight, Color.White);

                }

                foreach (Attack i in bossAttacks)
                {
                    if (i.isAlive)
                    {

                        sprite.Draw(punch, i.attackPos, Color.Red);
                    }

                }

                foreach (Attack i in bossAttack2)
                {
                    if (i.isAlive)
                    {

                        sprite.Draw(toaster, i.attackPos, Color.White);
                    }

                }

                foreach (Attack j in yourAttacks)
                {
                    if (j.isAlive)
                    {

                        sprite.Draw(tear, j.attackPos, Color.Violet);
                    }

                }
                foreach (Attack j in toasterThrow)
                {
                    if (j.isAlive)
                    {

                        sprite.Draw(roar, j.attackPos, Color.Violet);
                    }

                }
                foreach (Attack j in finisher)
                {
                    if (j.isAlive)
                    {

                        sprite.Draw(heart, j.attackPos, Color.Violet);
                    }

                }
                if (yourTurn)
                {

                    if (MainGame.boss1beat)
                    {

                        sprite.Draw(action2, actionBar, Color.White);

                    }
                    else
                    {

                        sprite.Draw(actions, actionBar, Color.White);
                    }
                }

                sprite.DrawString(courierNew, bossHealth.ToString(), new Vector2(170.0f, 400.0f), Color.White);
                sprite.DrawString(courierNew, playerHealth.ToString(), new Vector2(600.0f, 400.0f), Color.White);

                sprite.DrawString(tips, "His softspot is his head, if only we could reach it", new Vector2(300.0f, 575.0f), Color.White);
            }




            sprite.End();

        }




    }
}
