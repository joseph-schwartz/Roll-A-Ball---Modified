using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //Set the camera to a fixed distance back from the player
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame once final position is calculated
    void LateUpdate()
    {
        //Keeps the camera following the player at a fixed distance away
        transform.position = player.transform.position + offset;
    }
}
