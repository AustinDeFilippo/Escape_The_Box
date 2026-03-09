using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public GameObject prefBullet;
    public Transform spawnPoint;
    public float shootTime = 2f;
    private float resetTime;



    


void Update()
{

    ShootMech();
}
private void ShootMech()
     {

        resetTime += Time.deltaTime;
            
        if (resetTime >= shootTime)
        {
                 
            Instantiate(prefBullet, spawnPoint.position, Quaternion.identity);
            resetTime = 0f;
        }
    }
}
   
    

