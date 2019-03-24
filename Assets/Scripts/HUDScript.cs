using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System; 

public class HUDScript : MonoBehaviour
{
    public int power; 
    private float score; 
    private int maxPower = 100; 
    private int minPower = 1;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerScore; 
    private float powerStat; 
    public TextMeshProUGUI airScore; 
    private float airStat; 
    public TextMeshProUGUI hangScore; 
    private float hangStat; 
    public TextMeshProUGUI distanceScore; 
    private float distanceStat; 
    public TextMeshProUGUI moveScore; 
    private float moveStat; 
    public TextMeshProUGUI totalScore; 
    private float totalStat; 
    private BallScript ballStats; 
    // Start is called before the first frame update
    void Start()
    {
        WipeScore(); 
        power = 50; 
        score = 0f; 
        powerText.text = "Power: " + power.ToString(); 
        scoreText.text = "HighScore: " + score.ToString(); 
    }

    public void changeScore()
    {
        if(totalStat > score)
        {
            scoreText.text = "HighScore: " + totalStat.ToString(); 
            score = totalStat; 
        }
    }

    public int changePower(int change)
    {
        power += change;  
        if(power>maxPower)
        {
            power=maxPower;
        }
        if(power<minPower)
        {
            power=minPower;
        }
        powerText.text = "Power: " + power.ToString(); 
        return(power); 
    }

    public void GetBall(BallScript ball)
    {
        ballStats = ball; 
        DisplayScore(); 
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds (6f);
        WipeScore(); 
    }
    private void DisplayScore()
    {
        powerStat = Mathf.Round(ballStats.GetPower()); 
        airStat = Mathf.Round(ballStats.GetHeight()); 
        hangStat = Mathf.Round(ballStats.GetHang()); 
        distanceStat = Mathf.Round(ballStats.GetDistance()); 
        moveStat = Mathf.Round(ballStats.GetSpeed()); 
        totalStat = Mathf.Round(ballStats.TotalScore()); 
        powerScore.text = "Power: " + powerStat.ToString(); 
        airScore.text = "Vertical: " + airStat.ToString(); 
        hangScore.text = "Hangtime: " + hangStat.ToString(); 
        distanceScore.text = "Distance: " + distanceStat.ToString(); 
        moveScore.text = "Movement: " + moveStat.ToString();
        totalScore.text = "Total: " + totalStat.ToString();  
        changeScore(); 
        StartCoroutine(Wait());
    }

    private void WipeScore()
    {
        powerScore.text = " "; 
        airScore.text = " "; 
        hangScore.text = " "; 
        distanceScore.text = " "; 
        moveScore.text = " "; 
        totalScore.text = " "; 
    }
}
