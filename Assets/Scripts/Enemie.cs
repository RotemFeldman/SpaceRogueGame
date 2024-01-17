using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    protected virtual int HP { get;set; }
    protected virtual float MoveSpeed { get; set; }

    protected void Start()
    {
        CombatManager.AllEnemies.Add(gameObject);   
    }

    protected void Update()
    {
        if (IsDead())
        {
            OnDeathDo();
        }
        
    }

    protected bool IsDead()
    {
        if (HP > 0)
        {
            return false;
        }
        return true;
    }

    protected void OnDeathDo()
    {
        CombatManager.AllEnemies.Remove(gameObject);
        gameObject.SetActive(false);
    }

}
