using UnityEngine;

public class launcher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myBody;
    private bool readyLaunch = true;
    private float force = 20;
    private float forceMax = 30;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this would access the rigidbody component of the object
        //myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (readyLaunch)
        {
            launchBall();
        }
       
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "leftRamp":
                myBody.AddForce(transform.right * -2);
                break;
            case "rightRamp":
                myBody.AddForce(transform.up * 2);
                break;
        }
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("accelerator"))
    //     {
    //         print("should acc");
    //         myBody.AddForce(transform.up * 3);
    //         
    //         //won't launch again until it falls through, fix this later
    //     }
    // }

    void OnTriggerExit2D(Collider2D triggerCollider)
    {
        if (triggerCollider.gameObject.CompareTag("deathBlock"))
        {
            readyLaunch = true;
            print("ready to launch");
        }
        if (triggerCollider.gameObject.CompareTag("launcherTrigger"))
        {
            readyLaunch = false;
            print("Can't launch");
        }
    }
    
    
//SET BLOCKS FOR THESE ACCELERATORS

    void launchBall()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (force < forceMax)
            {
                force += 0.5f;
            }
        }
            
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (force < forceMax)
            {
                force += 0.1f;
            }
        }
            
        

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            myBody.bodyType = RigidbodyType2D.Dynamic;

            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                myBody.AddForce(transform.right * force, ForceMode2D.Impulse);
                
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                myBody.AddForce(transform.right * -force, ForceMode2D.Impulse);
            }
            
        }

        //force = 0f;

    }
}
