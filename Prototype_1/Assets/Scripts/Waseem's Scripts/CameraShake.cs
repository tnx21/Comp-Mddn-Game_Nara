using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    bool shaking = false;

    public void Update()
    {
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
        yield return new WaitForSeconds(2.0f);
        glitch.enabled = false;
        shaking = false;
    }


}