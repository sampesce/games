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
    class Home
    {

        public bool homeStart = false;
        Texture2D player;
        Texture2D house;
        Rectangle playerRect;
        Rectangle door;
        float timer = 0f;
        float interval = 100f;
        int currentFrame = 1;
        int bearWidth = 52;
        int bearHeight = 52;
        Rectangle sourceRect;
        Vector2 origin;
        Vector2 location;
        Texture2D bear;
        Texture2D bearHouse;
        Rectangle backGround;
        SpriteFont tips;

        public Home(Texture2D player, Texture2D house, Texture2D bear, Texture2D bearHouse, SpriteFont tips)
        {

            //player = Content.Load<Texture2D>("player");
            door = new Rectangle(600, 60, 200, 300);
            this.player = player;
            this.house = house;
            playerRect = new Rectangle(375, 425, 52, 52);
            location = new Vector2(400, 450);
            this.bear = bear;
            this.bearHouse = bearHouse;
            this.tips = tips;
            backGround = new Rectangle(0, 0, 800, 600);

        }

        public void update(KeyboardState k, GameTime gameTime)
        {

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
            if (playerRect.Y < 275)
            {
                playerRect.Y = 275;
                location.Y = 300;

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
            if (playerRect.Intersects(door))
            {

                playerRect.X = 530;
                location.X = 555;
                MainGame.atBackyard = true;
                MainGame.atHome = false;
                

            }

        }

        public void draw(SpriteBatch sprite, GraphicsDevice brush)
        {


            sprite.Begin();

            brush.Clear(Color.Brown);

            sprite.Draw(bearHouse, backGround, Color.White);

            sprite.Draw(bear, location, sourceRect, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);

            
            
            sprite.DrawString(tips, "Your basic controls for movement are W,A,S,D", new Vector2(250.0f, 500.0f), Color.White);
            sprite.DrawString(tips, "The left shift button is the action button", new Vector2(250.0f, 517.0f), Color.White);
            sprite.DrawString(tips, "You can press space if you run into enemies for a basic attack", new Vector2(250.0f, 532.0f), Color.White);
            sprite.DrawString(tips, "You need to fight enemies to gain strength, in order to defeat...him", new Vector2(230.0f, 549.0f), Color.White);

            

            //sprite.Draw(player, playerRect, Color.White);

            //sprite.Draw(house, door, Color.White);


            sprite.End();

            /*
            if (!homeStart)
            {

                brush.Clear(Color.Brown);

            }

            if(homeStart == true){

                sprite.Begin();

              

                sprite.End();

                brush.Clear(Color.Red);
           
            }
             */ 
        }
             
              

    }
}
