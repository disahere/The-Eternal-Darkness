using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerMovement : MonoBehaviour 
    {
        [SerializeField] private AudioSource stepsSound;
        [SerializeField] public List<AudioClip> stepSounds;
        private BoxCollider2D _boxCollider;
        private Vector3 _moveDelta;
        private RaycastHit2D _hit;
        private Animator _myAnimator;

        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        public Joystick joystick;

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _myAnimator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            var x = joystick.Horizontal * 5;
            var y = joystick.Vertical * 4;

            if (x == 0 && y == 0)
            {
                x = Input.GetAxisRaw("Horizontal") * 5;
                y = Input.GetAxisRaw("Vertical") * 4;
            }

            var moving = (_moveDelta.magnitude > 0.5f);
            _myAnimator.SetBool(IsRunning, moving);

            _moveDelta = new Vector3(x, y, 0);

            if (!stepsSound.isPlaying && moving)
            {
                stepsSound.Play();
                AudioClip soundToPlay = stepSounds[Random.Range(0, stepSounds.Count)];
                stepsSound.clip = soundToPlay;
            }

            if (_moveDelta.x > 0)
                transform.localScale = new Vector3(6, 6, 6);
            else if (_moveDelta.x < 0)
                transform.localScale = new Vector3(-6, 6, 6);

            MoveAndCheckCollisions();
        }

        private void MoveAndCheckCollisions()
        {
            _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
                Mathf.Abs(_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Barrier"));
            if (_hit.collider == null)
            {
                transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);
            }

            _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
                Mathf.Abs(_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Barrier"));
            if (_hit.collider == null)
            {
                transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
            }
        }
    }
}
