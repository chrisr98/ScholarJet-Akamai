using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController thePlayer;

    private CameraController theCamera;

    public Vector2 startDirection;

    public string pointName;

    // Start is called before the first frame update
    void Start()
    {

        //get access to PlayerController
        thePlayer = FindObjectOfType<PlayerController>();

        if(thePlayer.startPoint == pointName)
        {
            //player start point at a given scene and faces the right direction
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;


            //camera start point to match player
            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
