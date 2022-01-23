using UnityEngine;

public class HeroLevel2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector3 movement;
    private bool isMoving = false;
    private AudioSource sound;

    public Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer();
        PressKeys();

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else
        {
            sound.Stop();
        }
    }

    private void MovePlayer()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += movement * Time.deltaTime * speed;
    }

    private void PressKeys()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            playerAnimator.Play("hero-back");
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnimator.Play("hero-front");
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            playerAnimator.Play("hero-right");
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            playerAnimator.Play("hero-left");
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
