using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipSystems;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Bonuses
{
    [RequireComponent(typeof(MovementSystem))]
    public abstract class Bonus : MonoBehaviour
    {
        [SerializeField]
        private BonusIdentity bonusIdentity;
        public BonusIdentity BonusIdentity {get {return bonusIdentity;}}

        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerShipController>();
            
            if (player != null)
            {
                Debug.Log(player.name);
                ApplyEffectOnPlayer(player);
            }
        }

        private void Update() 
        {
            GetComponent<MovementSystem>().LongitudinalMovement(Time.deltaTime);
        }

        public virtual void ApplyEffectOnPlayer(PlayerShipController player = null)
        {
            Destroy(this.gameObject);
        }
    }
    public enum BonusIdentity
    {
        Health,
        AttackSpeed
    }
}
