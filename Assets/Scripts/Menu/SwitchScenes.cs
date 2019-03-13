using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void SceneLoad(int scenenumber)
    {
        SceneManager.LoadSceneAsync(scenenumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
