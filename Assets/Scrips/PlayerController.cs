using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public Rigidbody rb;
    
    public int ForcaEmX;
    public int ForcaEmZ = 50;

    public GameController gameController;

    public GameObject FxExprosionPrefab;

    public float Speed = 110;

    public float  TargetAngle = 30;

    public float SpeedRotation = 5;



    void Start()
    {

    }


    void FixedUpdate()
    {
        if (rb.velocity.z < Speed)
        {
            rb.AddForce(0, 0, ForcaEmZ * Time.fixedDeltaTime);
        }

        if (Input.GetKey("a") == true)
        {
            rb.AddForce(-ForcaEmX * Time.fixedDeltaTime, 0, 0);

            Quaternion CurrentRotation = rb.rotation;
            Quaternion TargetRotation = Quaternion.Euler(0, 0, TargetAngle);
            Quaternion NewRotation = Quaternion.Lerp(CurrentRotation, TargetRotation, Time.fixedDeltaTime * SpeedRotation);
            rb.MoveRotation(NewRotation);

        }
        else if (Input.GetKey("d") == true)
        {
            rb.AddForce(ForcaEmX * Time.fixedDeltaTime, 0, 0);

            Quaternion CurrentRotation = rb.rotation;
            Quaternion TargetRotation = Quaternion.Euler(0, 0, -TargetAngle);
            Quaternion NewRotation = Quaternion.Lerp(CurrentRotation, TargetRotation, Time.fixedDeltaTime * SpeedRotation);
            rb.MoveRotation(NewRotation);

        }
        else
        {
            Quaternion CurrentRotation = rb.rotation;
            Quaternion TargetRotation = Quaternion.Euler(0, 0, 0);
            Quaternion NewRotation =Quaternion.Lerp(CurrentRotation, TargetRotation, Time.fixedDeltaTime * SpeedRotation);
            rb.MoveRotation(NewRotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
         
        if (collision.collider.CompareTag("Inimigo") == true)
        {
            GameObject.Instantiate(FxExprosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            gameController.GameOver();
        } 
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Planeta"))
        {
            gameController.VencerJogo();
        }

    }

}