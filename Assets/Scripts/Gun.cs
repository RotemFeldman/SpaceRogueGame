using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : Weapon
{
    public static Gun Instance { get; private set; }

    [Header("Gun")]
    [SerializeField] float Range =10f;
    [SerializeField] float ShootingSpeed = 0.5f ;

    [Header("Bullet")]
    [SerializeField] protected GameObject BulletObject;
    [SerializeField] public float _bulletSpeed;
    

    [Header("Visual")]
    [SerializeField] SpriteRenderer SpriteRenderer;

    private bool _canShoot;
    private float _lastShot;

    private void Awake()
    {
        Instance = this;
    }

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
            Shoot();
            
            _canShoot = false;
            _lastShot = Time.time;
            return;
        }
        else
        {
            if (_lastShot + ShootingSpeed < Time.time) { _canShoot = true; }
        }

    }

    private void Shoot()
    {
        Instantiate(BulletObject,transform.position,Quaternion.identity);        
    }



}
