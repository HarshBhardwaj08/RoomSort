using UnityEngine;
using UnityEngine.SceneManagement;

public class LostPanel : MonoBehaviour
{
    public SoundManager soundManager;
    private int currentLevel;
    void Start()
    {
        soundManager.PlayLostSound();
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    public void OnRestart()
    {
        soundManager.PlayClickSound();
        SceneManager.LoadScene(currentLevel);
        gameObject.SetActive(false);
    }
}
