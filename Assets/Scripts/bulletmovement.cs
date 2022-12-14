using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float bulletSpeed = -240f;
    private int pierce = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground")
        {
            pierce++;
            if (pierce >= Upgrades.PierceCounter)
            {
                Destroy(gameObject);
            }
        }
    }
}
