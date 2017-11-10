using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {

    public List<CharacterCreation> Characters;
    // Use this for initialization
    List<CharController> ControlList;
    public GameObject BaseCharacter;
	void Start () {
        foreach (CharacterCreation character in Characters)
        {
            Vector3 pos = new Vector3(character.position.x, character.position.y, transform.position.z);
            CharController newChar = Instantiate(BaseCharacter, pos, Quaternion.identity).GetComponent<CharController>();
            newChar.myCharacter = character;
            ControlList.Add(newChar);
        }
	}

    private void ResetCharacters()
    {
        foreach (CharController character in ControlList)
        {
            character.ResetCharacter();
        }
    }
}
