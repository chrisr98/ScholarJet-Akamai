using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;

    private Vector3 targetPosition;

    public float moveSpeed;

    private static bool cameraExist;

    public BoxCollider2D cameraBounds;

    private Vector3 minBounds;

    private Vector3 maxBounds;

    private Camera theCamera;

    private float halfHeight;

    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
  
        //when loaded into new area don't destroy to carry over everything
        //check for duplicates
        if (!cameraExist)
        {
            cameraExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        if (cameraBounds == null)
        {
            cameraBounds = FindObjectOfType<BoundsManager>().GetComponent<BoxCollider2D>();
            minBounds = cameraBounds.bounds.min;
            maxBounds = cameraBounds.bounds.max;
        }

        //set bounds so camera doesn't see outside game view bounds
        minBounds = cameraBounds.bounds.min;
        maxBounds = cameraBounds.bounds.max;

        //get camera component
        theCamera = GetComponent<Camera>();
        //get sizes for camera
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        //makes sure camera always follow player
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (cameraBounds == null)
        {
            cameraBounds = FindObjectOfType<BoundsManager>().GetComponent<BoxCollider2D>();
            minBounds = cameraBounds.bounds.min;
            maxBounds = cameraBounds.bounds.max;
        }

        //makes sure camera stays in bounds
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);


    }


    public void SetBounds(BoxCollider2D newBounds)
    {
        cameraBounds = newBounds;

        //set bounds so camera doesn't see outside game view bounds
        minBounds = cameraBounds.bounds.min;
        maxBounds = cameraBounds.bounds.max;

    }
}

