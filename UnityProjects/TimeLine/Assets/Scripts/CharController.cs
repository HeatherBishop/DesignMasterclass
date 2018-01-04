using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public Vector2 startPos;
    private SpriteRenderer characterSprites;

    [HideInInspector]
    public bool moveable = true;

    [HideInInspector]
    public CharacterCreation CharInfo;

    private void Start()
    {
        characterSprites = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }
    public void ResetCharacter()
    {
        //reset to default
        characterSprites.color = Color.white;
        transform.position = startPos;
        moveable = true;
    }
}
