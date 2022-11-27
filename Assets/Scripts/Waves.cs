using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float wave;
    public GameObject Enemy;
    private float EnemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && wave == 0)
        {
            wave++;
        } 
        if(wave == 1 && EnemyCount <= 5)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            EnemyCount++;
        }
    }
}
