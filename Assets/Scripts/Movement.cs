
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    

    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        movePlayer();
    }

    void movePlayer()

    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, zValue);

    }
}
