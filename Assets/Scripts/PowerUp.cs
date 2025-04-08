using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Football.instance.FireBall(player.enemyGoal);
            Destroy(gameObject);
        }
    }
}
