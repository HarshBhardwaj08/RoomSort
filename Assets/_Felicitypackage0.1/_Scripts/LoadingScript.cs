using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(waitforscene());
    }

    
    IEnumerator waitforscene()
    {
        SceneManager.LoadScene(1);
        yield return new WaitForSeconds(1f);
    }
}
