using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shaking camera when hitting trigger
//Using kino glitch library to help with this
public class CameraShake : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    bool shaking = false;

    public void Update()
    {
        //Only shake once the trigger has been activated
        if (shaking)
        {
            Shake();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        shaking = true;
    }

    public void Shake()
    {
        Kino.AnalogGlitch glitch = this.playerCamera.GetComponent<Kino.AnalogGlitch>();
        glitch.enabled = true;
        StartCoroutine(disableGlitch(glitch));
    }

    IEnumerator disableGlitch(Kino.AnalogGlitch glitch)
    {
        //Shake camera for 2 seconds
        yield return new WaitForSeconds(2.0f);
        glitch.enabled = false;
        shaking = false;
    }


}