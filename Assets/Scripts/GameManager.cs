using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public GameObject deathScreen;
    public TextMeshProUGUI hitsText;

    [Header("Player Components")]
    public PlayerMotor playerMotor;
    public PlayerLook playerLook;

    [Header("Game Settings")]
    public float totalTime = 60f;

    private float timeLeft;
    private bool timerRunning = false;
    private bool gameOver = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        timeLeft = totalTime;
        UpdateTimerUI();
        deathScreen.SetActive(false);

        // Cursor initial sperren und verstecken
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (timerRunning && !gameOver)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                timerRunning = false;
                gameOver = true;
                ShowDeathScreen();
            }
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int displayTime = Mathf.FloorToInt(timeLeft);
        if (displayTime < 0) displayTime = 0;
        timerText.text = "Time: " + displayTime.ToString();
    }

    public void StartTimer()
    {
        if (!timerRunning && !gameOver)
        {
            timerRunning = true;
        }
    }

    public bool CanHit()
    {
        return (!gameOver);
    }

    public void RestartGame()
    {
        gameOver = false;
        timeLeft = totalTime;
        UpdateTimerUI();
        deathScreen.SetActive(false);
        timerRunning = false;

        // Reset HitCounter
        if (HitCounter.instance != null)
            HitCounter.instance.ResetHits();

        // Spielersteuerung aktivieren
        if (playerMotor != null)
            playerMotor.enabled = true;
        if (playerLook != null)
            playerLook.enabled = true;

        // Cursor sperren und verstecken
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public bool IsTimerRunning()
    {
        return timerRunning;
    }

    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);

        // Spielersteuerung deaktivieren
        if (playerMotor != null)
            playerMotor.enabled = false;
        if (playerLook != null)
            playerLook.enabled = false;

        // Cursor sichtbar und entsperrt machen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Hits anzeigen
        if (HitCounter.instance != null)
            hitsText.text = "Hits: " + HitCounter.instance.GetHits().ToString();
    }

    // Wird vom Retry-Button im Deathscreen aufgerufen
    public void OnRetryButton()
    {
        RestartGame();
    }
}
