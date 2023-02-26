using UnityEngine;

public class RockPlacer : MonoBehaviour
{
    public GameObject[] prefabs;
    public float stepSize = 5;
    public float offsetSize = 1;

    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        var size = renderer.bounds;

        for (float step = size.min.x; step < size.max.x; step+=stepSize)
        {
            var pos = new Vector3(step, 0, renderer.bounds.max.z);
            Place(pos);
            
            pos = new Vector3(step, 0, renderer.bounds.min.z);
            Place(pos);
            
            pos = new Vector3(renderer.bounds.min.x, 0, step);
            Place(pos);
            
            pos = new Vector3(renderer.bounds.max.x, 0, step);
            Place(pos);
        }
    }

    public void Place(Vector3 position)
    {
        var prefab = Choose(prefabs);
        var pos = position;
        
        var offset =  Random.insideUnitSphere * offsetSize;
        offset.y = 0;
        pos += offset;
        
        var angle = Random.Range(0f, 360f);
        var rot = Quaternion.Euler(0, angle, 0);
            
        Instantiate(prefab, pos, rot);
    }

    GameObject Choose(GameObject[] list) => list[Random.Range(0, list.Length)];
}
