using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    [SerializeField] private float speed = 7;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private Transform groundCheck;
    private Rigidbody2D rb;
    private Vector2 startPos;

    public void Reset()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f);

        float ySpeed = rb.velocity.y;
        if(Input.GetButton("Jump"+playerNumber) && hit.collider != null)
        {
            ySpeed = jumpSpeed;
        }

        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"+playerNumber), ySpeed);
    }
}
