using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Navigating the pause menu with the use of ESC
public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public AdvancedMovement movementScript;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    //Unpause game and set time back to normal
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        movementScript.enabled = true;
        isPaused = false;
    }

    //Pause the game and stop time
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        movementScript.enabled = false;
        isPaused = true;
    }

    //unpause game if it's paused before returning to menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //Unpause game and reload scene
    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        movementScript.enabled = true;
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
