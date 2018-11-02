using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to attach the player to moving platforms
public class AttachPlayer : MonoBehaviour
{

    public GameObject Player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            //Set player position to that of moving platform
            Player.transform.parent = this.transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}