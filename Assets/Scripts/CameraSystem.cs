using System;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private Camera cam;
    public float scrollSpeed = 20;

    [Range(0f,1f)]public float zoom;
    public float minZoom = 5;
    public float maxZoom = 20;
    public float zoomSpeed = 5;
    public float zoomSmoothness = 0.9f;

    private float targetFOV;
    
    private void Start()
    {
        cam = Camera.main;
        targetFOV = cam.fieldOfView;
    }

    private void LateUpdate()
    {
        var input = cam.ScreenToViewportPoint(Input.mousePosition);
        var scrollDir = Vector3.zero;
        
        if (input.x < 0.1f) scrollDir.x = -1;
        if (input.x > 0.9f) scrollDir.x = 1;
        if (input.y < 0.1f) scrollDir.z = -1;
        if (input.y > 0.9f) scrollDir.z = 1;
        scrollDir.Normalize();

        transform.position += scrollDir * scrollSpeed * Time.deltaTime;
        
        // zoom
        var wheelDir = Input.mouseScrollDelta.y;
        zoom += wheelDir * zoomSpeed * Time.deltaTime;
        zoom = Mathf.Clamp01(zoom);

        targetFOV = Mathf.Lerp(minZoom, maxZoom, zoom);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, 1 - zoomSmoothness);
    }
}
