using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject Wave4;
    public GameObject Wave5;
    public GameObject Wave6;


    public static int Kills;
    public static double Coins;
    public static int WaveNum;
    void Start()
    {
        Wave1.SetActive(false);
        Wave2.SetActive(false);
        Wave3.SetActive(false);
        Wave4.SetActive(false);
        Wave5.SetActive(false);
        Wave6.SetActive(false);
        WaveNum = 1;
        Kills = 0;
        Coins = 0;
    }

    void Update()
    {
        switch (WaveNum)
        {
            case 1:
                Wave1.SetActive(true);
                if (Kills >= 9)
                    WaveNum++;
                break;
            case 2:
                Wave2.SetActive(true);
                if (Kills >= 19)
                    WaveNum++;
                break;
            case 3:
                Wave3.SetActive(true);
                if (Kills >= 29)
                    WaveNum++;
                break;
            case 4:
                Wave4.SetActive(true);
                if (Kills >= 39)
                    WaveNum++;
                break;
            case 5:
                Wave5.SetActive(true);
                if (Kills >= 49)
                    WaveNum++;
                break;
            case 6:
                Wave6.SetActive(true);
                if (Kills >= 59)
                    WaveNum++;
                break;
        }
    }
}
