using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public string firstLevelScene;

    public void LoadFirstLevelScene()
    {
        SceneManager.LoadScene(firstLevelScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
