using UnityEngine;

public class Football : MonoBehaviour
{
    public static Football instance;

    private Vector3 startPos;
    private Rigidbody2D rb;

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
}
