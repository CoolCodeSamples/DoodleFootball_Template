using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
    normal,
    robo,
    fireBall
}

public class Ball : MonoBehaviour
{
    [SerializeField] private Sprite roboBall;
    [SerializeField] private Sprite football;
    [SerializeField] private GameObject fire;

    public static Ball Instance;
    private Vector3 startPosition;
    private static List<Ball> activeBalls = new List<Ball>();
    private Rigidbody2D rb;

    public static void Reset()
    {
        for (int i = activeBalls.Count-1; i >= 0; i--)
        {
            Ball currentBall = activeBalls[i];
            if (Instance == currentBall)
            {
                currentBall.transform.position = currentBall.startPosition;
                currentBall.ChangeBall(BallType.normal);

                Rigidbody2D currentRb = currentBall.GetComponent<Rigidbody2D>();
                currentRb.velocity = new Vector3(0, Random.Range(-0.6524875f,5.45236f), 0);
                currentRb.angularVelocity = 0;
            }
            else
            {
                activeBalls.Remove(currentBall);
                if(currentBall != null) Destroy(currentBall.gameObject); // Not sure why this is null after the scene restart.
            }
        }
    }

    public void Duplicate()
    {
        Instantiate(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * 5;
        ChangeBall(BallType.robo);
        transform.rotation = Quaternion.identity;
    }

    public void ChangeBall(BallType ballType)
    {
        switch (ballType)
        {
            case BallType.normal:
                GetComponent<SpriteRenderer>().sprite = football;
                fire.SetActive(false);
                break;

            case BallType.robo:
                GetComponent<SpriteRenderer>().sprite = roboBall;
                break;
            case BallType.fireBall:
                fire.SetActive(true);
                break;

        }
    }

    public void FireBall(Transform target)
    {
        rb.velocity = (target.position - transform.position).normalized*20;
        rb.angularVelocity = 0;
        ChangeBall(BallType.fireBall);
        if (rb.velocity.x<0)
        {
            transform.rotation = Quaternion.Euler(0,0,180);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void Awake()
    {
        activeBalls.Add(this);
        ChangeBall(BallType.normal);
        rb = GetComponent<Rigidbody2D>();

        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        startPosition = transform.position;
        football = GetComponent<SpriteRenderer>().sprite ;
        if(activeBalls.Count<=1) Reset(); // Soll nicht resetten bei dupliziertem Ball
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        fire.SetActive(false);
    }
}
