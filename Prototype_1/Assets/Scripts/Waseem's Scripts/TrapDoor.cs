using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggering trap door animation
public class TrapDoor : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (anim != null)
        {
            //Play the trapdoor amimation when hitting trigger
            anim.Play("Trapdoor");
        }
    }


}
