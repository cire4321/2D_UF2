using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private Button[] buttons;
    public GameObject container;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();//Busca los botones hijos de este gameObject
        
        ShowMenu(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))//Si se apreta la tecla "Esc", se abre este menú
        {
            ShowMenu(true);

            //Time.timeScale = 0f;//Al abrir este menú se para el juego
        }
    }

    public void Resume()//Se reanuda el juego
    {
        //Time.timeScale = 1f;
        ShowMenu(false);

    }

    private void ShowMenu(bool show)//Función q en el caso de ser true, muestra el menú de pausa
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(show);
        }
        container.SetActive(show);
    }

    public void Exit()//Sale del juego
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
