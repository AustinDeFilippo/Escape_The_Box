
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] float health = 3f;
    public  Vector3 spawnLocation = new Vector3(-43, 1, 22);
    GameObject[] coinObject;
    public TextMeshProUGUI coinCountText;
    private int totalCollect;
    

    void Start()
    {
        transform.position = spawnLocation;


    }

    
    void Update()
    {
        coinObject = GameObject.FindGameObjectsWithTag("Coin");
        CoinsCount();
        
        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spinner" || collision.gameObject.tag == "Bullet")  
        {
            health--;
            
            Debug.Log("Health: " + health);
            if (health <= 0)
            {
               transform.position = spawnLocation;
                health = 3;
            }
        }
        if (collision.gameObject.tag == "Winzone" && totalCollect == 0 )
        {
            GameState.Instance.AddScore(1);
            SceneManager.LoadScene("Game1WinScene");
        }
        if (collision.gameObject.tag == "Coin")
        {
            totalCollect--;
            
        }
        

    }

    private void CoinsCount()
    {
        coinCountText.text = "Coins: " + totalCollect;

       for  (int i = totalCollect; i < coinObject.Length; i++)
        {
            totalCollect++;
        }
       
        
    }
    
    
}
