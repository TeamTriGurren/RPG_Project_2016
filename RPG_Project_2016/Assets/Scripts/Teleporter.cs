using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public GameObject teleportLoc;
    public string regionChange;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Other.transform.position = teleportLoc.transform.position;
            PlayerMovement.region = regionChange;
        }
    }

  
}
