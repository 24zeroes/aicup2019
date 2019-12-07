using AiCup2019.Model;
using System.Linq;

namespace AiCup2019{
    public static class StrategyBuilder{
        public static Strategy Build(Unit player, Cache cache, Game game){

            if (player.Health < 89 && game.LootBoxes.Where(x => x.Item is Item.HealthPack).Any())
                return new Strategy {Type = StrategyType.Heal};

            if (player.Weapon.HasValue == false)
                return new Strategy {Type = StrategyType.Seek};
            
            if (player.Weapon.Value.Typ == WeaponType.RocketLauncher)
                return new Strategy {Type = StrategyType.WeaponChange};

            //if (cache.Peak.Y > player.Position.Y && cache.Peak.X != player.Position.X)
             //   return new Strategy {Type = StrategyType.Climb};

            return new Strategy {Type = StrategyType.Kill};
        }
    }
}