using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    public static Weapon instance;
    
    public static List<Enemie> Targets = new List<Enemie>();


    [HideInInspector]
    public Vector3 _bulletDirection;
    [HideInInspector]
    public Vector3 _bulletPosition;
    [HideInInspector]
    public Vector3 _bulletRotation;
    [HideInInspector]
    public Enemie _closestEnemie;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    protected virtual void FindTargetsInRange(float range)
    {
        foreach (Enemie enemie  in CombatManager.AllEnemies)
        {
            float distanceSqr = (transform.position - enemie.transform.position).sqrMagnitude;
            if (distanceSqr < range * range && !enemie.IsDead())
            {
                if (!Targets.Contains(enemie)) { Targets.Add(enemie); }
            }
            else
            {
                if (Targets.Contains(enemie)) { Targets.Remove(enemie); }
            }
        }
    }

    protected virtual Enemie FindClosestTarget()
    {
        if (Targets[0] == null) { return null; }

        Enemie closest = Targets[0];
        float distanceSqr = (transform.position - Targets[0].transform.position).sqrMagnitude;

        float targetDist;

        foreach (Enemie target in Targets)
        {
            targetDist = (transform.position - target.transform.position).sqrMagnitude;
            if (targetDist < distanceSqr) { closest = target; }
        }
        _closestEnemie = closest;
        return closest;
    }

    protected virtual void PointToTarget(Enemie target)
    {
        if (target == null) return;

        Vector3 targ = target.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        if (target.transform.position.x < transform.position.x)        
            transform.rotation = Quaternion.Euler(new Vector3(-180, 0, -angle));        
        else        
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        

        _bulletDirection = target.transform.position - transform.position;
        _bulletPosition = transform.position;
        _bulletRotation = transform.position - _closestEnemie.transform.position;
    }
}
