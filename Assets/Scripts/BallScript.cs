using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject player;
    private PlayerControl playerScript; 
    public float power;
    public float height; 
    public float time; 
    public float distance; 
    public float speed;
    public float hang;  
    public float score; 

    public void SetStats(float power, float height, float time, float distance, float speed)
    {
        this.power = power; 
        this.height = height; 
        this.time = time; 
        this.distance = distance; 
        this.speed = speed; 
    }

    public float TotalScore()
    {
        score = GetPower() + GetHeight() + GetHang() + GetDistance() + GetSpeed(); 
        return(score);   
    }
    public float GetHang()
    {
        hang = (Time.time - time) * 10; 
        return(hang); 
    }
    public float GetHeight()
    {
        return(height*5); 
    }
    public float GetDistance()
    {
        return(float)(distance*1.3); 
    }
    public float GetSpeed()
    {
        return(speed*10);
    }
    public float GetPower()
    {
        return(power); 
    }
}