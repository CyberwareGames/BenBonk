using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject Ins;
    void Start()
    {
        Ins.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShowIns()
    {
        Ins.SetActive(true);
    }
    public void HideIns()
    {
        Ins.SetActive(false);
    }

}
