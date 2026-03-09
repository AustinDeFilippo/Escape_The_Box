using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Riddlegame : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text riddleText;
    public TMP_Text clueText;
    public TMP_InputField inputField;
    public Button enterButton;
    public TMP_Text timeLimitText;
    public TMP_Text guessesLeftText;

    [Header("Game Settings")]
    private float timeRemaining = 300f; // 5 minutes
    private int guessesLeft = 5;
    private int currentClueIndex = 0;
    private bool gameEnded = false;

    private Riddle currentRiddle;
    private bool clueTimerActive = true;

    [System.Serializable]
    public class Riddle
    {
        public string question;
        public string answer;
        public string[] clues;
    }

    private Riddle[] riddles = new Riddle[]
    {
        new Riddle {
            question = "I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?",
            answer = "echo",
            clues = new string[] {
                "You hear me, but I don't speak.",
                "I exist in caves and mountains.",
                "I'm a reflection of sound.",
                "I'm often heard when you shout.",
                "I'm not a person, but I answer you."
            }
        },
        new Riddle {
            question = "I’m tall when I’m young, and I’m short when I’m old. What am I?",
            answer = "candle",
            clues = new string[] {
                "I melt over time.",
                "I’m used during blackouts.",
                "I give off light.",
                "I have a wick.",
                "I drip."
            }
        },
        new Riddle {
            question = "What has hands but can’t clap?",
            answer = "clock",
            clues = new string[] {
                "I'm always ticking.",
                "I tell time.",
                "I have a face.",
                "I’m on your wrist or wall.",
                "I never sleep."
            }
        },
        new Riddle {
            question = "The more you take, the more you leave behind. What are they?",
            answer = "footsteps",
            clues = new string[] {
                "You make me while walking.",
                "I follow you everywhere.",
                "I’m on the ground.",
                "I'm not visible in the air.",
                "Detectives look for me."
            }
        },
        new Riddle {
            question = "What can run but never walks, has a bed but never sleeps?",
            answer = "river",
            clues = new string[] {
                "I’m full of water.",
                "I have a mouth and a bed.",
                "Boats can travel on me.",
                "I flow downhill.",
                "I never stop."
            }
        },
        new Riddle {
            question = "I have keys but no locks. I have space but no room.",
            answer = "keyboard",
            clues = new string[] {
                "I’m used for typing.",
                "Gamers use me a lot.",
                "I have numbers and symbols.",
                "I’m connected to a computer.",
                "You press me often."
            }
        },
        new Riddle {
            question = "What has to be broken before you can use it?",
            answer = "egg",
            clues = new string[] {
                "I have a shell.",
                "I’m used in breakfast.",
                "I’m fragile.",
                "I can be fried or boiled.",
                "Chickens make me."
            }
        },
        new Riddle {
            question = "What begins with T, ends with T, and has T in it?",
            answer = "teapot",
            clues = new string[] {
                "I’m found in kitchens.",
                "I hold a drink.",
                "I start and end with the same letter.",
                "I can whistle.",
                "I get hot."
            }
        },
        new Riddle {
            question = "What can fill a room but takes up no space?",
            answer = "light",
            clues = new string[] {
                "I let you see.",
                "I come from the sun or a bulb.",
                "I travel fast.",
                "I can be warm.",
                "I can be blinding."
            }
        },
        new Riddle {
            question = "I’m found in socks, scarves and mittens; and often in the paws of playful kittens.",
            answer = "yarn",
            clues = new string[] {
                "I’m long and stringy.",
                "Cats like to play with me.",
                "I’m used in knitting.",
                "I come in many colors.",
                "I’m soft."
            }
        },
    };

    void Start()
    {
        enterButton.onClick.AddListener(CheckAnswer);
        LoadRandomRiddle();
    }

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;
        UpdateTimerText();

        if (timeRemaining <= 0f)
        {
            EndGame(false, "⏰ Time’s up! You lost!");
        }
        else if (clueTimerActive && timeRemaining <= 300f - (currentClueIndex + 1) * 60f && currentClueIndex < currentRiddle.clues.Length)
        {
            clueText.text += "\nClue: " + currentRiddle.clues[currentClueIndex];
            currentClueIndex++;
        }
    }

    void LoadRandomRiddle()
    {
        currentRiddle = riddles[Random.Range(0, riddles.Length)];
        riddleText.text = currentRiddle.question;
        clueText.text = "";
        guessesLeft = 5;
        currentClueIndex = 0;
        timeRemaining = 300f;
        gameEnded = false;
        clueTimerActive = true;
        guessesLeftText.text = "Guesses Left: 5";
        inputField.text = "";
    }

    void CheckAnswer()
    {
        if (gameEnded) return;

        string playerAnswer = inputField.text.Trim().ToLower();
        if (playerAnswer == currentRiddle.answer.ToLower())
        {
            EndGame(true, "✅ Correct! You win!");
        }
        else
        {
            guessesLeft--;
            guessesLeftText.text = $"Guesses Left: {guessesLeft}";
            if (guessesLeft <= 0)
            {
                EndGame(false, "❌ Out of guesses! You lose!");
            }
        }

        inputField.text = "";
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timeLimitText.text = $"Time Left: {minutes:00}:{seconds:00}";
    }

    void EndGame(bool win, string message)
    {
        gameEnded = true;
        clueTimerActive = false;
        riddleText.text = message;
        clueText.text = "";
        if (win) 
        {
            GameState.Instance.AddScore(1);
            SceneManager.LoadScene("Game1WinScene");
        }
        else
        {
            timeLimitText.text = "Game Over!";
        }
    }
}
