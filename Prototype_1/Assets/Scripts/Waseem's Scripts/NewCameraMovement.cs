using UnityEngine;
using System.Collections;

public class NewCameraMovement : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Vector3 leftOffset;
    private Vector3 rightOffset;

    private Vector3 currentPosition;
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

        leftOffset = transform.position - player.transform.position;
        leftOffset.x = leftOffset.x + 6;

        rightOffset = transform.position - player.transform.position;
        rightOffset.x = rightOffset.x - 6;

        transform.position = player.transform.position + offset;
        currentPosition = transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {


        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            //transform.position = player.transform.position + offset;
            transform.position = Vector3.Lerp(currentPosition, player.transform.position + offset, 10.0f * Time.deltaTime);
            currentPosition = transform.position;
        }
        else if (Input.GetKey("a"))
        {

            //transform.position = player.transform.position + rightOffset;
            transform.position = Vector3.Lerp(currentPosition, player.transform.position + rightOffset, 10.0f * Time.deltaTime);
            currentPosition = transform.position;
        }
        else if (Input.GetKey("d"))
        {
            //transform.position = player.transform.position + leftOffset;
            transform.position = Vector3.Lerp(currentPosition, player.transform.position + leftOffset, 10.0f * Time.deltaTime);
            currentPosition = transform.position;
        }
    }

}
