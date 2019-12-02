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
            var strategy = StrategyBuilder.Build(unit, _cache, game);
    
            UnitAction action = ActionBuilder.Build(strategy, unit, game, _cache);
            action.Log(debug, unit, strategy);
            return action;
        }
    }
}