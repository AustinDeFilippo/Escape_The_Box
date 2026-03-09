
using UnityEngine.SceneManagement;

using UnityEngine;

public class LoadObstacleCourse : MonoBehaviour
{

    

    public void LoadObstacleGameScene()
    {
        SceneManager.LoadScene("Game1Scene");
    }
    public void LoadHomeGameScene()
    {
        SceneManager.LoadScene("GameRoom");
    }
    public void LoadRiddle()
    {
        SceneManager.LoadScene("Game2Riddle");
    }
    public void LoadBall()
    {
        SceneManager.LoadScene("Game3Ball");
    }


}
