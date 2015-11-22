using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Test {
    public class Tile {

        public int tileID;
        public String name;
        public Texture2D image;

        public Tile(int tileID, String name, Texture2D image) {
            this.tileID = tileID;
            this.name = name;
            this.image = image;
        }

    }
}
