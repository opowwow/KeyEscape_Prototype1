using UnityEngine;

public class KeyActivator : MonoBehaviour
{
    public GameObject keyToActivate;

    private bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            if (gameManager != null &&
                gameManager.state == GameManager.GameState.Playing &&
                keyToActivate != null)
            {
                keyToActivate.SetActive(true);
                activated = true;

                Debug.Log(keyToActivate.name + " activated!");
            }
        }
    }
}