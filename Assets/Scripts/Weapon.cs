using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    
    protected List<GameObject> Targets = new List<GameObject>();

    public Vector3 _bulletDirection;
    public Vector3 _bulletPosition;
    public Vector3 _bulletRotation;
    public GameObject _closestEnemie;


    protected virtual void FindTargetsInRange(float range)
    {
        foreach (GameObject enemie  in CombatManager.AllEnemies)
        {
            Debug.Log(enemie.name);
            float distanceSqr = (transform.position - enemie.transform.position).sqrMagnitude;
            if (distanceSqr < range * range)
            {              
                if (!Targets.Contains(enemie)) { Targets.Add(enemie.gameObject); }
            }
        }
    }

    protected virtual GameObject FindClosestTarget()
    {
        if (Targets[0] == null) { return null; }

        GameObject closest = Targets[0];
        float distanceSqr = (transform.position - Targets[0].transform.position).sqrMagnitude;

        float targetDist;

        foreach (GameObject target in Targets)
        {
            targetDist = (transform.position - target.transform.position).sqrMagnitude;
            if (targetDist < distanceSqr) { closest = target; }
        }
        _closestEnemie = closest;
        return closest;
    }

    protected virtual void PointToTarget(GameObject target)
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
