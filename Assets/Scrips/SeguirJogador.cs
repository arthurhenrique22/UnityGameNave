using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    public PlayerController playerController;
    public Vector3 PlayerDistance ;

    void Start()
    {
        
    }

    
    void Update()
    {
        if( playerController == null)
        {
            return;
        }

        this.transform.position = playerController.transform.position + PlayerDistance;
     
    }
}
