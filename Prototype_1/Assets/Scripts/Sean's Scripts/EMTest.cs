using UnityEngine;
using UnityEngine.Events;

public class EMTest : MonoBehaviour

/*
 * 
 * Code for testing the EventManager, no longer used in the main game
 * 
 */

{
    private UnityAction someListener;

    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
    }

    private void OnEnable()
    {
        EventManager.StartListening("test", someListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("test", someListener);
    }

    void SomeFunction()
    {
        Debug.Log("SomeFunction was called");
    }
}
