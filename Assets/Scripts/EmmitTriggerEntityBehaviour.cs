using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace EntitasTest
{
    public class EmmitTriggerEntityBehaviour : MonoBehaviour, ILaserListener, ILaserRemovedListener
    {
        private void Awake()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            var entity = gameContext.GetEntitiesWithView(gameObject).SingleEntity();
            RegisterEvents(gameContext, entity);
        }

        private void RegisterEvents(GameContext gameContext, GameEntity entity)
        {
            entity.AddLaserListener(this);
            entity.RemoveLaserListener(this);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddCollision(gameObject, other.gameObject);
        }

        public void OnLaser(GameEntity entity)
        {
            Debug.Log("Laser Appear");
        }

        public void OnLaserRemoved(GameEntity entity)
        {
            Debug.Log("Laser Destroyed");
        }
    }
}
