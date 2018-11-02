using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classs used to store a speakers name and their sentences they want to say
[System.Serializable]
public class Dialogue
{
    public string name; // speakers name
    [TextArea(3, 10)]
    public string[] sentences;  // sentences for dialogue box
}
