using AiCup2019.Model;
using System.Linq;

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
        public static bool CanShoot(this Unit player, Unit target, Tile[][] tiles){
            if (player.Weapon.HasValue && player.Weapon.Value.Typ == WeaponType.RocketLauncher)
            {
                if (tiles[(int)(player.Position.X + 1)][(int)(player.Position.Y)] == Tile.Wall)
                    return false;
            
                if (tiles[(int)(player.Position.X - 1)][(int)(player.Position.Y)] == Tile.Wall)
                    return false;
            }

            if (Helpers.DistanceSqr(player.Position, target.Position) > 500)
                return false;

            return true;
        }
        public static bool CanBlock(this Unit[] units, Unit player){
            return units.Where(x => 
                (int)x.Position.Y == (int)player.Position.Y && 
                ((int)x.Position.X == (int)player.Position.X + 1 || (int)x.Position.X == (int)player.Position.X + 1)).Any();
        }
        
    }
}