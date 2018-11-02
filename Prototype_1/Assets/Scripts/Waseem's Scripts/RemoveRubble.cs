using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Removing rubble blocking mine when triggering with alter collider
public class RemoveRubble : MonoBehaviour {

    public GameObject rubble;

    private void OnTriggerEnter(Collider other)
    {
        rubble.SetActive(false);
    }
}
