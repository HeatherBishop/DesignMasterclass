using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour {
    [SerializeField]
    List<CreateNewItem> Artifacts = new List<CreateNewItem>();
    public GameObject DigSite;
    List<DigSiteController> digSites = new List<DigSiteController>();

	// Use this for initialization
	void Start () {
        foreach (CreateNewItem artifact in Artifacts)
        {
            Vector3 position = artifact.position;
            DigSiteController tempDigSite = Instantiate(DigSite, position, Quaternion.identity).GetComponent<DigSiteController>();
            
            tempDigSite.myArtifact = artifact;
            digSites.Add(tempDigSite);
        }
        ResetDigSites();
	}

    void ResetDigSites()
    {
        foreach  (DigSiteController site in digSites)
        {
            site.ResetSprite();
        }
    }
}
