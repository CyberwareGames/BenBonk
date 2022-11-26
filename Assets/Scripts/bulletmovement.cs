using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bulletmovement : MonoBehaviour
{
    private float bulletspeed = -100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletspeed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
