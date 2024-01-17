using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [Header("Gameplay")]
    [SerializeField] float Range =10f;
    [SerializeField] float ShootingSpeed = 0.5f ;


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
            //// shoot
            
            _canShoot = false;
            _lastShot = Time.time;
            return;
        }
        else
        {
            if (_lastShot + ShootingSpeed < Time.time) { _canShoot = true; }
        }

    }



}
