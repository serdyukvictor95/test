using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;
using Gameplay.Weapons;


[RequireComponent(typeof(Spaceship))]
public class EnemyShipController : ShipController
{
    [SerializeField]
    private Vector2 _fireDelay;
    [SerializeField]
    private int _points;
    [SerializeField]
    private List<GameObject> availableBonuses;
    
    [SerializeField]
    private float newTimer;
    




    private bool _fire = true;  
    private float timer;  
    private int direction = 1;
    public int Points {get{return _points;}}

    public static System.Action<int> OnEnemyDestroyed;
    void OnEnable(){
        timer = newTimer;
    }
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
        if(newTimer !=0){
        HorizontalMove();
        movementSystem.LateralMovement(direction * Time.deltaTime/5);}   
    }
    private void HorizontalMove(){
        //задаем таймер изменения направления горизонтального движения
        timer-=Time.deltaTime;
        if(timer <= 0) {
            timer = newTimer;
            if(direction==1)
            direction = -1;
            else if(direction==-1)
            direction = 1;
        }
    }
    

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }

    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }

    private void OnDestroy() 
    {
        if (OnEnemyDestroyed != null && !GetComponent<Spaceship>().Alive)
        {
            //добавления события, для отслеживания убитого корабля и выпадение бонуса 
            OnEnemyDestroyed.Invoke(_points);
            if (Random.Range(0f, 1f) > 0.5f)
                Instantiate(availableBonuses[Random.Range(0, availableBonuses.Count)], transform.position, transform.rotation);
        }
    }
}
