using UnityEngine;
using System.Collections;

public class PickedUpObj : MonoBehaviour {

    public bool refusethrow = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void OnTriggerEnter (Collider other) {

	    if (other.gameObject.tag != "Player" && other.gameObject.tag != "pickto"){ refusethrow = true;}


    }

      public void OnTriggerExit (Collider other) {

	    if (other.gameObject.tag != "Player" && other.gameObject.tag != "pickto"){ refusethrow = false;}
	
	
    }
}
