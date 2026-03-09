
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static PointCounter Instance;

    public int points = 0;

    void Awake()
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

    public void AddPoint()
    {

        points++;
        Debug.Log("Points: " + points);
    }
}
