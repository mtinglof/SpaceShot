using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager instance=null; 
    public BoardManager boardScript; 
    public AudioClip backgroundSound; 
    public AudioSource backgroundSource; 

    void Awake()
    {
        if(instance == null)
            instance = this; 
        else if(instance != this)
            Destroy(gameObject); 
        boardScript = GetComponent<BoardManager>(); 
        backgroundSource.clip = backgroundSound; 
        backgroundSource.Play(); 
        InitGame(); 
    }

    void InitGame()
    {
        boardScript.SetupScene(); 
    }

    public void GameOver()
    {
        enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
