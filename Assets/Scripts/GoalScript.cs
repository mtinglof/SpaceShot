using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject hud; 
    private HUDScript hudControl; 
    public GameObject[] explosions; 
    public GameObject ball; 

    void Start()
    {
        hudControl = hud.GetComponent<HUDScript>();  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CannonBall")
        {
            BallScript stats = other.GetComponent<BallScript>(); 
            stats.TotalScore(); 
            hudControl.GetBall(stats); 
            Destroy(other.gameObject); 
            GameObject toInstantiate = explosions[Random.Range(0, explosions.Length)]; 
            GameObject instance = Instantiate(toInstantiate) as GameObject; 
            return; 
        }
    }
}
