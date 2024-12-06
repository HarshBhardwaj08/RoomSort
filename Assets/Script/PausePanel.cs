using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public SoundManager soundManager;
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }
    void OnPlayButtonClicked()
    {
        soundManager.PlayClickSound();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    void OnQuitButtonClicked()
    {
        soundManager.PlayClickSound();
        gameObject.SetActive(false);
        Application.Quit();
    }
}
