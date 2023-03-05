using System;
using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    private Camera cam;
    public LayerMask mask;

    private void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        var pos = Input.mousePosition;
        var ray = cam.ScreenPointToRay(pos);

        if (Physics.Raycast(ray,out var hit,100,mask))
        {
            transform.position = hit.point;
        }
    }
}
