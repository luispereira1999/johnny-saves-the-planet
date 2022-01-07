using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed;
    private float diretionX;
    private float diretionY;
    public float limitMinX;
    public float limitMaxX;
    public float limitMinY;
    public float limitMaxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        diretionX = Input.GetAxisRaw("Horizontal") * playerSpeed;
        diretionY = Input.GetAxisRaw("Vertical") * playerSpeed;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, limitMinX, limitMaxX),
            Mathf.Clamp(transform.position.y, limitMinY, limitMaxY));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(diretionX, diretionY);
    }

    public void shootProjectile() {
        GameObject p = Instantiate(projectile) as GameObject;
        p.transform.position = transform.position;
    }
}
