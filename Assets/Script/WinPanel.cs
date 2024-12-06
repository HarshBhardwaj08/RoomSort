using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public CanvasManager gameManager;
    private int currentLevel;
    public SoundManager soundManager;
    void Start()
    {   
        gameManager = GetComponentInParent<CanvasManager>();
        soundManager.PlayWinSound();
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }
    public void OnWin()
    {
        soundManager.PlayClickSound();
        currentLevel++;
        if (currentLevel > gameManager.totalLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene(currentLevel);
        gameObject.SetActive(false);
    }
}
