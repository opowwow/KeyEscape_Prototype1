
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.LoseLife();
            }

            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null && respawnPoint != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.position = respawnPoint.position;
            }
        }
    }
}
