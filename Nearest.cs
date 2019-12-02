using AiCup2019.Model;
namespace AiCup2019{
    public class Nearest{
        public Unit? Enemy {get; set;}
        public LootBox? HealthPack {get; set;}
        public LootBox? Weapon {get; set;}
        public LootBox? Mine {get; set;}

        public Nearest(Unit player, Game game){
            Enemy = null;
            foreach(var other in game.Units){
                if (other.PlayerId != player.PlayerId)
                {
                    if (!Enemy.HasValue || Helpers.DistanceSqr(player.Position, other.Position) < Helpers.DistanceSqr(player.Position, Enemy.Value.Position))
                    {
                        Enemy = other;
                    }
                }
            }
            
            HealthPack = Mine = Weapon = null;
            foreach (var lootBox in game.LootBoxes)
            {
                if (lootBox.Item is Item.Weapon && ((Item.Weapon)lootBox.Item).WeaponType != WeaponType.RocketLauncher) //ToDo: убрать исключение РЛ
                {
                    if (!Weapon.HasValue || Helpers.DistanceSqr(player.Position, lootBox.Position) < Helpers.DistanceSqr(player.Position, Weapon.Value.Position))
                    {
                        Weapon = lootBox;
                    }
                }

                if (lootBox.Item is Item.HealthPack)
                {
                    if (!HealthPack.HasValue || Helpers.DistanceSqr(player.Position, lootBox.Position) < Helpers.DistanceSqr(player.Position, HealthPack.Value.Position))
                    {
                        HealthPack = lootBox;
                    }
                }

                if (lootBox.Item is Item.Mine)
                {
                    if (!Mine.HasValue || Helpers.DistanceSqr(player.Position, lootBox.Position) < Helpers.DistanceSqr(player.Position, Mine.Value.Position))
                    {
                        Mine = lootBox;
                    }
                }

            }
            

        }
    }
}