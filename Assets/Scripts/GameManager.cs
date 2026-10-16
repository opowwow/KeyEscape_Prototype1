
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Won,
        Lost
    }

    public GameState state = GameState.Playing;

    public int startingLives = 3;
    public int lives;
    public bool gameOver = false;

    public int keyPoints = 0;
    public int keysNeeded = 4;
    public bool doorUnlocked = false;

    public TMP_Text livesText;
    public TMP_Text keysText;

    public GameObject endGamePanel;
    public TMP_Text endGameText;

    void Start()
    {
        lives = startingLives;
        keyPoints = 0;
        gameOver = false;
        doorUnlocked = false;
        state = GameState.Playing;

        if (endGamePanel != null)
            endGamePanel.SetActive(false);

        UpdateLivesUI();
        UpdateKeysUI();
    }

    public void LoseLife()
    {
        if (state != GameState.Playing)
            return;

        lives--;
        UpdateLivesUI();

        Debug.Log("Lives remaining: " + lives);

        if (lives <= 0)
        {
            state = GameState.Lost;
            gameOver = true;

            ShowEndScreen("GAME OVER!");
            StopPlayer();
        }
    }

    public void AddKeys(int amount)
    {
        if (state != GameState.Playing)
            return;

        keyPoints = Mathf.Min(
            keysNeeded, keyPoints + amount
        );

        UpdateKeysUI();

        if (keyPoints >= keysNeeded && !doorUnlocked)
        {
            doorUnlocked = true;
            Debug.Log("DOOR UNLOCKED!");
        }
    }

    public void WinGame()
    {
        if (state != GameState.Playing || !doorUnlocked)
            return;

        state = GameState.Won;
        gameOver = true;

        ShowEndScreen("YOU WIN!");
        StopPlayer();
    }

    void ShowEndScreen(string message)
    {
        if (endGamePanel != null)
            endGamePanel.SetActive(true);

        if (endGameText != null)
        {
            endGameText.text = message;

            if (state == GameState.Won)
                endGameText.color = Color.yellow;
            else
                endGameText.color = Color.red;
        }
    }

    void StopPlayer()
    {
        PlayerController player =
            FindFirstObjectByType<PlayerController>();

        if (player != null)
        {
            player.enabled = false;

            Rigidbody rb = player.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    void UpdateKeysUI()
    {
        if (keysText != null)
            keysText.text = "Keys: " + keyPoints + "/" + keysNeeded;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
