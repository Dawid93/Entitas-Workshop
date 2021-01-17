using System;
using System.Collections.Generic;
using Entitas;

namespace EntitasTest.ECS.Systems
{
    public class RotateLaserSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _context;

        public RotateLaserSystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View, GameMatcher.Laser, GameMatcher.Acceleration));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isLaser && entity.hasView && entity.hasAcceleration;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = entity.view.value.transform;
                var acceleration = entity.acceleration.value;
                view.transform.up = acceleration.normalized;
            }
        }
    }
}