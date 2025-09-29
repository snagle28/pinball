using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] private Transform ballTransform;
    [SerializeField] private float smoothVal;
    Vector3 velocity = Vector3.zero;
    private Vector3 newLoc;


    private Vector3 startPos;
    void Start()
    {
        startPos = ballTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = ballTransform.position;
        target.x = startPos.x;
        target.z = -10;
        

        //calculate minimum height of camera. if its higher than that, lerp normally, otherwise clamp to bottom of screen
        float minY = -3.8f;
        target.y = Mathf.Max(target.y, minY);
        // float minX = -1f;
        // float maxX = 1f;
        //target.x = Mathf.Clamp(target.x, minX, maxX);
        
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
        
        
        
        
    }
}
