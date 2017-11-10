using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScriptCameraMovement : MonoBehaviour {
    [SerializeField]
    bool mouseDown = false;
    [SerializeField]
    Vector2 mouseDownStartPosition;
    [SerializeField]
    Transform Cam;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            Vector2 diff = mouseDownStartPosition - GetMousePosition();
            Cam.position = Cam.position + new Vector3(diff.x, diff.y, 0);
        }
    }

    private void OnMouseDown()
    {
        mouseDown = true;
        mouseDownStartPosition = GetMousePosition();
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }

    //private void OnMouseDrag()
    //{
    //    Vector2 diff = GetMousePosition() - mouseDownStartPosition;
    //    Cam.position = Cam.position + new Vector3(diff.x, diff.y, 0);
    //}

    Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
