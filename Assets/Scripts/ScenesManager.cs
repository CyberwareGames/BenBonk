using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public AudioSource Click;

    void Start()
    {
        Time.timeScale = 1f;
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayClick()
    {
        Click.Play();
    }
}
