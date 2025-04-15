using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int coolDown;
    [SerializeField] private GameObject[] powerUps;

    private void Spawn()
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, transform.rotation);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), coolDown, coolDown);
    }
}
