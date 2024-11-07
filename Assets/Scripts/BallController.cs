using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public AudioSource aud;
    public GameObject canvas;
    private Vector2 direction;

    void Start()
    {
        ResetBall();
    }

    void ResetBall()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        transform.position = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball hits a paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 paddleDirection = collision.contacts[0].point - (Vector2)collision.transform.position;
            paddleDirection.Normalize();
            direction = Vector2.Reflect(direction, paddleDirection);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
    void Win()
    {
        SceneManager.LoadScene("WinScene");
    }
    void Die()
    {
        canvas.SetActive(true);
    }

    void Update()
    {
        // Check for boundary collisions (top and bottom)
        if (transform.position.y > 5.4f || transform.position.y < -5.4f)
        {
            aud.Play();
            direction.y = -direction.y; // Reflect the Y direction
            GetComponent<Rigidbody2D>().velocity = direction * speed; // Update the velocity
        }

        // Reset the ball if it goes off the screen horizontally
        if (transform.position.x > 11)
        {
            Win();
        }
        if (transform.position.x < -11)
        {
            Die();
        }
    }
}