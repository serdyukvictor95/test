using System.Collections;
using System.Collections.Generic;
using Gameplay.Bonuses;
using Gameplay.ShipControllers.CustomControllers;
using UnityEngine;

public class AttackSpeedBonus : Bonus
{
    [SerializeField]
    public float attackSpeedBonus;

    public override void ApplyEffectOnPlayer(PlayerShipController player)
    {
        player.Dps = attackSpeedBonus;
        base.ApplyEffectOnPlayer();
    }
}
