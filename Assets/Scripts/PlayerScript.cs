using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private float horizontal;
    private Rigidbody2D rb;
    private float vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == 0 && vertical == 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        var movement = new Vector2(horizontal, vertical);
        rb.velocity = movement * (speed * Time.fixedDeltaTime);
    }

    private void Rotation()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        var direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}