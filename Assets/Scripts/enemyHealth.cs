using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public float health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(health <= 0)
        {
            Dead();
        }
	}

    public void ApplyDamage(int TheDamage)
    {
        health -= TheDamage;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
