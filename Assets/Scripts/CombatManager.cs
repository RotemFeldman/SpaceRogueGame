using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;

    public static List<GameObject> AllEnemies = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}