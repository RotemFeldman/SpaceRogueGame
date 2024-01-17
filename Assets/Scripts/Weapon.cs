using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    
    protected List<GameObject> Targets = new List<GameObject>();




    protected virtual void FindTargetsInRange(float range)
    {
        foreach (GameObject enemie  in CombatManager.AllEnemies)
        {
            Debug.Log(enemie.name);
            float distanceSqr = (transform.position - enemie.transform.position).sqrMagnitude;
            if (distanceSqr < range * range)
            {
                Debug.Log(enemie.name + " in range");
                if (!Targets.Contains(enemie)) {
                    Debug.Log("added enemie");
                    Debug.Log(Targets.Count);
                    Targets.Add(enemie.gameObject); }
            }
        }
    }

    protected virtual GameObject FindClosestTarget()
    {
        if (Targets[0] == null) { Debug.Log("null"); return null; }

        GameObject closest = Targets[0];
        float distanceSqr = (transform.position - Targets[0].transform.position).sqrMagnitude;

        float targetDist;

        foreach (GameObject target in Targets)
        {
            targetDist = (transform.position - target.transform.position).sqrMagnitude;
            if (targetDist < distanceSqr) { closest = target; }
        }
        Debug.Log("123");
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
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
