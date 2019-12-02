using AiCup2019;
using System.Linq;

namespace AiCup2019.Model{
    public static class JumpBuilder{
        public static bool Build(Unit player, Vec2Double target, Game game, Strategy strategy, Nearest nearest){

            if (target.X > player.Position.X && game.Level.Tiles[(int)(player.Position.X + 1)][(int)(player.Position.Y)] == Tile.Wall)
                return true;
            
            if (target.X < player.Position.X && game.Level.Tiles[(int)(player.Position.X - 1)][(int)(player.Position.Y)] == Tile.Wall)
                return true;

            if (strategy.Type == StrategyType.Kill && player.UnderPlatform(game.Level.Tiles) == true){
                return true;
            }

            if (strategy.Type == StrategyType.Kill && player.OnLadder(game.Level.Tiles) && nearest.Enemy.Value.OnLadder(game.Level.Tiles) && target.Y - player.Position.Y > 5){
                return true;
            }

            return strategy.Type != StrategyType.Kill && target.Y > player.Position.Y;
        }
    }
}