using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float camXMin;
    public float camXMax;
    public float camYMin;
    public float camYMax;


	void Update () {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, camXMin, camXMax),
                                         Mathf.Clamp(transform.position.y, camYMin, camYMax),
                                         transform.position.z);
    }

    
}
