using UnityEngine;
using System.Collections;

namespace NSManager
{

    public class raycastShooting : MonoBehaviour
    {

        public Texture2D crosshairTexture;
        public float crosshairScale = 1;
        public GameObject BasicAttack;
        public Transform Effect;
        public float TheDamage = 100;
        public float range = 1000;
        public float force = 1000;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0f, 0.5f, 0));

            if (Input.GetMouseButton(0))
            {

                if (Physics.Raycast(ray, out hit, range))
                {
                    
                    Rigidbody.Instantiate(BasicAttack, Effect.position, Effect.rotation);
                    
                       if(Vector3.Distance(transform.position, BasicAttack.transform.position) > 20)
                       {
                           Destroy(BasicAttack);
                       }
                    
                    hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
                }
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
}
