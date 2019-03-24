using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(1); 
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    public void Options()
    {
        SceneManager.LoadScene(2); 
    }
    public void Credits()
    {
        SceneManager.LoadScene(3); 
    }
    public void Back() 
    {
        SceneManager.LoadScene(0); 
    }
}
