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
    class Backyard
    {

        public bool homeStart = false;
        Texture2D player;
        Texture2D door;
        Rectangle playerRect;
        Rectangle house;
        Rectangle boss3;
        Rectangle woodsBoundary;
        Rectangle woodsAdvice;
        Rectangle boss3Advice;
        float timer = 0f;
        float interval = 100f;
        int currentFrame = 1;
        int bearWidth = 52;
        int bearHeight = 52;
        Rectangle sourceRect;
        Vector2 origin;
        Vector2 location;
        Texture2D bear;
        Texture2D theBackyard;
        Rectangle backGround;
        SpriteFont tips;


        public Backyard(Texture2D player, Texture2D door, Texture2D bear, Texture2D theBackyard, SpriteFont tips)
        {

            //player = Content.Load<Texture2D>("player");
            house = new Rectangle(20, 410, 170, 100);
            this.player = player;
            this.door = door;
            playerRect = new Rectangle(250, 475, 52, 52);
            boss3 = new Rectangle(380, 550, 370, 50);
            woodsBoundary = new Rectangle(740, 340, 60, 60);
            this.bear = bear;
            this.tips = tips;
            location = new Vector2(275, 500);
            this.theBackyard = theBackyard;
            backGround = new Rectangle(0, 0, 800, 600);
            woodsAdvice = new Rectangle(740, 450, 60, 60);
            boss3Advice = new Rectangle(250, 475, 60, 60);
            

        }

        public void update(KeyboardState k,GameTime gameTime)
        {

            if (MainGame.boss3beat)
            {

                MainGame.atBackyard = false;
                MainGame.ending = true;

            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (k.GetPressedKeys().Length == 0)
            {

                currentFrame = 1;

            }

            else if (timer > interval)
            {
                //Show the next frame
                currentFrame++;
                //Reset the timer
                timer = 0f;
            }

            //If we are on the last frame, reset back to the one before the first frame (because currentframe++ is called next so the next frame will be 1!)
            /*
            if (currentFrame == 25)
            {
                currentFrame = 0;
            }
            */

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
            if (playerRect.Y < 355)
            {
                playerRect.Y = 355;
                location.Y = 380;

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
            if (house.Intersects(playerRect))
            {
                playerRect.X = 250;
                location.X = 275;
                MainGame.atHome = true;
                MainGame.atBackyard = false;
                
                

            }
            if (boss3.Intersects(playerRect))
            {
                playerRect.X = 275;
                location.X = 300;
                MainGame.atBoss3 = true;
                MainGame.atBackyard = false;



            }
            if (woodsBoundary.Intersects(playerRect))
            {
                playerRect.X = 740;
                playerRect.Y = 430;
                location.X = 765;
                location.Y = 455;
                MainGame.atWoods = true;
                MainGame.atBackyard = false;



            }

            

        }

        public void draw(SpriteBatch sprite, GraphicsDevice brush)
        {

        

            sprite.Begin();

            

            brush.Clear(Color.Green);

            sprite.Draw(theBackyard, backGround, Color.White);

            //sprite.Draw(door, woodsBoundary, Color.White);

            sprite.Draw(bear, location, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);

            if (playerRect.Intersects(boss3Advice))
            {
                sprite.DrawString(tips, "There HE is, you're probably not strong enough..", new Vector2(250.0f, 400.0f), Color.White);

            }
            if (playerRect.Intersects(woodsAdvice))
            {
                sprite.DrawString(tips, "The enemies here are more your speed", new Vector2(250.0f, 400.0f), Color.White);

            }

            //sprite.Draw(player, playerRect, Color.White);

            //sprite.Draw(door, house, Color.White);

            //sprite.Draw(door, boss3, Color.White);


            sprite.End();


        }



    }
}
