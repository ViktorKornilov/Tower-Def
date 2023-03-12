using System;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public TowerData towerData;

    public static Placer instance;

    [Header("References")]
    [SerializeField]private MeshFilter mf;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private Material legitMaterial;
    [SerializeField] private Material invalidMaterial;
    
    private Camera cam;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
        UpdateData(towerData);
    }

    public void UpdateData(TowerData data)
    {
        mf.sharedMesh = data.prefab.GetComponent<MeshFilter>().sharedMesh;
        towerData = data;
    }

    private void Update()
    {
        if (towerData == null) return;
        
            var mousePos = Input.mousePosition;
            var ray = cam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out var hit))
            {
                var canPlace = hit.collider.CompareTag("Ground");
                mr.material = canPlace ? legitMaterial : invalidMaterial;
            }


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(towerData.prefab, transform.position, Quaternion.identity);
                towerData = null;
                mf.sharedMesh = null;
            }

    }
}
