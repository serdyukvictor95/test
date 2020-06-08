

namespace Gameplay.Weapons
{
    public interface IDamagable
    {
        bool Alive { get;}
        float Health { get; set;}

        float MaxHealth {get;}
    
        UnitBattleIdentity BattleIdentity { get; }

        void ApplyDamage(IDamageDealer damageDealer);

    }


    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}


