using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAlterTrigger : MonoBehaviour {

    public GameObject firstAlterTrigger;
    public GameObject secondAlterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        firstAlterTrigger.SetActive(false);
        secondAlterTrigger.SetActive(true);
    }
}
