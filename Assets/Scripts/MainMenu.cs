using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu, optionsMenu, controlsMenu, startMenu, optionsStartMenu;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf && !optionsMenu.activeSelf)
        {
            PauseMenu();
        }
    }

    public void OptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void OptionsStartMenu()
    {
        startMenu.SetActive(false);
        optionsStartMenu.SetActive(true);
    }
    public void ControlsMenu()
    {
        controlsMenu.SetActive(true);
        startMenu.SetActive(false);
    }
    public void BackStart()
    {
        startMenu.SetActive(true);
        optionsStartMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
