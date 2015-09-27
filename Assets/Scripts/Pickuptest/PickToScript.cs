using UnityEngine;
using System.Collections;

public class PickToScript : MonoBehaviour {


    public Vector3 objectPos;
    public Quaternion objectRot;
    public GameObject pickObj;
    public GameObject pickref;
    bool canpick = true;
    bool picking = false;
    bool guipick = false;
    bool holdingBall;
    public Texture2D crosshairTexture;
    public float crosshairScale = 1;
    void Start () {

	    pickref = GameObject.FindWithTag ("pickup");

	    pickObj = pickref;


    }

    void Update () {

        Ray raycheck = Camera.main.ScreenPointToRay(Input.mousePosition);

	    RaycastHit hitcheck;

	    if (Physics.Raycast(raycheck,out hitcheck, 10) && hitcheck.collider.gameObject.tag == "pickup"){



	    }

	        if (Physics.Raycast(raycheck, out hitcheck) && hitcheck.collider.gameObject.tag != "pickup"){


	        }

	        objectPos = transform.position;

	        objectRot = transform.rotation;

	        if(Input.GetMouseButtonDown(0) && canpick){

		        picking = true;

		        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

		        if (Physics.Raycast(ray,out hit, 10) && hit.collider.gameObject.tag == "pickup"){

			        pickObj = hit.collider.gameObject;

			        hit.rigidbody.useGravity = false;

			        hit.rigidbody.isKinematic = true;

			        hit.collider.isTrigger = true;
			
			        holdingBall = true;

			        hit.transform.parent = gameObject.transform;

			        hit.transform.position = objectPos;

			        hit.transform.rotation = objectRot;
                    
		        }

	        }

	        if(Input.GetMouseButtonUp(0) && picking){

		        picking = false;

		        canpick = false;

	        }
            if (Input.GetMouseButtonDown(0) && !canpick && pickObj.GetComponent<PickedUpObj>().refusethrow != true && holdingBall)
            {

                canpick = true;

                pickObj.GetComponent<Rigidbody>().useGravity = true;

                pickObj.GetComponent<Rigidbody>().isKinematic = false;

                pickObj.transform.parent = null;

                pickObj.GetComponent<Collider>().isTrigger = false;

                pickObj.GetComponent<Rigidbody>().AddForce(transform.forward * 500);

                pickObj = pickref;

                holdingBall = false;
                

            }

            if (Input.GetMouseButtonDown(1) && !canpick && pickObj.GetComponent<PickedUpObj>().refusethrow != true)
            {

                canpick = true;

                holdingBall = false;

                pickObj.GetComponent<Rigidbody>().useGravity = true;

                pickObj.GetComponent<Rigidbody>().isKinematic = false;

                pickObj.transform.parent = null;
                pickObj.GetComponent<Collider>().isTrigger = false;
                pickObj = pickref;

            }
	        
}


    void OnGUI()
    {
        //if not paused
        if (Time.timeScale != 0)
        {
            if (crosshairTexture != null)
                GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
            else
                Debug.Log("No crosshair texture set in the Inspector");
        }
    }
}
