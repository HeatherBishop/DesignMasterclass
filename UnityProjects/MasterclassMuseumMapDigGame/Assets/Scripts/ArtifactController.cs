using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour {
    [SerializeField]
    List<CreateNewItem> Artifacts;
    public GameObject DigSite;
    List<DigSiteController> digSites;

	// Use this for initialization
	void Start () {
        foreach (CreateNewItem artifact in Artifacts)
        {
            Vector3 position = artifact.position;
            digSites.Add(Instantiate(DigSite, position, Quaternion.identity).GetComponent<DigSiteController>());
            digSites[digSites.Count - 1].myArtifact = artifact;
        }
	}

    void ResetDigSites()
    {
        foreach  (DigSiteController site in digSites)
        {
            site.ResetSprite();
        }
    }
}
