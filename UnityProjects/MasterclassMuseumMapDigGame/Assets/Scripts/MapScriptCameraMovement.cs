using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScriptCameraMovement : MonoBehaviour {
    #region Variables
    bool mouseDown = false;
    Vector2 mouseDownStartPosition;
    [SerializeField]
    Transform Cam;
    [SerializeField]
    float camXMin;
    [SerializeField]
    float camXMax;
    [SerializeField]
    float camYMin;
    [SerializeField]
    float camYMax;
    [SerializeField]
    float minZoom;
    [SerializeField]
    float maxZoom;   
    float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    Touch touchZero;
    Touch touchOne;
    [SerializeField]
    float deltaTimeOut = 0.1f;
    Vector3 cameraOrigin;
    #endregion

    void Update()
    {
        if (mouseDown)
        {
            // If there are two touches on the device...
            if (Input.touchCount == 1)
            {
                MoveCamera();
            }

            else if (Input.touchCount >= 2)
            {
                ZoomCamera();
            }
        }
    }

    private void OnMouseDown()
    {
        mouseDown = true;
        cameraOrigin = GetMousePosition();
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        cameraOrigin = GetMousePosition();
    }

    
    private void MoveCamera()
    {
        //    if (Input.GetTouch(0).deltaTime > deltaTimeOut)
        //    {

        //    }
        Vector3 diff = GetMousePosition()- cameraOrigin;

        Cam.position = Cam.position - diff;

        
        Cam.position = new Vector3(
                                    Mathf.Clamp(Cam.position.x, camXMin, camXMax),
                                    Mathf.Clamp(Cam.position.y, camYMin, camYMax),
                                    Cam.position.z
                                    );
    }

    private void ZoomCamera()
    {
        touchZero = Input.GetTouch(0);
        touchOne = Input.GetTouch(1);
        if(touchOne.deltaTime > deltaTimeOut || touchZero.deltaTime > deltaTimeOut)
        {
            return;
        }

        // Find the position in the previous frame of each touch.
        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
        
            
            // ... change the orthographic size based on the change in distance between the touches.
            Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

            // Make sure the orthographic size never drops below zero.
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom,maxZoom);
        

        
}

    Vector3 GetMousePosition()
    {     
        return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); 
    }

    private void OnDisable()
    {
        Cam.position = GetMousePosition();
    }
}
