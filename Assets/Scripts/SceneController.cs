using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string sceneName;

    public void ChangeScene(string sceneName)
    {
        this.sceneName = sceneName;
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }
}
