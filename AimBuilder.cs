using AiCup2019.Model;
namespace AiCup2019{
    public static class AimBuilder{
        public static Vec2Double Build(Unit player, Unit? nearestEnemy){
            if (nearestEnemy.HasValue)
                return new Vec2Double(nearestEnemy.Value.Position.X - player.Position.X, nearestEnemy.Value.Position.Y - player.Position.Y);
                
            return new Vec2Double(0, 0);
        }
    }
}