using System.Collections;
using System.Collections.Generic;
using Entitas;
using EntitasTest;
using EntitasTest.ECS.Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSetup gameSetup;
    
    private Systems _systems;
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameSetup(gameSetup);
        
        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializeAsteroidSystem(contexts))
            .Add(new InitializePlayerSystem(contexts))
            
            .Add(new InputSystem(contexts))
            .Add(new ShootSystem(contexts))
            .Add(new HitAsteroidSystem(contexts))
            .Add(new MapAsteroidLevelToResourceSystem(contexts))
            .Add(new InstantiateViewSystem(contexts))
            .Add(new RotateLaserSystem(contexts))
            .Add(new ReplaceAccelerationSystem(contexts))
            .Add(new RotatePlayerSystem(contexts))
            .Add(new MoveSystem(contexts))
            .Add(new DestroySystem(contexts));
    }
}
