using UnityEngine;

public enum PowerUpType
{
    FireBall,
    Freeze,
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            switch (type)
            {
                case PowerUpType.FireBall:
                    Football.instance.FireBall(player.enemyGoal);
                    break;
                case PowerUpType.Freeze:
                    player.enemyPlayer.Freeze();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
