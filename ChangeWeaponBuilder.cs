using AiCup2019.Model;
namespace AiCup2019{
    public static class ChangeWeaponBuilder{
        public static bool Build(Unit player, Strategy strategy, LootBox? nearestWeapon){
            if (nearestWeapon.HasValue && strategy.Type == StrategyType.WeaponChange)
                return true;
                
            return false;
        }
    }
}