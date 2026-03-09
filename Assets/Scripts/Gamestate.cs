using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public Vector3 spawnLocation = new Vector3(1676, 0.5f, -45);

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        transform.position = spawnLocation;
        Debug.Log("Score: " + Score);
    }
}



