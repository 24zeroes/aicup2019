using AiCup2019.Model;
namespace AiCup2019{
    public class Cache{
        public Vec2Double Peak {get; set;}
        public Cache(Unit player, Game game){
            Peak = player.Position;
            foreach (var lootBox in game.LootBoxes)
            {
                if (lootBox.Position.Y > Peak.Y && game.Level.Tiles[(int)player.Position.X][(int)player.Position.Y] != Tile.Ladder){
                    Peak = lootBox.Position;
                }
            }
        }
    }
}