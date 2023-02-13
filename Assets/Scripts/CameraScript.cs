using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        transform.position = player.transform.position + new Vector3(0, 15, -12);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y, player.position.z -12);
    }
}
