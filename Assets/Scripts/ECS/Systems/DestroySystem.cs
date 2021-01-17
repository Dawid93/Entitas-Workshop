using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EntitasTest
{
    public class DestroySystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _context;

        public DestroySystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroy);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.hasView)
                {
                    var view = entity.view.value;
                    view.Unlink();
                    Object.Destroy(view);
                }
                entity.Destroy();
            }
        }
    }
}
