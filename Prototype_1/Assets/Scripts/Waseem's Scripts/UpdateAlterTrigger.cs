using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Setting dialogue colliders at altar
public class TriggerSecondAltarDialogue : MonoBehaviour {

    public GameObject firstAlterTrigger;
    public GameObject secondAlterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        firstAlterTrigger.SetActive(false);
        secondAlterTrigger.SetActive(true);
    }
}
