using System;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public GameObject towerPrefab;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var mousePos = Input.mousePosition;
            var ray = cam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out var hit))
            {
                var obj = Instantiate(towerPrefab, hit.point, Quaternion.identity);
                obj.transform.up = Vector3.Lerp(hit.normal,Vector3.up, 0.5f);
            }
        }
    }
}
