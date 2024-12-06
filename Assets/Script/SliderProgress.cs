using System.ComponentModel;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderProgress : MonoBehaviour
{
    public Slider slider;
    public TMP_Text percentageText;
    
    public float fillDuration = 2f; // Duration to fill the slider from 0 to 100

    private void Start()
    {
        slider.value = 0;
     
        StartCoroutine(UpdateSlider());
    }

    private System.Collections.IEnumerator UpdateSlider()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / fillDuration);
            slider.value = progress;
            percentageText.text = progress*100f + "%";
            yield return null;
        }

        slider.value = 100;
        percentageText.text = "100%";
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        SceneManager.LoadScene(currentLevel != 0 ? currentLevel : 1);
    }
}
