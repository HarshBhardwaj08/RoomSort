using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;


public class UI : MonoBehaviour
{
    // public Sprite Gameicon;
    public GameObject GamePanel, VictoryPanel, DefeatPanel, PausePanel;
    public TMP_Text[] Levelnumber;
    public int TotalLevels = 5;
   
    // public string GameName;
    //  public GameObject GameiconObject;
    //  public TMP_Text GameNametxt;
    private void Awake()
    {
        //  GameiconObject.GetComponent<Image>().sprite = Gameicon;
        //  GameNametxt.text = GameName;
      //  SetLevelNumber("Level : ", PlayerPrefs.GetInt("LevelNumber"));
    }
    private void OnEnable()
    {
        GameManager.GameVictory +=  OpenVictoryPanel;
    }
    private void OnDisable()
    {
        GameManager.GameVictory -= OpenVictoryPanel;
    }
    void Start()
    {
        Time.timeScale = 1f;
        // MenuPanel.SetActive(true);
        GamePanel.SetActive(true);
        VictoryPanel.SetActive(false); DefeatPanel.SetActive(false);
        PausePanel.SetActive(false); 


    }

    public void closepausepanel()
    {
        Debug.Log("Unpause");
        GamePanel.transform.localScale = new Vector3(0, 0, 0);
        GamePanel.SetActive(true);
        PausePanel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        GamePanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        StartCoroutine(WaitforTimescale1());
    }

    public void openpausepanel()
    {
        PausePanel.transform.localScale = new Vector3(0, 0, 0);
        PausePanel.SetActive(true);
        GamePanel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        PausePanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        StartCoroutine(WaitforTimescale0());

    }

   

    IEnumerator WaitforTimescale0()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
    }
    IEnumerator WaitforTimescale1()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
    }
    public void OpenDefeatPanel()
    {
        DefeatPanel.transform.localScale = new Vector3(0, 0, 0);
        DefeatPanel.SetActive(true);
        GamePanel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        DefeatPanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);

    }
    public void OpenVictoryPanel()
    {
        VictoryPanel.transform.localScale = new Vector3(0, 0, 0);
        VictoryPanel.SetActive(true);
        GamePanel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        VictoryPanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    public void SetLevelNumber(string Leveltext, int levelnumber)
    {
        foreach (TMP_Text level in Levelnumber)
        {

            level.text = Leveltext + levelnumber;
        }
    }

    public void nextlvlbtn()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 0 && SceneManager.GetActiveScene().buildIndex < TotalLevels)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void retrylvlbtn()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        
    }

}
