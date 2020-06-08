using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        private float _health;
        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        private Slider healthBar;

        [SerializeField]
        private Text healthText;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Health {get {return _health;} set{_health = value;}}
        public bool Alive {get {return _health > 0;}}

        public float MaxHealth {get{return _maxHealth;}}

        private void Start()
        {
            _health = _maxHealth;
            ShowHealth();
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _health -= damageDealer.Damage;
            if (!Alive){
                Destroy(gameObject);}
            else
                ShowHealth();
        }

        public void AddHealth(float bonus)
        {
            if (!Alive) return;
            _health = _health + bonus >= _maxHealth ? _maxHealth : _health + bonus;
            ShowHealth();
        }

        private void ShowHealth(){
            healthBar.value = _health/_maxHealth;
            healthText.text = string.Format("{0}|{1}", _health, _maxHealth);
        }
    }
}
