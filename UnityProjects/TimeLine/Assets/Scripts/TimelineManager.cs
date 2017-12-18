using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimelineManager : MonoBehaviour
{

    private static TimelineManager instance;

    public static TimelineManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimelineManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(TimelineManager).Name;
                    instance = obj.AddComponent<TimelineManager>();
                }
            }
            return instance;
        }
    }

    
    int maxCorrectAnswers;
    public int currentCorrectAnswers;
    private TouchController touchCont;


    public int MinYear = 1800;
    public int MaxYear = 1950;
    public float CharacterOffsetFromTimeline = 1.5f;
    public int yearIncrement = 20;

    private float allowedOffsetTolerance; //the amount of allowed positional offset on the x position before a character is deemed "in the correct place"
    private float incrementPerYear;

    public float timelineYPos = -25; //the minimum y bound for the timeline

  



    private float cameraVerticalExtent;
    private float cameraHorizontalExtent;

    //debug until graphics are created//

    public GameObject timelineDot;

    //for now just equidistant positions on the screen until we get the graphic
    public Dictionary<int, Vector2> YearPositionPairs = new Dictionary<int, Vector2>();

    
    // Use this for initialization
    void Start ()
    {
        maxCorrectAnswers = FindObjectsOfType<CharController>().Length;
        touchCont = FindObjectOfType<TouchController>();
        cameraVerticalExtent = Camera.main.orthographicSize;
        cameraHorizontalExtent = cameraVerticalExtent * Screen.width / Screen.height;
        GetYearPositions();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!touchCont.FocusedObject) //if there isnt a focused game object, we no longer need to continue
            return;

        if (CheckCorrectPosition())
        {
            touchCont.FocusedObject.GetComponent<CharController>().moveable = false;
            currentCorrectAnswers++;
        }

	}

    //check to see if the circle is within the tolerance of it's position
    bool CheckCorrectPosition()
    {
        int yearToCheck = FindClosest(touchCont.FocusedObject.GetComponent<CharController>().CharInfo.year);
        if (Vector2.Distance(touchCont.FocusedObject.transform.position,YearPositionPairs[yearToCheck] + getOffsetToClosestDecade(yearToCheck)) <= allowedOffsetTolerance)
            return true;
        return false;
    }


    void GetYearPositions()
    {
        int points = 0;
        for(int i = MinYear; i < MaxYear; i+= yearIncrement)
        {
            points++;
        }
        float SpaceBetweenPoints  = (cameraHorizontalExtent * 2) / points;
        Vector2 nextPoint = new Vector2(-cameraHorizontalExtent + 1, timelineYPos);
        for(int i = 0; i < points; i++)
        {
            int currentYear = MinYear + (yearIncrement * i);
            YearPositionPairs.Add(currentYear, nextPoint);
            //if we are not at the max year
            if(i != points-1)
            {
                //then add in a year halfway between this and the next increment (to make it increments of 10 rather than 20 at current) 
                YearPositionPairs.Add(currentYear + yearIncrement / 2, new Vector2(nextPoint.x + SpaceBetweenPoints / 2, nextPoint.y));
            }

            GameObject timelinePoint = Instantiate(timelineDot, nextPoint, Quaternion.identity) as GameObject;
            timelinePoint.transform.GetComponentInChildren<TextMesh>().text = currentYear.ToString();
            nextPoint.x += SpaceBetweenPoints;
        }
        allowedOffsetTolerance = SpaceBetweenPoints / 3; //for now just set the allowed offset to be 1/3 of the space between points
        incrementPerYear = SpaceBetweenPoints / yearIncrement;

    }

    public int FindClosest(int year)
    {
        int[] years = YearPositionPairs.Keys.ToArray();
        int currentClosest = int.MaxValue;
        for (int i = 0; i < years.Length; i++)
        {
            if(Mathf.Abs(years[i] -year) < Mathf.Abs(currentClosest - year))
            {
                currentClosest = years[i];
            }
        }
        return currentClosest;
    }
    /// <summary>
    /// returns vector with the offset from the closest decade on the x axis, y axis equals 1
    /// </summary>
    /// <param name="closestYear">the closest decade to the character's date variable</param>
    public Vector2 getOffsetToClosestDecade(int closestYear)
    {
        int offset = Mathf.Abs(closestYear - touchCont.FocusedObject.GetComponent<CharController>().CharInfo.year);
        return new Vector2(incrementPerYear * offset,CharacterOffsetFromTimeline);
    }
}
