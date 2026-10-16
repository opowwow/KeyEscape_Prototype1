
using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveSpeed = 2f;
    public float phaseOffset = 0f;

    public Transform respawnPoint;

    private Vector3 startPosition;
    private Rigidbody rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = rb.position;

        gameManager = FindFirstObjectByType<GameManager>();
    }

    void FixedUpdate()
    {
        float offset = Mathf.Sin(
            Time.fixedTime * moveSpeed + phaseOffset
        ) * moveDistance;

        Vector3 newPosition =
            startPosition + Vector3.right * offset;

        rb.MovePosition(newPosition);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (gameManager == null ||
            gameManager.gameOver ||
            respawnPoint == null)
            return;

        gameManager.LoseLife();

        Rigidbody playerRb =
            other.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.position = respawnPoint.position;
        }
    }
}
