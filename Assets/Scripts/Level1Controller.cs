using UnityEngine;
using UnityEngine.UI;

public class Level1Controller : MonoBehaviour
{
    public int requiredTrash;
    private int foundTrash;
    public int lives;
    public Text textTrash;
    public Text textLives;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.IsTouching(collision.otherCollider))
        {
            GameObject item = collision.collider.gameObject;

            if (item.tag == "Trash")
            {
                collectTrash();
                Destroy(collision.collider.gameObject);
            }
            else if (item.tag == "Obstacle")
            {
                collideWithObject();

                if (this.gameOver())
                {
                    Debug.Log("Game Over!");
                }
            }
        }
    }

    void collectTrash()
    {
        this.foundTrash++;
        textTrash.text = this.foundTrash.ToString();
    }

    void collideWithObject()
    {
        this.lives--;
        textLives.text = this.lives.ToString();
    }

    bool gameWin()
    {
        if (this.foundTrash == requiredTrash)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool gameOver()
    {
        if (this.lives == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
