using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour

/*
 * 
 * Code for testing the EventManager, no longer used in the main game
 * 
 */

{
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }
    }
}
