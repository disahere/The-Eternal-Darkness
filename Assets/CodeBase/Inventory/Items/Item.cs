using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Inventory.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
    public class Item : ScriptableObject
    {
        [FormerlySerializedAs("Prefab")] public GameObject prefab;
        private new string name = "New Item";
        private Sprite icon = null;
        private int _number = 8;
    }
}