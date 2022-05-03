using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Acceleration of movement
    public float speed = 0;
    public Text countText;
    public Text winText;
    //Power of lift
    public float liftForce = 2.0f;
    //Player Sphere
    private Rigidbody rb;
    //Count of objects collected
    private int count;
    private float movementX;
    private float movementY;
    private Vector3 lift;

    // Start is called before the first frame update - Initialize Variables
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
        //Base force vector value for lift
        lift = new Vector3(0.0f, 2.0f, 0.0f);
    }

    //Grab the movement value from the input
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        //Apply changes to the movement
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Check if it hit a collectible
        if (other.gameObject.CompareTag("Pickup"))
        {
            //Set to activity to false - For more efficiency delete if no dependents exist
            other.gameObject.SetActive(false);
            //Apply lift
            rb.AddForce(lift * liftForce, ForceMode.Impulse);
            count += 1;
            SetCountText();
        }
        //Restart the level if the enemy gets you
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //If the player charges the enemy from behind, remove the enemy
        if (other.gameObject.CompareTag("WeakPoint"))
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
            rb.AddForce(lift * liftForce, ForceMode.Impulse);
        }
        if (other.gameObject.CompareTag("KillZone"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //Updates the count text and sets the Win text if the conditions are met
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }

}
