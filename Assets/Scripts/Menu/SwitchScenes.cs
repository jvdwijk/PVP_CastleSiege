using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void SceneLoad(int Scenenumber)
    {
        SceneManager.LoadSceneAsync(Scenenumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
