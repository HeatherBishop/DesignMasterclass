using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSiteController : MonoBehaviour {
    public MapScriptCameraMovement CamMovement;
    public CreateNewItem myArtifact;
    SpriteRenderer myRenderer;
    Sprite OriginalSprite;
    Vector2 OriginalScale;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        OriginalSprite = myRenderer.sprite;
        OriginalScale = new Vector2(transform.localScale.x,transform.localScale.y);
        CamMovement = FindObjectOfType<MapScriptCameraMovement>();
    }

    public void UpdateSprite()
    {
        transform.localScale = new Vector3(myArtifact.scale.x,myArtifact.scale.y,1);
        myRenderer.sprite = myArtifact.sprite;
    }

    public void ResetSprite()
    {
        transform.localScale = OriginalScale;
        myRenderer.sprite = OriginalSprite;
    }

    static IEnumerator UpdateUI(CreateNewItem artifact) {
        yield return new WaitForSeconds(1);
        //call UI stuff
    }

    private void OnMouseDown()
    {
        UpdateSprite();
        StartCoroutine(UpdateUI(myArtifact));
        CamMovement.enabled = false;
    }
}
