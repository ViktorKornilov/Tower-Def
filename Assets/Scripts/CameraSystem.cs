using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public float speed = 10;
    
    private void Update()
    {
        var input = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0,
            z = Input.GetAxisRaw("Vertical")
        };

        transform.position += input * speed * Time.deltaTime;
        
        //Screen.width
        // Input.mousePosition
        
        
        // scrollwheel ir transform forward
        // min max apribojimai
        // smooth
        
        // tower place preview 
        // red 
        
        
    }
}
