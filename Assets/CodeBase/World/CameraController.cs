using UnityEngine;

namespace CodeBase.World
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        private const float CameraLerp = 5.0f;
        private float _cameraZPosition;

        private void Start()
        {
            _cameraZPosition = transform.position.z;
        }

        public void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * CameraLerp);
            transform.position = new Vector3(transform.position.x, transform.position.y, _cameraZPosition);
        }
    }
}