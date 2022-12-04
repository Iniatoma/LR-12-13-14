using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;
    float shipBoundaryRadius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the ship

        //Grab our rotation quaternion
        Quaternion rot = transform.rotation;
        //Grab the Z euler angle
        float z = rot.eulerAngles.z;
        //Change the z angle based on input 
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //recreate the quaternion 
        rot = Quaternion.Euler(0, 0, z);
        //Feed the quaternion into our rotation
        transform.rotation = rot;
        //Move the ship
        Vector3 pos = transform.position;

        Vector3 velocity= new Vector3(0,Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime);
        pos += rot*velocity;

        //Restric the player to the camera s boundaries
        //first to vertic,because it s simpler
        if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize- shipBoundaryRadius;
        }

        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }
        //Now do horizontal bounds
        float sreenRatio = (float)Screen.width / (float)Screen.height;//Warning Will be weird!
        float widthOrtho = Camera.main.orthographicSize * sreenRatio;
        //Now do horizontal bounds
        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }

        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }
        //Final, update  our position
        transform.position = pos;
    }
}
