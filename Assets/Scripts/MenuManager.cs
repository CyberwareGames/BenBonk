using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Gems;
    void Start()
    {
        Gems.text = "Gems: " + PlayerPrefs.GetInt("Gems", 0).ToString();
    }

    void Update()
    {
        
    }
}
