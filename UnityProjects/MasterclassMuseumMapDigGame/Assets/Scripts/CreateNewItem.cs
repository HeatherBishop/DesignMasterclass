using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Artifact",menuName = "Create an Artifact")]
public class CreateNewItem : ScriptableObject {

    public string itemName;//name of artifact
    public Vector2 position;//position in world space
    public Sprite sprite;//sprite to render
    public Vector2 scale;//scale of image



    public string question;//question about the item
    public string questionInfo;
    [SerializeField]
    public List<string> answers = new List<string>(4);//the 4 answers
    [Range(1,4)]
    public int correctAnswer;
    [TextArea]
    public string itemInfo;//info given about artifact
}
