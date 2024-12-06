using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public Toggle soundToggle;
    public SoundManager soundManager;
    public Button closeBtn;

    void Start()
    {
        bool isSoundOn = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        soundToggle.isOn = isSoundOn;
        soundManager.SetSound(isSoundOn);
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        closeBtn.onClick.AddListener(() =>
        {
            soundManager.PlayClickSound();
            gameObject.SetActive(false);
        });
    }

    void OnSoundToggleChanged(bool isOn)
    {
        soundManager.PlayClickSound();
        soundManager.SetSound(isOn);
        PlayerPrefs.SetInt("SoundEnabled", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
