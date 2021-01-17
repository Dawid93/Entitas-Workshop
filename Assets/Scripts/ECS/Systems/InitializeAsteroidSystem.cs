using Entitas;
using UnityEngine;

public class InitializeAsteroidSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitializeAsteroidSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        for (int i = 0; i < 4; i++)
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddAsteroid(3);
            entity.AddInitialPosition(new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0));
        }
    }
}