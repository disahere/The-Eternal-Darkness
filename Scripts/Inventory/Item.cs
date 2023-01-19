
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Items")]

public class Item : ScriptableObject
{
     public string name = "New Item";
     public Sprite icon = null;
     public GameObject Prefab;
     int number = 8 ;
}
