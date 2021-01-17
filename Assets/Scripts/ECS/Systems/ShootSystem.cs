using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ShootSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public ShootSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var entity = _contexts.game.CreateEntity();
            var playerTransform = _contexts.game.playerEntity.view.value.transform;
            entity.AddResource(_contexts.game.gameSetup.value.Laser);
            entity.AddAcceleration(playerTransform.up * _contexts.game.gameSetup.value.LaserSpeed);
            entity.AddInitialPosition(playerTransform.position);
            entity.isLaser = true;
        }
    }
}