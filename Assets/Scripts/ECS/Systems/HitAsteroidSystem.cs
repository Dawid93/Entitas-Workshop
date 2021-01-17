using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Random = System.Random;

namespace EntitasTest.ECS.Systems
{
    public class HitAsteroidSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _context;

        public HitAsteroidSystem(Contexts context) : base(context.game)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Collision));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCollision;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var first = entity.collision.first;
                var second = entity.collision.second;

                var firstEntity = _context.game.GetEntitiesWithView(first).SingleEntity();
                var secondEntity = _context.game.GetEntitiesWithView(second).SingleEntity();

                if (secondEntity.asteroid.level > 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var newEntity = _context.game.CreateEntity();
                        newEntity.AddAsteroid(secondEntity.asteroid.level - 1);
                        newEntity.AddInitialPosition(second.transform.position +
                                                     new Vector3(UnityEngine.Random.Range(-.1f, .1f),
                                                         UnityEngine.Random.Range(-.1f, .1f), 0));
                    }
                }

                firstEntity.isDestroy = true;
                secondEntity.isDestroy = true;
            }
        }
    }
}