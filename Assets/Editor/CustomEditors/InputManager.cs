using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {


    public GameObject window;
    public bool isAlive = true;

	// Use this for initialization
	void Start () 
    {
        Debug.Log(isAlive);
        Debug.Log(isAlive.ConvertBoolToString());
	}
	
	// Update is called once per frame
	void Update ()
    {
	        if (Input.GetKeyDown(KeyCode.I))
            {
                window.TurnGameObjectOnAndOff();
            }
	}
}
