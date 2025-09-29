using UnityEngine;
using UnityEngine.SceneManagement;
//SOURCES:
//ROTATION OF BALL: https://www.youtube.com/watch?v=0gzakhQgptI



public class bouncyBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myBody;
    //use this to determine speed:
    Vector2 previousPosition;
    
    //declare spawn location and info here
    public Vector3 spawnLocationBall;
    public Vector3 spawnLocationTrig;
    public bool readyRespawn;
    public int timer = 0;
    
    //declare player /launcher so that we can spawn it later
    public GameObject ballPrefab;
    public GameObject launcherOutline;
    
    [SerializeField] private pinballManager myManager;
    
    public ParticleSystem cheeseParticles;
    public ParticleSystem grapeParticles;
    
    public AudioSource audioSource;
    public AudioClip grapeSound;
    public AudioClip flipperSound;
    public AudioClip thumpSound;
    public AudioClip wooshSound;
    public AudioClip honeySound;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn launcher and player
        //this would access the rigidbody component of the object
        //myBody = GetComponent<Rigidbody2D>();
        spawnLocationBall = new Vector3(-0.168f, -3.45f, -0.03f);
        spawnLocationTrig = new Vector3(2.154f, -0.118f, 0);
        readyRespawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //myBody.linearDamping = 1.3f;
        // //this will allow the ball to rotate on the axis that is perpendicular
        // //to the direction it is facing
        // Vector2 position = new Vector2(transform.position.x, transform.position.y);
        // Vector2 speed = position - previousPosition;
        // Vector2 rotationAxis = Vector2.Perpendicular(speed);
        // if (speed.sqrMagnitude > 3f)
        // {
        //     transform.Rotate(new Vector3(rotationAxis.x, rotationAxis.y, 0), -speed.magnitude * 40f, Space.World);
        // }
        //
        // previousPosition = transform.position;
        if (readyRespawn)
        {
            //RespawnBall();
            //launcher.readyLaunch = true;
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bumper":
                Instantiate(cheeseParticles, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(thumpSound);
                myManager.AddScore("3");
                myBody.AddForce(collision.GetContact(0).normal * 1, ForceMode2D.Impulse);
                break;
            case "wall":
                //code
            case "grapes":
                Instantiate(grapeParticles, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(grapeSound);
                myBody.AddForce(collision.GetContact(0).normal * 1, ForceMode2D.Impulse);
                myManager.AddScore("2");
                break;
            case "melon":
                audioSource.PlayOneShot(thumpSound);
                myBody.AddForce(collision.GetContact(0).normal * 1);
                myManager.AddScore("1");
                break;
            case "pom":
                audioSource.PlayOneShot(grapeSound);
                myManager.AddScore("ultimate");
                break;
            
            default:
                break;
        }
    }

    void spawnStuff()
    {
        if (ballPrefab != null)
        {
            Instantiate(launcherOutline, spawnLocationBall, Quaternion.identity);
            Instantiate(ballPrefab, spawnLocationTrig, Quaternion.identity);
        }
        else
        {
            print("Player prefab not found");
        }
    }
    
    void OnTriggerEnter2D(Collider2D triggerCol)
    {
        switch (triggerCol.gameObject.tag)
        {
            case "deathBlock":
                readyRespawn = true;
                break;
            case "changeDir":
                myBody.linearVelocity = (Vector2)triggerCol.gameObject.transform.up * 1;
                break;
            case "honey":
                audioSource.PlayOneShot(honeySound);
                if (myBody.linearVelocity.y < 0)
                {
                    myBody.linearDamping = 30f;
                }
                break;
                
            default:
                print("trigger enter function not working in the ball object");
                break;
        }
       

        

        
    }

    void OnTriggerExit2D(Collider2D launcherCol)
    {
        if (launcherCol.gameObject.tag == "launcherTrigger")
        {
            audioSource.PlayOneShot(wooshSound);
            Destroy(launcherOutline);
            
        }

        if (launcherCol.gameObject.tag == "honey")
        {
            myBody.linearDamping = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "flipper":
                audioSource.PlayOneShot(flipperSound);
                break;
        }
    }
    
    
    
    

    void RespawnBall()
    {
            timer++;
            if (timer > 300)
            {
                //stop it from moving
                myBody.bodyType = RigidbodyType2D.Static;
                transform.position = spawnLocationBall;
                //myBody.linearVelocity = Vector2.zero;
                //myBody.rotation = 0;
                readyRespawn = false;
                timer = 0;
            }
        //Time.timeScale = 0; if deaths == 3
       
    }
    
}
