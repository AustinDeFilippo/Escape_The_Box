
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    

    
    void Update()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Boarder") || collision.gameObject.CompareTag("Spinner"))
        {
            Destroy(gameObject);
        }
        
    }
}
