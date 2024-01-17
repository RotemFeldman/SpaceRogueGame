using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [Header("Gameplay")]
    [SerializeField] float Range =10f;
    [SerializeField] float ShootingSpeed = 0.5f ;
    [SerializeField] GameObject Bullet;


    [Header("Visual")]
    [SerializeField] SpriteRenderer SpriteRenderer;

    private bool _canShoot;
    private float _lastShot;

    private void Update()
    {
        FindTargetsInRange(Range);

        if (Targets.Count > 0)
        {
            PointToTarget(FindClosestTarget());
            TryShoot();
        }
    }


    private void TryShoot()
    {
        if (_canShoot)
        {
            
            
            _canShoot = false;
            _lastShot = Time.time;
            return;
        }
        else
        {
            if (_lastShot + ShootingSpeed < Time.time) { _canShoot = true; }
        }

    }

    public void Shoot(Transform startPosition, float angle)
    {
        Instantiate(Bullet);

        Bullet.transform.Translate(startPosition.position);
        
    }



}
