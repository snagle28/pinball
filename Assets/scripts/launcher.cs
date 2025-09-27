using UnityEngine;

public class launcher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myBody;
    private bool readyLaunch = true;
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
                myBody.AddForce(transform.right * -10);
                break;
            case "rightRamp":
                myBody.AddForce(transform.up * 10);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("accelerator"))
        {
            print("should acc");
            myBody.AddForce(transform.up * 10);
            
            //won't launch again until it falls through, fix this later
        }
    }

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
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            myBody.bodyType = RigidbodyType2D.Dynamic;
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                myBody.AddForce(transform.right * -30, ForceMode2D.Impulse);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                myBody.AddForce(transform.right * 30, ForceMode2D.Impulse);
            }
        }
        
    }
}
