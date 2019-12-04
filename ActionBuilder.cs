using AiCup2019.Model;

namespace AiCup2019{
    public static class ActionBuilder{
        public static UnitAction Build(Strategy strategy, Unit player, Game game, Cache cache){
            var nearest = new Nearest(player, game);
            var target = TargetBuilder.Build(strategy, nearest, cache, player);
            var aim = AimBuilder.Build(player, nearest.Enemy);
            var jump = JumpBuilder.Build(player, target, game, strategy, nearest);
            var velocity = VelocityBuilder.Build(strategy, player, target, game.Level.Tiles);
            var action = new UnitAction();
            

            action.Velocity = velocity;
            action.Jump = jump;
            action.JumpDown = jump == false;
            action.Aim = aim;
            action.Shoot = player.CanShoot(nearest.Enemy.Value, game.Level.Tiles, nearest);
            action.SwapWeapon = ChangeWeaponBuilder.Build(player, strategy, nearest.Weapon);
            action.PlantMine = false;
            action.Reload = false;
            return action;
        }
    }
}