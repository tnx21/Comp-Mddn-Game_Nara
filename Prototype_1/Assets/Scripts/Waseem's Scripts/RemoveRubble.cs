using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRubble : MonoBehaviour {

    public GameObject rubble;

    private void OnTriggerEnter(Collider other)
    {
        rubble.SetActive(false);
    }
}
