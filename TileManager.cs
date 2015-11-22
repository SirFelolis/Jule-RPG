using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Test {
    public class TileManager {

        public static Tile tileWater = new Tile(0, "water", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\water"));
        public static Tile tileStone = new Tile(1, "stone", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\stone"));
        public static Tile tileGrass = new Tile(2, "grass", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\grass"));
        public static Tile tileDirt = new Tile(3, "dirt", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\dirt"));
        public static Tile tileSand = new Tile(4, "sand", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\sand"));
        public static Tile tileGrassStone = new Tile(5, "stone1", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\stone1"));
        public static Tile tilePlank = new Tile(6, "plank", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\stone1"));
        public static Tile tileError = new Tile(100, "error", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\error"));
        public static Tile tileOutline = new Tile(101, "outline", Program.game.Content.Load<Texture2D>(@"Textures\Tiles\outline"));

        public static List<Tile> tiles = new List<Tile>();
        public TileManager() {
            tiles.Add(tileWater);
            tiles.Add(tileDirt);
            tiles.Add(tileGrass);
            tiles.Add(tileSand);
            tiles.Add(tileStone);
            tiles.Add(tileGrassStone);
            tiles.Add(tilePlank);
            tiles.Add(tileError);
            tiles.Add(tileOutline);
        }

        public static Tile getTileByVector(int x, int y) {
            try {
                return getTileById(Game1.Instance.myMap.Rows[y].blocks[x]);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return tileError;
            }
        }

        public static Tile getTileById(int id) {
            foreach (Tile t in tiles) {
                if (t.tileID == id) {
                    return t;
                }
            }
            return tileError;
        }

        public static Tile getTileByName(String s) {
            foreach (Tile t in tiles) {
                if (t.name.ToLower() == s.ToLower().Trim()) {
                    return t;
                }
            }
            return tileError;
        }

        public static Texture2D getBlockTexture(int id) {
            return getTileById(id).image;
        }

        public static Rectangle GetSourceRectangle(int tileIndex) {
            return new Rectangle(tileIndex * 32, 0, 32, 32);
        }

    }
}
