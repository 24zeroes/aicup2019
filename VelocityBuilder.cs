using AiCup2019.Model;
namespace AiCup2019{
    public static class VelocityBuilder{
        public static double Build(Strategy strategy, Unit player, Vec2Double target, Tile[][] tiles){
            if (strategy.Type == StrategyType.Kill && (player.OnLadder(tiles) == false && player.OnJumper(tiles) == false))
            {
                return target.X - player.Position.X;
                
            }
                
            
            return target.X < player.Position.X ? double.MinValue : double.MaxValue;
        }
    }
}