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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class PlayerComponent : Microsoft.Xna.Framework.GameComponent {
        public PlayerComponent(Game game)
            : base(game) {
            // TODO: Construct any child components here
        }

        private Boolean isWalking;
        public Boolean Walking {
            get { return isWalking; }
        }

        private int facing;
        public int Facing {
            get { return facing; }
            set { facing = value; }
        }

        private Texture2D texture;
        public Texture2D Texture {
            get { return texture; }
            set { texture = value; }
        }

        private Vector2 position;
        public Vector2 Position {
            get { return position; }
        }

        public void Load() {
            texture = Game1.Instance.Content.Load<Texture2D>(@"Textures\Sprites\sprite_front");
            position = new Vector2(320, 320);
            tileX = (int)position.X / 32;
            tileY = (int)position.Y / 32;
        }


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize() {
            // TODO: Add your initialization code here
            Load();
            base.Initialize();
        }

        private float speed = 1f;
        public float Speed {
            get { return speed; }
            set { speed = value; }
        }

        private int tileX, tileY;
        public int TileX {
            get { return tileX; }
        }
        public int TileY {
            get { return tileY; }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime) {
            // TODO: Add your update code here

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Q)) {
                Game1.Instance.camera.Zoom += 0.2f;

            } else if (ks.IsKeyDown(Keys.E)) {
                Game1.Instance.camera.Zoom -= 0.2f;
            }

            int oldFacing = facing;

            if (ks.IsKeyDown(Keys.Left) && !isWalking) {
                isWalking = true;
                position.X -= speed;
                facing = 1;
            }
            if (ks.IsKeyDown(Keys.Up) && !isWalking) {
                isWalking = true;
                position.Y -= speed;
                facing = 2;

            }
            if (ks.IsKeyDown(Keys.Right) && !isWalking) {
                isWalking = true;
                position.X += speed;
                facing = 3;
            }

            if (ks.IsKeyDown(Keys.Down) && !isWalking) {
                isWalking = true;
                position.Y += speed;
                facing = 4;
            }

            Boolean shouldUpdateSprite = facing == oldFacing ? false : true;


            // Sjekker om du er inne i en ny tile. Blir brukt til å force en tile kordinasjon fordi enginen er rar
            // Den sjekker innenfor en %6

            double dx = position.X % 32;
            double dy = position.Y % 32;



            int tempX = tileX;
            int tempY = tileY;          

            if (dx <= 16 && dx >= 10 && facing == 1) {
                tileX = (int)(position.X / 32);
            }
            if (dy <= 7 && dy >= 1 && facing == 2) {
                tileY = (int)(position.Y / 32);
            }
            if (dx >= 16 && dx <= 24 && facing == 3) {
                tileX = (int)(position.X / 32 + 1);

            }
            if (dy <= 7 && dy >= 1 && facing == 4) {
                tileY = (int)(position.Y / 32 + 1);

            }
            ///////////////////////////////////////

            //if (tempX != tileX || tempY != tileY) {
            //    test(tempX, tempY);
            //}

            if (shouldUpdateSprite) updateSprite();
            Game1.Instance.camera.Update(Position);
            isWalking = false;

            base.Update(gameTime);
        }

        public void test(int x, int y) {
            Console.WriteLine(x + "  " + y);
        }

        public void updateTileVector(Vector2 newVector) {
            position = newVector;
        }

        public void onTileChange(Vector2 oldTile, Vector2 newTile) {

        }

        public void updateSprite() {
            Texture2D newTexture;
            switch (facing) {
                case 1:
                    newTexture = Game1.Instance.Content.Load<Texture2D>(@"Textures\Sprites\sprite_left");
                    break;
                case 2:
                    newTexture = Game1.Instance.Content.Load<Texture2D>(@"Textures\Sprites\sprite_back");

                    break;
                case 3:
                    newTexture = Game1.Instance.Content.Load<Texture2D>(@"Textures\Sprites\sprite_right");
                    break;

                default:
                    newTexture = Game1.Instance.Content.Load<Texture2D>(@"Textures\Sprites\sprite_front");
                    break;

            }
            Texture = newTexture;
        }
    }
}
