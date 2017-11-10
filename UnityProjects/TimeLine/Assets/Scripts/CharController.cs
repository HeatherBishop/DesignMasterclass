using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    Vector2 startPos;

    public static float distAway;

    public static float timelineYPos;

    public static float timelineMaxY;

    [HideInInspector]
    public CharacterCreation myCharacter;

    bool onMe = false;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && onMe)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            onMe = false;
        }
    }
    private void OnMouseDown()
    {
        onMe = true;
    }


    private void OnMouseUp()
    {
        if ((transform.position - new Vector3(startPos.x, startPos.y, transform.position.z)).magnitude < distAway)
        {
            //Show information

            return;
        }

        if (transform.position.y > timelineMaxY)//if above timeline
        {
            transform.position = startPos;
        }

        else//on timeline
        {
            if (CheckXPos())
            {//in right place on timeline
                SnapToTimeline();
            }
            else
            {//in wrong place on timeline
                transform.position = startPos;
            }
        }
    }

    bool CheckXPos()//Check if in right place
    {
        if (Mathf.Abs(transform.position.x - YearToXPos(myCharacter.year)) > 0.5)//close enough. 0.5 is arbitrary at this point
            return true;
        else { return false; }
    }


    void SnapToTimeline()
    {
        transform.position = new Vector3(transform.position.x, timelineYPos, transform.position.z);
    }

    public void ResetCharacter()
    {
        transform.position = startPos;
    }

    float YearToXPos(int year)
    {
        return 0;
        //a function to turn the year into xpos on timeline
    }
}
