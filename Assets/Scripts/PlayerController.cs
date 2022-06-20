using UnityEngine;
using System.Collections; using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    private int numPickups = 6; //Put here the number of pickups you have. public Text scoreText;
    public Text WinText;
    public Text scoreText;
    private GameObject PlayerPos = null;
    public Text PlayerPosition;
    public Text PlayerVelocity;
    Vector3 prevposition;
    Vector3 currentposition;
    public Vector3 Velocity;
    public Text Pickups;




    void Start()
    {
        count = 0; WinText.text = ""; SetCountText();

        if (PlayerPos == null)
            PlayerPos = GameObject.Find("Player");


        prevposition = transform.position;

    }



    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis, 0.0f, verAxis);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        currentposition = transform.position;
        Velocity = (currentposition - prevposition) / Time.fixedDeltaTime;
        prevposition = currentposition;




        //Pickups.text = "NearestPickup: " + .ToString();

        PlayerVelocity.text = "Player Velocity: " + Velocity.ToString();

        PlayerPosition.text = "Player Position: " + PlayerPos.transform.position.ToString("0.00");

    }
    //NO changes



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false); count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString(); if (count >= numPickups)
        {
            WinText.text = "You win!";
        }
    }
}