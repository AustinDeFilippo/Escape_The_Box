
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickGame : MonoBehaviour
{
   

    void Update()
    {
        Obsticle();
        Riddle();
        Ball();
    }

    private void Obsticle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("StartGameOneScene");
        }
    }
    private void Riddle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Game2Rules");
        }
    }
    private void Ball()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Game3Rules");
        }
    }
}
