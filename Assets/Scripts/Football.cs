using UnityEngine;

public class Football : MonoBehaviour
{
    public static Football instance;

    [SerializeField] private GameObject fireImage;

    private Vector3 startPos;
    private Rigidbody2D rb;

    public void FireBall(Transform target)
    {
        fireImage.SetActive(true);
        rb.velocity = (target.position - transform.position).normalized * 40;
        transform.up = transform.position - target.position;
    }

    public void Reset()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
    }

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fireImage.SetActive(false);
    }
}
