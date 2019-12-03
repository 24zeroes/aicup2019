using AiCup2019.Model;
namespace AiCup2019{
    public static class VelocityBuilder{
        public static double Build(Strategy strategy, Unit player, Vec2Double target, Tile[][] tiles){
            if (strategy.Type == StrategyType.Kill && (player.OnLadder(tiles) == false && player.OnJumper(tiles) == false))
            {
                if (player.Position.X > target.X)
                {
                    return  - 7;
                }
                else
                {
                    return  + 7;
                }
                
            }
                
            
            return target.X < player.Position.X ? double.MinValue : double.MaxValue;
        }
    }
}