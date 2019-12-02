using AiCup2019.Model;

namespace AiCup2019{
    public static class ActionExtentions{
        public static void Log(this UnitAction action, Debug debug, Unit player, Strategy strategy){
            debug.Draw(new CustomData.Log($"Unit #{player.Id} | Velocity: {action.Velocity} | Jump: {action.Jump} | JumpDown: {action.JumpDown} | Aim: {action.Aim.X} {action.Aim.Y} | Shoot: {action.Shoot} | SwapWeapon: {action.SwapWeapon} | PlantMine: {action.PlantMine}"));
            debug.Draw(new CustomData.Log($"HP: {player.Health}"));
            debug.Draw(new CustomData.Log($"Strategy: {strategy.Type}"));
        }
    }
}