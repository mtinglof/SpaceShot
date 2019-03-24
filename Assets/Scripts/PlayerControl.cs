using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables; 
using System; 

public class PlayerControl : MonoBehaviour
{
    public GameObject player; 
    public GameObject wheel; 
    public GameObject ballSpawn;
    public GameObject hud;  
    private GameObject cannonBallclone;
    public GameObject cannonBall;   
    public Rigidbody2D cannon;  
    private HUDScript hudControl;  
    private BallScript ballControl; 
    public AudioClip smallBoom; 
    public AudioClip mediumBoom; 
    public AudioClip largeBoom; 
    public AudioSource MusicSource; 
    public GameObject instructionsHolder;
    private GameObject instructions;  
    
    public int power = 50; 
    private int fireRatio = 4;   
    private int screenLeft = 1; 
    private int screenRight = 78; 
    private float speed = 15f; 
    private float rotation = 50f; 
    private float cannonRotation = 300f; 
    private float minRotation = 50f; 
    private float acceleration = 10f; 
    private float deaccerlate = 20f; 
    private int fireRate = 1; 
    private float lastShot; 

    private bool goingLeft = false; 
    private bool goingRight = false; 
    private bool menuOpen = false; 
    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time; 
        hudControl = hud.GetComponent<HUDScript>(); 
    }

    void GetInstructions()
    {
        if(!menuOpen)
            {
                instructions = Instantiate(instructionsHolder) as GameObject; 
                menuOpen = true; 
            }
        else
            {
                Destroy(instructions); 
                menuOpen = false; 
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get cannon starting coordinates 
        Vector3 pos = transform.position; 
        float wheelRotation = wheel.transform.rotation.eulerAngles.z; 
        float bodyRotation = player.transform.rotation.eulerAngles.z; 

        //Cannon Movement to the right 
        if(Input.GetKey(KeyCode.RightArrow))
        {
            cannon.AddForce(transform.right*speed); 
            wheelRotation -= rotation*Time.deltaTime;
            rotation += acceleration;  
            goingLeft = false; 
            goingRight = true; 
            wheel.transform.rotation = Quaternion.Euler(0, 0, wheelRotation);
        }

        //Cannon Movement to the left
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            cannon.AddForce(-transform.right*speed); 
            wheelRotation += rotation*Time.deltaTime;
            rotation += acceleration;  
            goingLeft = true; 
            goingRight = false; 
            wheel.transform.rotation = Quaternion.Euler(0, 0, wheelRotation);
        }

        //rotation of cannon body 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            bodyRotation += cannonRotation*Time.deltaTime; 
            player.transform.rotation = Quaternion.Euler(0, 0, bodyRotation);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            bodyRotation -= cannonRotation*Time.deltaTime; 
            player.transform.rotation = Quaternion.Euler(0, 0, bodyRotation);
        }

        //fire the cannon
        if(Input.GetKey(KeyCode.Space) && (Time.time > fireRate + lastShot))
        {
            cannonBallclone = Instantiate(cannonBall, ballSpawn.transform.position, transform.rotation) as GameObject; 
            Rigidbody2D cannonBallbody = cannonBallclone.GetComponent<Rigidbody2D>(); 
            BallScript ballControl = cannonBallclone.GetComponent<BallScript>(); 
            Vector3 velocity = cannon.velocity; 
            ballControl.SetStats(power, Math.Abs(pos.y-2), Time.time, 80-(float)pos.x, Math.Abs(velocity.x)); 
            lastShot = Time.time; 
            cannon.AddForce(-transform.right*(power/4), ForceMode2D.Impulse); 
            cannonBallbody.AddForce(transform.right*power*fireRatio, ForceMode2D.Impulse); 
            if(power<25)
            {
                MusicSource.clip = smallBoom; 
                MusicSource.Play(); 
            }
            else if(power > 24 && power < 75)
            {
                MusicSource.clip = mediumBoom; 
                MusicSource.Play();  
            }
            else
            {
                MusicSource.clip = largeBoom; 
                MusicSource.Play();  
            }
        }

        //increase and decrease cannon power 
        if(Input.GetKey(KeyCode.A))
        {
            power = hudControl.changePower(-1); 
        }
        if(Input.GetKey(KeyCode.D))
        {
            power = hudControl.changePower(1); 
        }

        //prevents cannon from coming off screen
        if (pos.x < screenLeft)
        {
            pos.x = screenLeft; 
            wheelRotation = wheel.transform.rotation.eulerAngles.z; 
        }
        if (pos.x > screenRight)
        {
            pos.x = screenRight;
            wheelRotation = wheel.transform.rotation.eulerAngles.z; 
        }
        transform.position = pos; 

        //deaccerlate wheel rotation 
        if(rotation > minRotation && !Input.anyKey)
        {
            if(goingLeft)
            {
                wheelRotation += rotation*Time.deltaTime;
                wheel.transform.rotation = Quaternion.Euler(0, 0, wheelRotation);
                rotation -= deaccerlate;
            }
           if(goingRight)
           {
                wheelRotation -= rotation*Time.deltaTime;
                wheel.transform.rotation = Quaternion.Euler(0, 0, wheelRotation);
                rotation -= deaccerlate; 
           }
        }
        
        //opens instructions menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetInstructions(); 
        }
    }
}
