using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;

    public static List<Enemie> AllEnemies = new List<Enemie>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
