using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI WaveText;
    public TMPro.TextMeshProUGUI KillsText;
    public TMPro.TextMeshProUGUI CoinsText;
    public TMPro.TextMeshProUGUI Gems;

    void Start()
    {
        
    }

    void Update()
    {
        WaveText.text = "Wave: " + GameManager.WaveNum;
        KillsText.text = "Kills: " + GameManager.Kills;
        CoinsText.text = "Coins: $" + GameManager.Coins;
        Gems.text = "Gems: " + GameManager.Gems;
        
    }


    public void ReturnToMenu()
    {
        PlayerPrefs.SetInt("Gems", GameManager.Gems);
        SceneManager.LoadScene(0);
    }
    public void RestartScene()
    {
        PlayerPrefs.SetInt("Gems", GameManager.Gems);
        SceneManager.LoadScene(1);
    }
}
