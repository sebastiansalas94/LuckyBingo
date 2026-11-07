using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField] private GameObject ballPrefab;

    float lifeTime = 5.0f;
    float cooldown = 1.0f;
    private float nextSpawnTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ballPrefab != null)
        {
            if (Time.time >= nextSpawnTime)
            {
                // Fix: Use UnityEngine.Random.Range to generate a random position
                Vector3 randomPosition = new Vector3(
                    UnityEngine.Random.Range(transform.position.x - 1f, transform.position.x + 1f),
                    transform.position.y,
                    UnityEngine.Random.Range(transform.position.z - 1f, transform.position.z + 1f)
                );
                GameObject ball = Instantiate(ballPrefab, randomPosition, Quaternion.identity);
                Destroy(ball, lifeTime);

                nextSpawnTime = Time.time + cooldown;
            }
        }
    }
}
