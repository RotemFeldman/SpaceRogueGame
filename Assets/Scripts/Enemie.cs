using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{

    void Start()
    {
        CombatManager.AllEnemies.Add(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
