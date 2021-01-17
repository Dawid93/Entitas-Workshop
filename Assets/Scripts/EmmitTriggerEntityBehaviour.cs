using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntitasTest
{
    public class EmmitTriggerEntityBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddCollision(gameObject, other.gameObject);
        }
    }
}
