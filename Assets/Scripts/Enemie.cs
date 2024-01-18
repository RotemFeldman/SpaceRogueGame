using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    protected virtual int HP { get; set; } = 5;
    protected virtual float MoveSpeed { get; set; }

    protected void Awake()
    {
        CombatManager.AllEnemies.Add(this);
    }

    protected void Update()
    {
        if (IsDead())
        {
            OnDeathDo();
        }

    }

    public bool IsDead()
    {
        if (HP > 0)
        {
            return false;
        }
        return true;
    }

    protected void OnDeathDo()
    {
        CombatManager.AllEnemies.Remove(this);
        Weapon.Targets.Remove(this);
        Debug.Log(CombatManager.AllEnemies.Count);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            OnCollisionWithBullet();
            return;
        }
    }

    private void OnCollisionWithBullet()
    {
        HP -= Gun.Instance.Damage;
    }
}
