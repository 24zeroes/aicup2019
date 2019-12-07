using AiCup2019.Model;
namespace AiCup2019{
    public class Cache{
        public Vec2Double Peak {get; set;}
        public double? PrevDistance {get; set;}
        public double? CurrentDistance {get; set;}
        public Strategy PrevStrategy {get; set;}
        public int EqualDistanceTicks {get; set;}
        public Cache(Unit player, Game game){
            Peak = player.Position;
            foreach (var lootBox in game.LootBoxes)
            {
                if (lootBox.Position.Y > Peak.Y && game.Level.Tiles[(int)player.Position.X][(int)player.Position.Y] != Tile.Ladder){
                    Peak = lootBox.Position;
                }
            }
            CurrentDistance = null;
            PrevDistance = null;
            EqualDistanceTicks = 0;
        }

        public void UpdateDistance(Unit player, Unit enemy)
        {
            if (CurrentDistance.HasValue)
            {
                PrevDistance = CurrentDistance;
            }

            CurrentDistance = Helpers.DistanceSqr(player.Position, enemy.Position);
            
            if (PrevDistance.HasValue && (int)CurrentDistance.Value == (int)PrevDistance.Value)
            {
                EqualDistanceTicks++;
            }
            else
            {
                EqualDistanceTicks = 0;
            }
        }
    }
}