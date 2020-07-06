using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update of the escape key showing the main menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //This resumes the level of the game the player is currently playing
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pauses the game
    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Shows the current scene
    private int currentSceneIndex;

    //Shows the Load Menu being loaded
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        WaveSpawner.Currentwave = "0";
        //Saved the last saved level the user has played
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        //Loads Menu Screen
        SceneManager.LoadScene("Menu");
    }

    //The user will be able to quit the game
    public void QuitGame() 
    {
        Debug.Log("Quitting Game....");
        Application.Quit();
    }
}
