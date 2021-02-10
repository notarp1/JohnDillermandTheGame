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
        float rounded_x = RoundToNearestPixel(player.transform.position.x);
        float rounded_y = RoundToNearestPixel(player.transform.position.y);
        camera.transform.position = new Vector3(rounded_x, rounded_y, -10);
    }

    float pixelToUnits = 1000f;
    public float RoundToNearestPixel(float unityUnits)
    {
        float valueInPixels = unityUnits * pixelToUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float roundedUnityUnits = valueInPixels * (1 / pixelToUnits);
        return roundedUnityUnits;
    }
}
