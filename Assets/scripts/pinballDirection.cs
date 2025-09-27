using UnityEngine;

public class pinballDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RotateDir", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RotateDir()
    //can i preserve this even when i reload the scene?
    {
        transform.Rotate(0,0,45);
    }
}
