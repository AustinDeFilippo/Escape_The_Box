using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public int maxRounds = 5;
    public int maxLives = 3;
    private int currentRound = 1;
    private int lives;
    private bool isPlayingSequence = false;
    

    [Header("UI")]
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI roundText;

    [Header("Buttons")]
    public ColorButton[] colorButtons;

    private List<int> currentSequence = new List<int>();
    private int playerIndex = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        lives = maxLives;
        currentRound = 1;
        statusText.text = "";
        UpdateUI();
        StartCoroutine(PlayRound());
    }

    IEnumerator PlayRound()
    {
        isPlayingSequence = true;
        playerIndex = 0;
        currentSequence.Clear();

       
        for (int i = 0; i < currentRound; i++)
        {
            int randomIndex = Random.Range(0, colorButtons.Length);
            currentSequence.Add(randomIndex);
        }

        yield return ShowSequence();
        isPlayingSequence = false;
    }

    IEnumerator ShowSequence()
    {
        yield return new WaitForSeconds(1f);

        foreach (int index in currentSequence)
        {
            colorButtons[index].Flash();
            yield return new WaitForSeconds(1f);
        }
    }

    public void PlayerPressed(int index)
    {
        if (isPlayingSequence) return;

        if (currentSequence[playerIndex] == index)
        {
            playerIndex++;
            if (playerIndex >= currentSequence.Count)
            {
                currentRound++;
                if (currentRound > maxRounds)
                {
                    GameState.Instance.AddScore(1);
                    SceneManager.LoadScene("Game1WinScene");
                }
                else
                {
                    UpdateUI();
                    StartCoroutine(PlayRound());
                }
            }
        }
        else
        {
            lives--;
            if (lives <= 0)
            {
                statusText.text = "💀 Game Over!";
                Invoke(nameof(StartGame), 2f);
            }
            else
            {
                statusText.text = "❌ Try Again!";
                UpdateUI();
                StartCoroutine(PlayRound());
            }
        }
    }

    private void UpdateUI()
    {
        roundText.text = $"Round: {currentRound} / {maxRounds}";
        livesText.text = $"Lives: {lives}";
    }
}

