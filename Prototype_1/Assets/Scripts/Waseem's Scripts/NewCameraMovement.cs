using UnityEngine;
using System.Collections;

public class NewCameraMovement : MonoBehaviour
{

    public GameObject player;       
    private Vector3 offset;         //offset to center camera
    private Vector3 leftOffset;     //offset to move camera left
    private Vector3 rightOffset;    //offset to move camera right

    private Vector3 currentPosition;

    void Start()
    {
        //Calculating the offset to the middle
        offset = transform.position - player.transform.position;

        //Calculating the offset to the left
        leftOffset = transform.position - player.transform.position;
        leftOffset.x = leftOffset.x + 6;

        //Calculating the offset to the right
        rightOffset = transform.position - player.transform.position;
        rightOffset.x = rightOffset.x - 6;

        //Starting the camera in the middle
        transform.position = player.transform.position + offset;
        currentPosition = transform.position;
    }

    //Using LateUpdate so that the camera moves after the player moves (i.e. following the player)
    void LateUpdate()
    {
        //If player not moving center the camera
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position = Vector3.Lerp(currentPosition, player.transform.position + offset, 10.0f * Time.deltaTime);
            currentPosition = transform.position;
        }
        //If player moving left, lerp the camera to the right
        else if (Input.GetKey("a"))
        {
            transform.position = Vector3.Lerp(currentPosition, player.transform.position + rightOffset, 10.0f * Time.deltaTime);
            currentPosition = transform.position;
        }
        //If player moving right, lerp the camera to the left
        else if (Input.GetKey("d"))
        {
            transform.position = Vector3.Lerp(currentPosition, player.transform.position + leftOffset, 10.0f * Time.deltaTime);
            currentPosition = transform.position;
        }
    }

}
