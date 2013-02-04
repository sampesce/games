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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Home home;
        Backyard backyard;
        Woods woods;
        Boss1 boss1;
        Boss2 boss2;
        Boss3 boss3;
        Texture2D startScreen;
        Texture2D endScreen;
        Rectangle rectForStart;
        public static bool atHome = false;
        public static bool atBackyard = false;
        public static bool atBoss1 = false;
        public static bool atBoss2 = false;
        public static bool atBoss3 = false;
        public static bool atWoods = false;
        public static bool gameStart = true;
        public static bool toasterPickedUp = false;
        public static bool boss1beat = false;
        public static bool boss2beat = false;
        public static bool boss3beat = false;
        public static bool ending = false;
        public bool gameOver = false;
        SpriteFont newFont;
        SpriteFont tips;
        
        

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            //graphics.IsFullScreen = bFullScreen;
            graphics.ApplyChanges();

            // add start screen to the page
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            Texture2D player = Content.Load<Texture2D>("bear_Boss");
            Texture2D house = Content.Load<Texture2D>("house");
            Texture2D action = Content.Load<Texture2D>("action1");
            Texture2D bear = Content.Load<Texture2D>("bear");
            Texture2D bearHouse = Content.Load<Texture2D>("bearHouse");
            Texture2D theBackyard = Content.Load<Texture2D>("backyard");
            Texture2D castle = Content.Load<Texture2D>("castle");
            Texture2D wooded = Content.Load<Texture2D>("Background");
            Texture2D stump = Content.Load<Texture2D>("stump");
            Texture2D tear = Content.Load<Texture2D>("tear");
            Texture2D garbage = Content.Load<Texture2D>("garbage");
            Texture2D trex = Content.Load<Texture2D>("trex");
            Texture2D fire = Content.Load<Texture2D>("fire");
            Texture2D toast = Content.Load<Texture2D>("toaster");
            Texture2D roar = Content.Load<Texture2D>("roar");
            Texture2D heart = Content.Load<Texture2D>("heart");
            Texture2D trexD = Content.Load<Texture2D>("trexD");
            Texture2D evilBear = Content.Load<Texture2D>("evilBear");
            Texture2D punch = Content.Load<Texture2D>("punch");
            Texture2D shock = Content.Load<Texture2D>("shock");
            Texture2D acorn = Content.Load<Texture2D>("acorn");
            Texture2D evilBearD = Content.Load<Texture2D>("evilBearD");
            Texture2D roar2 = Content.Load<Texture2D>("roar2");
            Texture2D baby = Content.Load<Texture2D>("baby");
            Texture2D babyD = Content.Load<Texture2D>("babyD");
            Texture2D milk = Content.Load<Texture2D>("milk");
            Texture2D vomit = Content.Load<Texture2D>("vomit");
            Texture2D crack= Content.Load<Texture2D>("crack");
            Texture2D action2 = Content.Load<Texture2D>("action2");
            Texture2D action3 = Content.Load<Texture2D>("action3");
            Texture2D action4 = Content.Load<Texture2D>("action4");
            Song song = Content.Load<Song>("song");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            

            
            newFont = Content.Load<SpriteFont>("myFont");
            tips = Content.Load<SpriteFont>("tips");

            

            home = new Home(player,house, bear,bearHouse, tips);
            backyard = new Backyard(player,house,bear, theBackyard, tips);
            woods = new Woods(player, house, bear, wooded, tear,toast, tips);
            boss1 = new Boss1(player,house, action, newFont, bear, stump, evilBear, punch,roar2,tear,shock,heart,evilBearD,acorn,action3,tips);
            boss2 = new Boss2(player, house,action, newFont, bear,garbage,trex,fire,roar, tear, toast,heart,trexD,action2,tips);
            boss3 = new Boss3(player,house, action, newFont, bear,castle,baby,milk,vomit, tear,roar2,heart,shock,crack,babyD, action4,tips);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            startScreen = Content.Load<Texture2D>("start");
            rectForStart = new Rectangle(0, 0, 800, 600);
            endScreen = Content.Load<Texture2D>("endscreen");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


           

            KeyboardState currCode = Keyboard.GetState();

            if (gameStart)
            {

                if (currCode.IsKeyDown(Keys.Enter))
                {

                    atHome = true;
                    gameStart = false;


                }
            }
            if (atHome)
            {

                //home = new Home();
                home.update(currCode,gameTime);
                home.draw(spriteBatch, graphics.GraphicsDevice);
            
            }
            if (atBackyard)
            {

                //home = new Home();
                backyard.update(currCode, gameTime);
                backyard.draw(spriteBatch, graphics.GraphicsDevice);

            }
            if (atBoss3)
            {

                //home = new Home();
                boss3.update(currCode,gameTime);
                boss3.draw(spriteBatch, graphics.GraphicsDevice);

            }
            if (atWoods)
            {

                //home = new Home();
                woods.timer.Enabled = true;
                woods.update(currCode, gameTime);
                woods.draw(spriteBatch, graphics.GraphicsDevice);

            }
            if (atBoss1)
            {

                //home = new Home();
                boss1.update(currCode, gameTime);
                boss1.draw(spriteBatch, graphics.GraphicsDevice);

            }
            if (atBoss2)
            {

                //home = new Home();
                boss2.update(currCode,gameTime);
                boss2.draw(spriteBatch, graphics.GraphicsDevice);

            }


            if (ending)
            {

                gameOver = true;
            }

            // TODO: Add your update logic here


            // do something like....

            /*
             * if GO button is clicked, make a new House, and run() that
             * 
             * if(Backyard){
             * 
             *  backyard.run();
             *  
             * which will take keyboard input, add the newbackground, and continually update
             * 
             * }
             * 
             * if(Boss1){
             *  ..... etc
             * 
             * }
             * 
             * 
             * 
             * 
            */
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            spriteBatch.Begin();





           if (!atHome && gameStart)
           {

               GraphicsDevice.Clear(Color.White);

               
               
               spriteBatch.Draw(startScreen, rectForStart, Color.White);

               

           }

           if (gameOver)
           {
               spriteBatch.Draw(endScreen, rectForStart, Color.White);

           }


            

           spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
