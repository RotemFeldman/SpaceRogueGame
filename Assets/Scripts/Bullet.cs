using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    
    private float rot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Gun.Instance._bulletDirection.x, Gun.Instance._bulletDirection.y).normalized * Gun.Instance._bulletSpeed;
        rot = Mathf.Atan2(Gun.Instance._bulletRotation.x, Gun.Instance._bulletRotation.y)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rot+90f);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { return; }
        if (collision.gameObject.tag == "Bullet") { return; }

        Destroy(gameObject);

    }

  
}
