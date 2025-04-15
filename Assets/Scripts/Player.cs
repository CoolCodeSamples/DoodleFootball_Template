using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyGoal;
    public Player enemyPlayer;

    [SerializeField] private int playerNumber;
    [SerializeField] private float speed = 7;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject iceCube;
    private bool canMove = true;

    private Rigidbody2D rb;
    private Vector2 startPos;

    public void Freeze()
    {
        canMove = false;
        CancelInvoke(nameof(Unfreeze));
        iceCube.SetActive(true);
        Invoke(nameof(Unfreeze), 5);
    }

    private void Unfreeze()
    {
        canMove = true;
        iceCube.SetActive(false);
    }

    public void Reset()
    {
        Unfreeze();
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
        if(canMove)
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f);

            float ySpeed = rb.velocity.y;
            if (Input.GetButton("Jump" + playerNumber) && hit.collider != null)
            {
                ySpeed = jumpSpeed;
            }

            rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal" + playerNumber), ySpeed);
        }
    }
}
