using System.Collections;
using System.Collections.Generic;
using Gameplay.Spaceships;
using Gameplay.ShipSystems;
using Gameplay.Bonuses;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    [RequireComponent(typeof(Spaceship))]
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private float _fireDelay;
        [SerializeField]
        private float _dps;
        public float Dps {get {return _dps;} set {_dps = _dps == 1 ? value : _dps;}}
        private bool _fire = true; 
        public static System.Action OnPlayerDestroyed;   
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!_fire)
                    return;

                fireSystem.TriggerFire();
                StartCoroutine(FireDelay(_fireDelay * _dps));
            }
        }     

        private IEnumerator FireDelay(float delay)
        {
            _fire = false;
            yield return new WaitForSeconds(delay);
            _fire = true;
        }
         private void OnDestroy() 
    {
        if (OnPlayerDestroyed != null)
        {
            OnPlayerDestroyed.Invoke();
            FindObjectOfType<GameController>().GameOver();
        }
        
    }
    }
}
