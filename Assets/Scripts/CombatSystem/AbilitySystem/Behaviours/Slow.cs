using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Slow : AbilityBehaviours {

	 private const string abname = "Slow";
    private const string abdescription = "Slow objects";
    private const BehaviourStartTimes startTime = BehaviourStartTimes.End; // On impact
    //private Sprite icon = Resources.Load()

 

    private float effectDuration; //Time length of the effect
    private float slowPercent;


    public Slow(float ed, float sp)
        : base (new BasicObjectInformation(abname, abdescription),startTime)
    {
        slowPercent = sp;
        effectDuration = ed;
    }

    public override void ActivateBehaviour(GameObject objectHit)
    {
       
        StartCoroutine(SlowMovement(objectHit));
    }

    private IEnumerator SlowMovement(GameObject objectHit)
    {
        //if(objectHit.GetComponent<"Movement">>() != null)

        //finding the object get movement variable apply percentage slow
        //apply percent slow var to movement
        yield return new WaitForSeconds(effectDuration);

        //reset movement objects movements speed

        yield return null;
    }
}
