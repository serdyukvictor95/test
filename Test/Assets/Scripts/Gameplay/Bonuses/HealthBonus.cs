using System.Collections;
using System.Collections.Generic;
using Gameplay.Bonuses;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.Spaceships;
using UnityEngine;

public class HealthBonus : Bonus
{
    [SerializeField]
    public float healthBonus;

    public override void ApplyEffectOnPlayer(PlayerShipController player)
    {
        player.GetComponent<Spaceship>().AddHealth(healthBonus);
        base.ApplyEffectOnPlayer();
    }
}
