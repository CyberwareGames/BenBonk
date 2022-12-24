using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public AudioSource Thunder;
    private int lives;
    public GameObject House1;
    public GameObject House2;
    public GameObject Flash;
    void Start()
    {
        lives = 3;
        House1.SetActive(true);
        House2.SetActive(true);
        Flash.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Thunder.Play();
            Destroy(collision.gameObject);
            Flash.SetActive(true);
            Invoke("Unflash", 0.16f);
            lives--;
            if(lives <= 2)
                House1.SetActive(false);
            if(lives <= 1)
                House2.SetActive(false);
            if(lives <= 0)
            {
                FindObjectOfType<GameManager>().LosePanel.SetActive(true);
                PlayerPrefs.SetInt("Gems", GameManager.Gems);
                Upgrades.PierceCounter = 1;
                Upgrades.FireRateCounter = 1;
                Upgrades.DamageCounter = 1;
                Upgrades.ExtraBulletCounter = 1;
                Time.timeScale = 0f;
            }
            
        }
    }

    void Unflash()
    {
        Flash.SetActive(false);
    }
}
