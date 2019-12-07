using AiCup2019.Model;
using System.Linq;

namespace AiCup2019{
    public static class StrategyBuilder{
        public static Strategy Build(Unit player, Cache cache, Game game, Nearest nearest){

            if (player.Health < 89 && game.LootBoxes.Where(x => x.Item is Item.HealthPack).Any())
                return new Strategy {Type = StrategyType.Heal};

            if (player.Weapon.HasValue == false)
                return new Strategy {Type = StrategyType.Seek};
            
            if (cache.EqualDistanceTicks > 10 || cache.PrevStrategy.Type == StrategyType.GettinCloser && Helpers.DistanceSqr(player.Position, nearest.Enemy.Value.Position) > 4)
            {
                return new Strategy {Type = StrategyType.GettinCloser};
            }

            return new Strategy {Type = StrategyType.Kill};
        }
    }
}