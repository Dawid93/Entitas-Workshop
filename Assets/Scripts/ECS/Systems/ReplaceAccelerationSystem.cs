using Entitas;
using UnityEngine;

public class ReplaceAccelerationSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public ReplaceAccelerationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.game.input.value.y;
        var playerEntity = _contexts.game.playerEntity;
        var playerTransform = playerEntity.view.value.transform;

        var acceleration = playerEntity.acceleration.value;
        playerEntity.ReplaceAcceleration(acceleration + input * playerTransform.up * _contexts.game.gameSetup.value.MovementSpeed * Time.deltaTime);
    }
}