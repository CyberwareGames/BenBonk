using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public static int EnemyCount;
    public static int Kills;
    public static double Coins;
    public static int WaveNum;
    void Start()
    {
        WaveNum = 1;
        Kills = 0;
        Coins = 0;
        EnemyCount = 7;
    }

    void Update()
    {
        if(EnemyCount < 2)
        {
            WaveNum++;
            Instantiate(enemy, new Vector3(Random.Range(-135f, -88f), 28f), Quaternion.identity);
            Instantiate(enemy, new Vector3(Random.Range(-135f, -88f), 28f), Quaternion.identity);
            Instantiate(enemy, new Vector3(Random.Range(-135f, -88f), 28f), Quaternion.identity);
            Instantiate(enemy, new Vector3(Random.Range(-135f, -88f), 28f), Quaternion.identity);
            EnemyCount += 4;
        }
    }
}
