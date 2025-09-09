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
    private bool hasRoboBall;

    private Rigidbody2D rb;
    private Vector2 startPos;

    public void ActivateRoboBall()
    {
        CancelInvoke(nameof(DeactivateRoboBall));
        hasRoboBall = true;
        Football.instance.ToggleRoboImage(true);
        Invoke(nameof(DeactivateRoboBall), 5);
    }

    public void Freeze()
    {
        canMove = false;
        CancelInvoke(nameof(Unfreeze));
        iceCube.SetActive(true);
        Invoke(nameof(Unfreeze), 5);
    }

    public void Reset()
    {
        DeactivateRoboBall();
        Unfreeze();
        transform.position = startPos;
        rb.velocity = Vector2.zero;
    }

    private void DeactivateRoboBall()
    {
        hasRoboBall = false;
        Football.instance.ToggleRoboImage(false);
    }

    private void Unfreeze()
    {
        canMove = true;
        iceCube.SetActive(false);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal" + playerNumber), Input.GetAxis("Vertical" + playerNumber));

        if (hasRoboBall)
        {
            Football.instance.RoboMovement(input);
        }
        else if(canMove)
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f);

            float ySpeed = rb.velocity.y;
            if (Input.GetButton("Jump" + playerNumber) && hit.collider != null)
            {
                ySpeed = jumpSpeed;
            }

            rb.velocity = new Vector2(speed * input.x, ySpeed);
        }
    }
}
