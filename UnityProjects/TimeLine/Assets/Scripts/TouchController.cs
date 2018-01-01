using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    public GameObject FocusedObject;
    private Vector2 mouseOffset;

    private TimeChecker timeCheck;

    public void Start()
    {
        timeCheck = GetComponent<TimeChecker>();
    }

    // Update is called once per frame
    void Update ()
    {
    

        if(Time.time >= timeCheck.lastInputTime + timeCheck.timeBetweenLastInputAndTimeout)
        {
            SceneSelection.LoadMainMenu();
        }

        //touch start
        if(Input.GetMouseButtonDown(0))
        {
            timeCheck.lastInputTime = Time.time;
            //find the gameobject we are dragging 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.tag == "Character")
            {
                if(hit.collider.GetComponent<CharController>().moveable)
                {
                    FocusedObject = hit.collider.gameObject;
                    mouseOffset = (Vector2)hit.transform.position - hit.point;
                }
            }
        }

        //touch middle
        else if(Input.GetMouseButton(0) && FocusedObject)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FocusedObject.transform.position = newPos + mouseOffset;
        }

        //touch end
        else if(Input.GetMouseButtonUp(0) && FocusedObject)
        {
            //if it's moveable it has not been placed in the right area, so snap it back to start
            if(FocusedObject.GetComponent<CharController>().moveable)
            {
                FocusedObject.transform.position = FocusedObject.GetComponent<CharController>().startPos;
            }
            //if not, then its found it's place so we put it there
            else
            {
                int closestYear = TimelineManager.Instance.FindClosest(FocusedObject.GetComponent<CharController>().CharInfo.year);
                FocusedObject.transform.position = TimelineManager.Instance.YearPositionPairs[closestYear] + TimelineManager.Instance.getOffsetToClosestDecade(closestYear);

                //and increase the correct answers
                TimelineManager.Instance.currentCorrectAnswers++;
                //if the current correct answers equals the number required
                if (TimelineManager.Instance.currentCorrectAnswers == TimelineManager.Instance.maxCorrectAnswers)
                {
                    //then load the win screen
                    SceneSelection.LoadWinScreen();
                }
            }

                FocusedObject = null;
        }
	}
}
