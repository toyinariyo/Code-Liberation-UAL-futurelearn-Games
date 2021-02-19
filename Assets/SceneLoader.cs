using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Gets current active scene (main menu: scene 0) and 
                                                                              //increments it by 1 and loads it (star clicker game: scene 1)
    }

    public void QuitGame()
    {
        Application.Quit(); //fucking obvious code comment - quits game
        Debug.Log("Quit the game!");
    }
}
