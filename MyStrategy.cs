using AiCup2019.Model;
using System;

namespace AiCup2019
{
    public class MyStrategy
    {
        private Cache _cache {get; set;}

        public UnitAction GetAction(Unit unit, Game game, Debug debug)
        {
            if (_cache == null)
                _cache = new Cache(unit, game);

            var nearest = new Nearest(unit, game);

            _cache.UpdateDistance(unit, nearest.Enemy.Value);

            var strategy = StrategyBuilder.Build(unit, _cache, game, nearest);
            _cache.PrevStrategy = strategy;
            UnitAction action = ActionBuilder.Build(strategy, unit, game, _cache, nearest);
            action.Log(debug, unit, strategy);
            return action;
        }
    }
}