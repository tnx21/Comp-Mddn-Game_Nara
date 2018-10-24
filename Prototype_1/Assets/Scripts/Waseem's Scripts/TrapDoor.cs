using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.Play("Trapdoor");
    }


}
