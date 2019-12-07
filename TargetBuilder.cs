using AiCup2019.Model;
namespace AiCup2019{
    public static class TargetBuilder{
        public static Vec2Double Build(Strategy strategy, Nearest nearest, Cache cache, Unit player){
            if (nearest.Weapon.HasValue && strategy.Type == StrategyType.Seek){
                return new Vec2Double(nearest.Weapon.Value.Position.X, nearest.Weapon.Value.Position.Y);
            }

            if (nearest.HealthPack.HasValue && strategy.Type == StrategyType.Heal){
                return new Vec2Double(nearest.HealthPack.Value.Position.X, nearest.HealthPack.Value.Position.Y);
            }

            if (strategy.Type == StrategyType.Climb){
                return cache.Peak;
            }

            var addition = 0;
            
            if (strategy.Type == StrategyType.GettinCloser)
            {

                return new Vec2Double(nearest.Enemy.Value.Position.X + addition, nearest.Enemy.Value.Position.Y);
            }

            if (nearest.Enemy.HasValue){
                if (player.Position.X > nearest.Enemy.Value.Position.X)
                {
                    addition = 6;
                }
                else 
                {
                    addition = -6;
                }

                if (nearest.Enemy.Value.Weapon.HasValue && nearest.Enemy.Value.Weapon.Value.Typ == WeaponType.RocketLauncher)
                    addition = addition * 2;

                if (Helpers.DistanceSqr(player.Position, nearest.Enemy.Value.Position) < addition * addition)
                    addition = addition * -1;

                if (Helpers.DistanceSqr(player.Position, nearest.Enemy.Value.Position) < 16)
                    addition = addition * -1;

                return new Vec2Double(nearest.Enemy.Value.Position.X + addition, nearest.Enemy.Value.Position.Y);
            }
            
            return new Vec2Double(nearest.Enemy.Value.Position.X, nearest.Enemy.Value.Position.Y);
        }
    }
}