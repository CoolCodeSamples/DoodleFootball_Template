using UnityEngine;

public enum PowerUpType
{
    RoboBall,
    MultiBall,
    Freeze,
    FireBall
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FootballPlayer player))
        {
            print(player.GetType());
            switch (powerUpType)
            {
                case PowerUpType.RoboBall:
                case PowerUpType.FireBall:
                case PowerUpType.Freeze:
                    player.ActivatePowerUp(powerUpType);
                    break;
                case PowerUpType.MultiBall:
                    Ball.Instance.Duplicate();
                    break;
                
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
