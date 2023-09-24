﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ObjectData;

namespace TempleUprising.Common.WorldGeneration
{
    public static class TileHelper
    {
        /// <summary>
        /// 检测是否为一个背景方块
        /// </summary>
        public static bool TopSlope(this Tile tile)
        {
            byte b = (byte)tile.Slope;
            if (b != 1)
                return b == 2;

            return true;
        }

        /// <summary>
        /// 将可能越界的方块坐标收值为非越界坐标
        /// </summary>
        public static Vector2 PTransgressionTile(Vector2 TileVr, int L = 0, int R = 0, int D = 0, int S = 0)
        {
            if (TileVr.X > Main.maxTilesX - R)
            {
                TileVr.X = Main.maxTilesX - R;
            }
            if (TileVr.X < 0 + L)
            {
                TileVr.X = 0 + L;
            }
            if (TileVr.Y > Main.maxTilesY - S)
            {
                TileVr.Y = Main.maxTilesY - S;
            }
            if (TileVr.Y < 0 + D)
            {
                TileVr.Y = 0 + D;
            }
            return new Vector2(TileVr.X, TileVr.Y);
        }

        /// <summary>
        /// 检测该位置是否存在一个实心的固体方块
        /// </summary>
        public static bool HasSolidTile(this Tile tile)
        {
            return tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType];
        }

        public static Vector2 FindTopLeft(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            if (tile == null)
                return new Vector2(x, y);
            TileObjectData data = TileObjectData.GetTileData(tile.TileType, 0);
            x -= tile.TileFrameX / 18 % data.Width;
            y -= tile.TileFrameY / 18 % data.Height;
            return new Vector2(x, y);
        }

        /// <summary>
        /// 检测方块的一个矩形区域内是否有实心物块
        /// </summary>
        /// <param name="tileVr">方块坐标</param>
        /// <param name="DetectionL">矩形左</param>
        /// <param name="DetectionR">矩形右</param>
        /// <param name="DetectionD">矩形上</param>
        /// <param name="DetectionS">矩形下</param>
        public static bool TileRectangleDetection(Vector2 tileVr, int DetectionL, int DetectionR, int DetectionD, int DetectionS)
        {
            Vector2 newTileVr;
            for (int x = 0; x < DetectionR - DetectionL; x++)
            {
                for (int y = 0; y < DetectionS - DetectionD; y++)
                {
                    newTileVr = PTransgressionTile(new Vector2(tileVr.X + x, tileVr.Y + y));
                    if (Main.tile[(int)newTileVr.X, (int)newTileVr.Y].HasSolidTile())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 获取一个物块目标，输入世界物块坐标，自动考虑收界情况
        /// </summary>
        public static Tile GetTile(Vector2 pos)
        {
            pos = PTransgressionTile(pos);
            return Main.tile[(int)pos.X, (int)pos.Y];
        }
    }
}
