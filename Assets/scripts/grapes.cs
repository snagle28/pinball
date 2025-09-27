using UnityEngine;
//SOURCES = https://discussions.unity.com/t/add-force-in-direction-of-collision/251268
public class grapes : MonoBehaviour
{
    private Rigidbody2D rbGrapes;
    public int timer = 0;
    public GameObject myself;
    //declare spawn location here
    public Vector3 spawnLocation;
    public bool readyRespawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbGrapes = GetComponent<Rigidbody2D>();
        float xCoor = transform.position.x;
        float yCoor = transform.position.y;
        float zCoor = transform.position.z;
        spawnLocation = new Vector3(xCoor, yCoor, zCoor);
        readyRespawn = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyRespawn)
        {
            RespawnGrapes();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the object exists:
        
        
        switch (collision.gameObject.tag)
        {
            case "ball":
                //adds force at the point of contact, uses impulse to do this fast and immediately
                rbGrapes.bodyType = RigidbodyType2D.Dynamic;
                rbGrapes.AddForce(collision.GetContact(0).normal, ForceMode2D.Impulse);
                if (myself != null)
                {
                    print(timer);
                    readyRespawn = true;
                }
                break;
            case "bumper":
                rbGrapes.AddForce(collision.GetContact(0).normal, ForceMode2D.Impulse);
                break;
            case "flipper":
                rbGrapes.AddForce(collision.GetContact(0).normal,ForceMode2D.Impulse);
                break;
            case "wall":
                rbGrapes.AddForce(collision.GetContact(0).normal, ForceMode2D.Impulse);
                break;
            case "leftRamp":
                rbGrapes.AddForce(collision.GetContact(0).normal, ForceMode2D.Impulse);
                break;
            case "rightRamp":
                rbGrapes.AddForce(collision.GetContact(0).normal, ForceMode2D.Impulse);
                break;
            case "launcherCollider":
                rbGrapes.AddForce(collision.GetContact(0).normal, ForceMode2D.Impulse);
                break;
            default:
                break;
        }
    }

    void RespawnGrapes()
    {
        
        timer++;
        if (timer > 800)
        {
            
            transform.position = spawnLocation;
            rbGrapes.bodyType = RigidbodyType2D.Static;
            readyRespawn = false;
            timer = 0;
        }
    }
}
