using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public Vector2 startPos;

    [HideInInspector]
    public bool moveable = true;

    [HideInInspector]
    public CharacterCreation CharInfo;

    private void Start()
    {
        startPos = transform.position;
    }
    private Vector2 YearToPosition()
    {
        //convert the year to the position on the timeline
        return Vector2.zero;

    }
    public void ResetCharacter()
    {
        //reset to default
        transform.position = startPos;
        moveable = true;
    }
}
