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
    [SerializeField] GameObject BulletSpawnPoint;

    [Header("Bullet")]
    [SerializeField] protected GameObject BulletObject;
    [SerializeField] public float _bulletSpeed;
    
    [SerializeField] float ReloadTime = 2f;
    [SerializeField] GameObject BulletsParent;
    [SerializeField] int _bulletPoolSize = 10;

    private List<GameObject> _bulletsPool = new List<GameObject>();

    
    

    [Header("Visual")]
    [SerializeField] SpriteRenderer SpriteRenderer;

    private bool _canShoot;
    private float _lastShot;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InstantiateBulletsPool();
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



    #region Shooting Methods

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
        GameObject bullet = GetBulletFromPool();
        
        if (bullet == null)
        {
            Debug.Log("GetBulletFromPool returned null");
            return;
        }

        bullet.transform.position = BulletSpawnPoint.transform.position;
        bullet.SetActive(true);
        
    }

    #endregion


    private void InstantiateBulletsPool()
    {
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(BulletObject, BulletsParent.transform);
            bullet.SetActive(false);
            _bulletsPool.Add(bullet);
        }
    }

    private GameObject GetBulletFromPool()
    {
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            if (!_bulletsPool[i].activeInHierarchy)
            {
                return _bulletsPool[i];
            }
        }

        return null;
    }

    

}
