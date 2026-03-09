using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float xValue;
    [SerializeField] float yValue;
    [SerializeField] float zValue;

    void FixedUpdate()
    {
        transform.Rotate(xValue, yValue, zValue);
    }

   
}
