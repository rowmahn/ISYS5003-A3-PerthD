using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManageScript : MonoBehaviour
{
    public void quitScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }
}
