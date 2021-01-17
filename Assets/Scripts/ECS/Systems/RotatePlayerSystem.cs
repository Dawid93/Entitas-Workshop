using Entitas;
using UnityEngine;

public class RotatePlayerSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public RotatePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var input = _contexts.game.input.value.x;
        var playerTransform = _contexts.game.playerEntity.view.value.transform;
        var playerRotation = playerTransform.rotation.eulerAngles;
        playerRotation.z -= input * _contexts.game.gameSetup.value.RotationSpeed * Time.deltaTime;
        playerTransform.rotation = Quaternion.Euler(playerRotation);
    }
}