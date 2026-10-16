
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameManager gameManager;
    public Material lockedMaterial;
    public Material unlockedMaterial;

    private Renderer portalRenderer;
    private BoxCollider portalCollider;
    private bool unlocked = false;

    void Start()
    {
        portalRenderer = GetComponent<Renderer>();
        portalCollider = GetComponent<BoxCollider>();

        portalRenderer.material = lockedMaterial;
        portalCollider.isTrigger = false;
    }

    void Update()
    {
        if (gameManager == null)
            return;

        if (gameManager.doorUnlocked && !unlocked)
        {
            unlocked = true;

            portalRenderer.material = unlockedMaterial;
            portalCollider.isTrigger = true;

            Debug.Log("Portal is now open!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && unlocked)
        {
            gameManager.WinGame();
        }
    }
}
