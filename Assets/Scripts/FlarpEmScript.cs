using UnityEngine;

public class FlarpEmScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPoint;
    public float maxPullDistance = 3f;
    public float forceMultiplier = 10f;

    private Vector2 initialPos;
    private Vector2 currentDragPos;
    private bool isDragging = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = projectile.GetComponent<Rigidbody2D>();
        initialPos = projectile.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Bounce more or apply any additional effects here if needed
        }
    }

    void Update()
    {

        if (isDragging)
        {
            currentDragPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector2 dragDirection = currentDragPos - (Vector2)shootPoint.position;
            dragDirection = Vector2.ClampMagnitude(dragDirection, maxPullDistance);
            projectile.transform.position = (Vector2)shootPoint.position + dragDirection;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseProjectile();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        rb.isKinematic = true;
    }

    private void ReleaseProjectile()
    {
        isDragging = false;
        rb.isKinematic = false;
        Vector2 releaseDirection = (initialPos - (Vector2)projectile.transform.position);
        rb.velocity = releaseDirection * forceMultiplier;
        projectile.transform.position = initialPos;
    }
}
