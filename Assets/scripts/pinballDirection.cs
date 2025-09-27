using UnityEngine;

public class pinballDirection : MonoBehaviour
{
    private float minAngle = -90f;
    private float maxAngle = 180f;
    private float currentAngle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAngle= transform.eulerAngles.z;
        //InvokeRepeating("RotateDir", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float targetAngle = Mathf.Lerp(minAngle, maxAngle, Mathf.PingPong(Time.time, 1f));
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * 3f);
        transform.rotation = Quaternion.Euler(0,0,currentAngle);
    }

    void RotateDir()
    //can i preserve this even when i reload the scene?
    {
        
        // float targetAngle = Mathf.Lerp(minAngle, maxAngle, Mathf.PingPong(Time.time, 1f));
        // currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * 3f);
        // transform.rotation = Quaternion.Euler(0,0,currentAngle);
    }
}
