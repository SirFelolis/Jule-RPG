using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Test {

    public class MapRow {
        public List<MapCell> Columns = new List<MapCell>();
        public int[] blocks = new int[TileMap.size];
    }

    public class TileMap {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 64;
        public int MapHeight = 64;
        public static int size = 64;

        public TileMap() {
            for (int y = 0; y < size; y++) {
                MapRow thisRow = new MapRow();
                Rows.Add(thisRow);
            }

            for (int i = 0; i < size; i++) {
                for (int ii = 0; ii < size; ii++) {
                    Rows[i].blocks[ii] = 0;
                }
            }

            Rows[2].blocks = (replaceArrayAt(getIdByString("sand*10"), 5));
            Rows[3].blocks = (replaceArrayAt(getIdByString("sand*16"), 5));
            Rows[4].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*14,sand,sand"), 4));
            Rows[5].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*15,sand,sand"), 3));
            Rows[6].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*16,sand*3"), 3));
            Rows[7].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*18,sand,sand"), 3));
            Rows[8].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*19,sand,sand"), 3));
            Rows[9].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*20,sand"), 3));
            Rows[10].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*20,sand"), 3));
            Rows[11].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*20,sand"), 3));
            Rows[12].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*20,sand"), 2));
            Rows[13].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*20,sand"), 2));
            Rows[14].blocks = (replaceArrayAt(getIdByString("sand,sand,grass*20,sand"), 2));
            Rows[15].blocks = (replaceArrayAt(getIdByString("sand*23"), 2));
            Rows[16].blocks = (replaceArrayAt(getIdByString("stone*62"), 2));
        }

        public int[] getIdByString(String[] input) {
            int[] newArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++) {
                int i2 = TileManager.getTileByName(input[i]).tileID;
                newArray[i] = i2;
            }
            return newArray;
        }


        public int[] getIdByString(String input) {
            String[] split = input.Split(',');
            List<int> newArray = new List<int>();
            for (int i = 0; i < split.Length; i++) {
                if (split[i].Contains("*")) {
                    String[] newSplit = split[i].Split('*');
                    for (int i2 = 0; i2 < Int32.Parse(newSplit[1]); i2++) {
                        String test = split[i].Split('*')[0];
                        Tile t = TileManager.getTileByName(test);
                        newArray.Add(t.tileID);
                    }
                } else {
                    newArray.Add(TileManager.getTileByName(split[i]).tileID);
                }
            }
            return newArray.ToArray();

        }

        public int[] replaceArrayAt(int[] input, int startIndex) {
            int[] newArray = new int[size];
            if (input.Length + startIndex > newArray.Length) {
                Console.WriteLine("Error in making map! Make sure the startIndex of the array you are using to replace is less than the size of the map");
                Console.WriteLine("Start index: " + startIndex + ", input length: " + input.Length);
                return new int[size];
            }
            Boolean flag = false;
            int count = 0;
            for (int i = 0; i < newArray.Length; i++) {
                if (i >= startIndex && !flag) {
                    for (int i2 = 0; i2 < input.Length; i2++) {
                        newArray[count] = input[i2];
                        count++;
                    }
                    flag = true;
                }
                count++;
                if ((flag) && (count == newArray.Length)) break;
            }
            return newArray;
        }
    }
}
