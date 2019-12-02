using AiCup2019.Model;

namespace AiCup2019{
    public static class Helpers{
        public static double DistanceSqr(Vec2Double a, Vec2Double b)
        {
            return (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
        }
    }
}