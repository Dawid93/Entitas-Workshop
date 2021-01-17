using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _context;

    public InstantiateViewSystem(Contexts context) : base(context.game)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameObject = Object.Instantiate(entity.resource.prefab);
            entity.AddView(gameObject);
            gameObject.Link(entity);

            if (entity.hasInitialPosition)
                gameObject.transform.position = entity.initialPosition.value;
        }
    }
}