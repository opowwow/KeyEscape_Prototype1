
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    public int keyValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            if (gameManager != null && !gameManager.gameOver)
            {
                gameManager.AddKeys(keyValue);
                gameObject.SetActive(false);
            }
        }
    }
}
