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

namespace Game_Test {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        public TileMap myMap;

        //static int width = 800;
        //static int height = 480;
        ////int squaresAcross = (int)Math.Ceiling(width / 32m) + 1;
        ////int squaresDown = (int)Math.Ceiling(height/32m) + 1;

        public Camera2D camera;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont mainFont;
        Texture2D SimpleTexture;


        public PlayerComponent player;
        public TileManager tileManager;

        public static Game1 Instance {
            get { return Program.game; }
        }


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferWidth = 1024;
            //graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            player = new PlayerComponent(this);
            camera = new Camera2D(GraphicsDevice.Viewport);
            tileManager = new TileManager();
            myMap = new TileMap();
            SimpleTexture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);


            Components.Add(player);
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {      
            mainFont = Content.Load<SpriteFont>("font");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }


        


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        long time = Environment.TickCount;
        int counter;
        int fps;

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw camera
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            for (int x = 0; x < TileMap.size; x++) {
                for (int y = 0; y < TileMap.size; y++) {
                    int id = myMap.Rows[y].blocks[x];
                    spriteBatch.Draw(TileManager.getBlockTexture(id), new Rectangle((x * 32), (y * 32), 32, 32), Color.White); ;
                }
            }
            // Draw player
            spriteBatch.Draw(player.Texture, player.Position, Color.White);
            spriteBatch.End();


            


            // Draw text

            spriteBatch.Begin();
            spriteBatch.DrawString(mainFont, "X: " + (int)(player.Position.X), new Vector2(20, 20), Color.Black);
            spriteBatch.DrawString(mainFont, "Y: " + (int)(player.Position.Y), new Vector2(20, 40), Color.Black);
            spriteBatch.DrawString(mainFont, "X tile: " + player.TileY, new Vector2(20, 60), Color.Black);
            spriteBatch.DrawString(mainFont, "Y tile: " + player.TileX, new Vector2(20, 80), Color.Black);
            spriteBatch.DrawString(mainFont, "FPS: " + fps, new Vector2(20, 100), Color.Black);


            spriteBatch.DrawString(mainFont, "facing: " + player.Facing, new Vector2(20, 120), Color.Black);
            spriteBatch.DrawString(mainFont, "block: " + myMap.Rows[player.TileY].blocks[player.TileX] + ", " + TileManager.getTileByVector(player.TileX, player.TileY).name, new Vector2(20, 140), Color.Black);
            double d1 = player.Position.X % 32;
            double d2 = player.Position.Y % 32;
            counter++;
            if (Environment.TickCount >= time + 1000) {
                fps = counter;
                counter = 0;
                time = Environment.TickCount;

                Console.WriteLine("X: " + d1);
                Console.WriteLine("Y: " + d2);
                Console.WriteLine();

            }
            spriteBatch.DrawString(mainFont, "modulo x: " + d1, new Vector2(20, 160), Color.Black);
            spriteBatch.DrawString(mainFont, "modulo y: " + d2, new Vector2(20, 180), Color.Black);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
