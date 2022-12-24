using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public float speed;
    public int startPoint;
    public Transform[] points;

    private int i;
    void Start()
    {
        transform.position = points[startPoint].position;
    }
    void Update()
    {
        Debug.Log(i);
        if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Gems++;
            Destroy(gameObject);
        }
    }

}
