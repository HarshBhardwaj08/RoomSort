using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayPanel : MonoBehaviour
{
    public SoundManager soundManager;
    public CanvasManager gameManager;
    public SettingsPanel settingpanel;
    public PausePanel pausepanel;
    public TMP_Text currentlevelNumber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        currentlevelNumber.text = currentLevel.ToString();
    }

    public void OpenSettingPanel()
    {
        soundManager.PlayClickSound();
        gameManager.CloseAllPanels();
        settingpanel.gameObject.SetActive(true);
    }
    public void OpenPausePanel()
    {
        soundManager.PlayClickSound();
        gameManager.CloseAllPanels();
        pausepanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
