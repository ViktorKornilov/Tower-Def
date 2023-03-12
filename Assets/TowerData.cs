using UnityEngine;

[CreateAssetMenu()]
public class TowerData : ScriptableObject
{
    public string title;
    public string description;
    public int price;
    public Sprite icon;
    public GameObject prefab;
}