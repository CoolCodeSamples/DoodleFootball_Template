using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Football ball))
        {
            print("GOOOOOOOOOOAL!!!");
        }
    }
}
