using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSiteController : MonoBehaviour {
    CameraController Cam;
    public CreateNewItem myArtifact;
    SpriteRenderer myRenderer;
    Sprite OriginalSprite;
    Vector2 OriginalScale;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        OriginalSprite = myRenderer.sprite;
        OriginalScale = new Vector2(transform.localScale.x,transform.localScale.y);
    }

    public void UpdateSprite()
    {
        transform.localScale = myArtifact.scale;
        myRenderer.sprite = myArtifact.image;
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
        Cam.enabled = false;
    }
}
