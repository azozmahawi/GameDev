using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Joystick JoystickMovement;
    public Rigidbody Rigidbody;
    public static int TreasureCounter;
    public int LivesCounter = 3;
    public GameObject Heart1, Heart2, Heart3;
    public float Speed;
    public GameObject Text;
    //public Transform Player;
   //public NavMeshAgent Enemy;

    // Start is called before the first frame update
    public void Start()
    {
        TreasureCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        //float Horizontal = Input.GetAxis("Horizontal");
        //float Vertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(Vertical, 0, Horizontal) * Time.deltaTime * Speed;

        float horizontalJoystick = JoystickMovement.Horizontal;
        float verticalJoystick = JoystickMovement.Vertical;
        Vector3 movement = new Vector3(horizontalJoystick, 0, verticalJoystick) * Time.deltaTime * Speed;

        transform.Translate(movement);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Treasure")
        {
            Destroy(other.gameObject);
            TreasureCounter++;
            UpdateTreasureCounter();
        }

        if (other.gameObject.name == "Enemy")
        {
            Destroy(other.gameObject);
            LivesCounter--;
            UpdateHeartsUI();

            if (LivesCounter == 0)
            {
                Destroy(gameObject);
            }
        }
        //if (other.gameObject.name == "Agro")
        {
            //Enemy.SetDestination(Player.position);
            //Destroy(other.gameObject);
        }
        if (other.gameObject.name == "First House")
        {
            Application.LoadLevel("First House");
        }

        if (other.gameObject.name == "Second House")
        {
            Application.LoadLevel("Second House");
        }

        if (other.gameObject.name == "Third House")
        {
            Application.LoadLevel("Third House");
        }

        if (other.gameObject.name == "Fourth House")
        {
            Application.LoadLevel("Fourth House");
        }

        if (other.gameObject.name == "Fifth House")
        {
            Application.LoadLevel("Fifth House");
        }

        if (other.gameObject.name == "Sixth House")
        {
            Application.LoadLevel("Sixth House");
        }
    }
    void UpdateHeartsUI()
    {
        switch (LivesCounter)
        {
            case 2:
                Heart1.SetActive(false);
                break;

            case 1:
                Heart2.SetActive(false);
                break;
            case 0:
                Heart3.SetActive(false);
                Application.LoadLevel("Game Over");
                break;
        }
    }
    void UpdateTreasureCounter()
    {
        if(TreasureCounter == 2)
        {
            Application.LoadLevel("Victory");
        }
    }
}
