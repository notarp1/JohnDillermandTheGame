using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera");
    
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
