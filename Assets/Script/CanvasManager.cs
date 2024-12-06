using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public WinPanel winpanel;
    public LostPanel losepanel;
    public GameplayPanel gameplaypanel;
    public int totalLevel;
    private void OnEnable()
    {
        GameManager.ActivateWinPanel += OpenWinPanel;
    }
    private void OnDisable()
    {
        GameManager.ActivateWinPanel -= OpenWinPanel;
    }
    public void OpenWinPanel()
    {
        CloseAllPanels();
        StartCoroutine(EnableWinPanel(3.0f));
    }
    
    public void OpenLostPanel()
    {
        CloseAllPanels();
        losepanel.gameObject.SetActive(true);
    }

    public void CloseAllPanels()
    {
        gameplaypanel.settingpanel.gameObject.SetActive(false);
        gameplaypanel.pausepanel.gameObject.SetActive(false);
        winpanel.gameObject.SetActive(false);
        losepanel.gameObject.SetActive(false);
    }
    IEnumerator EnableWinPanel(float sec)
    {
        yield return new WaitForSeconds(sec);
        winpanel.gameObject.SetActive(true);
    }
}