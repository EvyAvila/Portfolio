using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //A gameobject that will find the main player in the game to follow
    private GameObject player;
    private Transform PlayerTransform;
    
    //A float difference in the Y vector to change the height difference 
    [SerializeField] float YDifference;

    //A camera that mainly uses to change the size of the camera
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        YDifference = 1.75f;
        player = GameObject.Find("Player");
        cam = GetComponent<Camera>();
        cam.orthographicSize = 3.50f;
        PlayerTransform = player.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCamera();
    }

    //A method where the camera moves with the player along the x and z axis, while also maintaining a 
    //height difference
    void MoveCamera()
    {
        //transform.position = new Vector3(player.transform.position.x, YDifference , player.transform.position.z);
        Vector3 playerPos = PlayerTransform.position;
        transform.position = new Vector3(playerPos.x, YDifference, playerPos.z);
    }
}
