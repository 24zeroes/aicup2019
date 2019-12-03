using AiCup2019.Model;
namespace AiCup2019{
    public static class ChangeWeaponBuilder{
        public static bool Build(Unit player, Strategy strategy, LootBox? nearestWeapon){
            if (nearestWeapon.HasValue && strategy.Type == StrategyType.WeaponChange)
                return true;

            if (nearestWeapon.HasValue && ((Item.Weapon)nearestWeapon.Value.Item).WeaponType == WeaponType.Pistol && player.Weapon.HasValue && player.Weapon.Value.Typ == WeaponType.AssaultRifle)
                return true;

            return false;
        }
    }
}