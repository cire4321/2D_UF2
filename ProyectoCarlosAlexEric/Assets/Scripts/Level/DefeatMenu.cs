using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Candyland");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
