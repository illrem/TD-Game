using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Called the play function by creating a play method
    public void PlayGame()
    {
        //Loading the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // The Scene to Continue
    private int sceneToContinue;

    //Continue the game
    public void ContinueGame() {

        // The scene that continues to the Saved Scene
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        //Loads the Saved Scene
        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;

    }
    
    //Called the quit function by creating a quit method
    public void QuitGame()
    {
        //Quitting the game
        Debug.Log("Quit");
        Application.Quit();
    }
}
