using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Create a Character")]
public class CharacterCreation : ScriptableObject {
    public string characterName;//name of character
    public Vector2 position;//position in world space
    public Sprite sprite;//sprite to render
    public Vector2 scale;//scale of image

    [Range(100,2000)]//arbitrary right now
    public int year;
    [TextArea]
    public string itemInfo;//info given about character



}
