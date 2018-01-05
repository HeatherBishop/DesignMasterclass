using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DigSiteController : MonoBehaviour {
    
    public CreateNewItem myArtifact;

    SpriteRenderer myRenderer;
    Sprite OriginalSprite;
    Vector2 OriginalScale;
    int dig =4;
    [SerializeField]

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        OriginalSprite = myRenderer.sprite;
        OriginalScale = new Vector2(transform.localScale.x,transform.localScale.y);
        
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
        dig = 4;
    }


    private void OnMouseDown()
    {
        if (dig < 0 || CanvasController.instance.questionCanvas.activeSelf || CanvasController.instance.informationCanvas.activeSelf)
        {
            Debug.Log("AAAAAa");
            return;
        }
        Debug.Log("YAYAY");
        Debug.Log(dig);
        CanvasController.instance.PlayParticleSystem(dig-1,transform.position);
        Debug.Log("YAYAY");
        if(--dig == 0)
        {
            UpdateSprite();
            CanvasController.instance.StartQuestion(myArtifact);
        }
        //Dig particles
        
    }
}
