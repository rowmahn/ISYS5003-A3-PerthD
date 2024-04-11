using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject creditPage;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CreditPageLoader()
    {
        creditPage.SetActive(true);
    }

    public void CreditPageExit()
    {
        creditPage.SetActive(false);
    }
}
