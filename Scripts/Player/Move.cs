using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private AudioSource stepsSound;
    [SerializeField] public List<AudioClip> stepSounds;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    Animator myAnimator;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal") * 5;
        float y = Input.GetAxisRaw("Vertical") * 4;

        bool moving = (moveDelta.magnitude > 0.5f);
        myAnimator.SetBool("isRunning", moving);

        moveDelta = new Vector3(x,y,0);

         if (!stepsSound.isPlaying && moving) { stepsSound.Play();
         AudioClip soundToPlay = stepSounds[Random.Range(0,stepSounds.Count)];
          stepsSound.clip = soundToPlay; }

        if (moveDelta.x > 0)
        transform.localScale = new Vector3(6,6,6);
            else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-6,6,6);


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0,moveDelta.y * Time.deltaTime, 0);
        }
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    } 
    
}
