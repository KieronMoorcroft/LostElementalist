using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public GameObject FireballPrefab;
    public float fireball_speed = 15;
    public float fireballLifespan = 1;
    public float fireball_range = 100;
    public float TheDamage = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0f, 0.5f, 0));
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            if (Physics.Raycast(ray, out hit, fireball_range))
            {
                FireballSpell();
                FireballPrefab.transform.Translate(0, 0, fireball_speed * Time.deltaTime);
                hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    public void FireballSpell()
    {
        Rigidbody.Instantiate(FireballPrefab, transform.position, transform.rotation);
        Destroy(gameObject, fireballLifespan);
    }
}
