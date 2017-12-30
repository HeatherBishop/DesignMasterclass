using UnityEngine.UI;
using UnityEngine;

public struct TimeTaken
{
    public int Minutes;
    public int Seconds;
}

public class TimeChecker : MonoBehaviour {



    [HideInInspector]
    public float timeOutTime;


    public static float gameStartTime;

    [SerializeField]
    private float timeBetweenLastInputAndTimeout = 240; //for now its set at 4 minutes to timeout

    [SerializeField]
    private Text timeTakenText;

    private void OnEnable()
    {
        TimeTaken timeTaken = GetTimeTaken();
        timeTakenText.text = "Time taken: " + timeTaken.Minutes + " Minutes and " + timeTaken.Seconds + "  Seconds"; 
    }


    public void SetTimeoutTime()
    {
        timeOutTime = Time.time + timeBetweenLastInputAndTimeout;
    }

    public TimeTaken GetTimeTaken()
    {
        TimeTaken timeTaken = new TimeTaken();
        int currentTimeTakenInSecs = (int)(Time.time - gameStartTime);
        int minutes = currentTimeTakenInSecs / 60;
        int seconds = 0;
        if(currentTimeTakenInSecs - (minutes * 60) > 0)
        {
            seconds = currentTimeTakenInSecs - (minutes * 60);
        }



        timeTaken.Minutes = minutes;
        timeTaken.Seconds = seconds;
        return timeTaken;
    }
}
