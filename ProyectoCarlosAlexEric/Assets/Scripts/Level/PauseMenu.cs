using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private Button[] buttons;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        ShowMenu(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            ShowMenu(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        ShowMenu(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    private void ShowMenu(bool show)
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(show);
        }
    }
}
