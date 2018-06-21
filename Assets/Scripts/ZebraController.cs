using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZebraController : MonoBehaviour {

    public float moveSpeed = 0.01f;
    public float turnSpeed = 1.0f;
    private int playerScore = 0;

    public Text starfishText;
    public Text winText;    
    private int starfishTotal;

    public AudioClip pickupSound;
    private AudioSource audioPlayer;

	// Use this for initialization
	void Start ()
    {
        winText.text = "";
        GameObject[] starfishArray = GameObject.FindGameObjectsWithTag("Nut");
        this.starfishTotal = starfishArray.Length;
        starfishText.text = "Nuts Left: " + starfishTotal;
        audioPlayer = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {		

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.localRotation * this.forward() * moveSpeed; 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.localRotation * this.backward() * moveSpeed;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation *= Quaternion.Euler(0, 0, -turnSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation *= Quaternion.Euler(0, 0, turnSpeed);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Nut")
        {
            Destroy(collision.gameObject);            
            starfishTotal--;
            audioPlayer.PlayOneShot(pickupSound);
            starfishText.text = "Nuts Left: " + starfishTotal;            
            if (starfishTotal == 0)
            {
                winText.text = "All The Work!";
            }
            
        }
    }

    private Vector3 forward()
    {
        return new Vector3(0, -1, 0);
    }

    private Vector3 backward()
    {
        return new Vector3(0, 1, 0);
    }
}
