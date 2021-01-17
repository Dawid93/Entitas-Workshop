using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace EntitasTest.ECS.Systems
{
    public class MapAsteroidLevelToResourceSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public MapAsteroidLevelToResourceSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Asteroid);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAsteroid;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var gameSetup = _contexts.game.gameSetup.value;
            var asteroidSpeed = gameSetup.AsteroidSpeed;
            
            foreach (var entity in entities)
            {
                entity.AddResource(MapLevelToGameObject(entity.asteroid.level, gameSetup));
                var randomAngle = Random.Range(0, 2f);
                entity.AddAcceleration(new Vector3(asteroidSpeed * Mathf.Cos(randomAngle), asteroidSpeed * Mathf.Sin(randomAngle), 0f));
            }
        }

        private GameObject MapLevelToGameObject(int level, GameSetup gameSetup)
        {
            switch (level)
            {
                case 3: 
                    return gameSetup.Bigs[Random.Range(0, gameSetup.Bigs.Length)];
                case 2:
                    return gameSetup.Meds[Random.Range(0, gameSetup.Meds.Length)];
                case 1:
                    return gameSetup.Smalls[Random.Range(0, gameSetup.Smalls.Length)];
                case 0:
                    return gameSetup.Tinys[Random.Range(0, gameSetup.Tinys.Length)];
                default:
                    return gameSetup.Bigs[Random.Range(0, gameSetup.Bigs.Length)];
            }
        }
    }
}