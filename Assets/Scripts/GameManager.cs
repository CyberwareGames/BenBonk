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
    public GameObject Wave7;
    public GameObject Wave8;
    public GameObject Wave9;

    public static int Kills;
    public static double Coins;
    public static int WaveNum;

    public GameObject LosePanel;
    void Start()
    {
        Time.timeScale = 1f;
        LosePanel.SetActive(false);
        Wave1.SetActive(false);
        Wave2.SetActive(false);
        Wave3.SetActive(false);
        Wave4.SetActive(false);
        Wave5.SetActive(false);
        Wave6.SetActive(false);
        Wave7.SetActive(false);
        Wave8.SetActive(false);
        Wave9.SetActive(false);
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
                if (Kills >= 8)
                    WaveNum++;
                break;
            case 2:
                Wave2.SetActive(true);
                if (Kills >= 18)
                    WaveNum++;
                break;
            case 3:
                Wave3.SetActive(true);
                if (Kills >= 28)
                    WaveNum++;
                break;
            case 4:
                Wave4.SetActive(true);
                if (Kills >= 38)
                    WaveNum++;
                break;
            case 5:
                Wave5.SetActive(true);
                if (Kills >= 48)
                    WaveNum++;
                break;
            case 6:
                Wave6.SetActive(true);
                if (Kills >= 58)
                    WaveNum++;
                break;
            case 7:
                Wave7.SetActive(true);
                if (Kills >= 78)
                    WaveNum++;
                break;
            case 8:
                Wave8.SetActive(true);
                if (Kills >= 98)
                    WaveNum++;
                break;
            case 9:
                Wave9.SetActive(true);
                if(Kills >= 100)
                    LosePanel.SetActive(true);
                break;
        }
    }
}
