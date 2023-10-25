using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu, optionsMenu, controlsMenu, startMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            PauseMenu();
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


    public void BackMainMenu()
    {
        StartCoroutine(LoadSceneWithDelay("Menu_Scene", 0.3f));
        Time.timeScale = 1;
    }

    public void OptionsMenu()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ControlsMenu()
    {
        controlsMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
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
        StartCoroutine(LoadSceneWithDelay("Scene_01", 0.3f));
        // startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
