using AiCup2019.Model;
using System.Linq;
using System;

namespace AiCup2019{
    public static class UnitExtention{
        public static bool OnLadder(this Unit player, Tile[][] level){
            return level[(int)player.Position.X][(int)player.Position.Y] == Tile.Ladder || 
                    level[(int)player.Position.X][(int)player.Position.Y - 1] == Tile.Ladder;
        }
        public static bool OnJumper(this Unit player, Tile[][] level){
            return level[(int)player.Position.X][(int)player.Position.Y] == Tile.JumpPad ||
                    (int)player.Position.Y - 1 > -1 && level[(int)player.Position.X][(int)player.Position.Y - 1] == Tile.JumpPad ||
                    (int)player.Position.Y - 2 > -1 && level[(int)player.Position.X][(int)player.Position.Y - 2] == Tile.JumpPad;
        }
        public static bool UnderPlatform(this Unit player, Tile[][] level){
            return 
                level[(int)player.Position.X][(int)player.Position.Y + 2] == Tile.Platform ||
                level[(int)player.Position.X - 1][(int)player.Position.Y + 2] == Tile.Platform ||
                level[(int)player.Position.X + 1][(int)player.Position.Y + 2] == Tile.Platform ||
                level[(int)player.Position.X][(int)player.Position.Y + 1] == Tile.Platform ||
                level[(int)player.Position.X - 1][(int)player.Position.Y + 1] == Tile.Platform ||
                level[(int)player.Position.X + 1][(int)player.Position.Y + 1] == Tile.Platform ||
                level[(int)player.Position.X][(int)player.Position.Y] == Tile.Platform ||
                level[(int)player.Position.X - 1][(int)player.Position.Y ] == Tile.Platform ||
                level[(int)player.Position.X + 1][(int)player.Position.Y] == Tile.Platform;
        }
        public static bool CanShoot(this Unit player, Unit target, Tile[][] tiles, Nearest nearest){
            var tan = ((nearest.Enemy.Value.Position.Y - player.Position.Y) / (nearest.Enemy.Value.Position.X - player.Position.X));
            
            var isRightSide = nearest.Enemy.Value.Position.X < player.Position.X;
            var increment = isRightSide ? -0.3 : 0.3;

            double x1 = player.Position.X;
            double y1 = player.Position.Y + 1;
            double x2 = nearest.Enemy.Value.Position.X;
            double y2 = nearest.Enemy.Value.Position.Y + 1;
            double x = x1;
            double y = y1;

            try
            {
                while ((int)x != (int)(x2))
                {
                    x = x + increment;
                    y = (x * y2 - x * y1 - x1 * y2 + x2 * y1) / (x2 - x1);
                    if ((int)x == (int)(x2) && ((int)y == (int)y2 || (int)y == (int)(y2 + 1) || (int)y == (int)(y2 - 1)))
                        break;

                    if (tiles[(int)x][(int)y] == Tile.Wall)
                        return false;
                }
            }
            catch(Exception e){
                return false;
            }

            return true;
        }
        public static bool CanBlock(this Unit[] units, Unit player){
            return units.Where(x => 
                (int)x.Position.Y == (int)player.Position.Y && 
                ((int)x.Position.X == (int)player.Position.X + 1 || (int)x.Position.X == (int)player.Position.X + 1)).Any();
        }
        
    }
}