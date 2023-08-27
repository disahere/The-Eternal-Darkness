using UnityEngine;

namespace CodeBase.World
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform destination;

        public Transform GetDestination()
        {
            return destination;
        }
    }
}