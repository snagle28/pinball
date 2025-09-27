using Unity.VisualScripting;
using UnityEngine;

public class pinballFlipper : MonoBehaviour
{


    [SerializeField] private KeyCode flipKey;

    [SerializeField] private Rigidbody2D myBody;

    [SerializeField] private float flipPower;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(flipKey))
        {
            myBody.AddForce(transform.up * flipPower);
        }
    }
}
