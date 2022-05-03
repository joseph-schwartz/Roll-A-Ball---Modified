using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Initialize the rotate speed
    public float rotateSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        //Rotate the collectible at a constant speed modified by the rotateSpeed public variable
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * rotateSpeed);
    }
}
