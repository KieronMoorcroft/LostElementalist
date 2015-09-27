using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DamageOverTime : AbilityBehaviours {

	private const string abname = "Damage Over Time";
    private const string abdescription = "A Damage Over Time";
    private const BehaviourStartTimes startTime = BehaviourStartTimes.Beginning; // On impact
    //private Sprite icon = Resources.Load()

    private float areaRadius; //Radius of sphere collider
    private float effectDuration; //Time length of the effect
    private Stopwatch durationTimer = new Stopwatch();
    private float baseEffectDamage;

    public bool isRandomOn;
    private float lifeDistance;
    private bool isOccupied;
    private float damageTickDuration;

    public DamageOverTime(float ar, float ed, float bd)
        : base (new BasicObjectInformation(abname, abdescription),startTime)
    {
        areaRadius = ar;
        effectDuration = ed;
        baseEffectDamage = bd;
        isOccupied = false;
    }

    public override void ActivateBehaviour(GameObject objectHit)
    {
        StartCoroutine(DOT());
    }

    private IEnumerator DOT()
    {
        durationTimer.Start(); //turn on timer

        while(durationTimer.Elapsed.TotalSeconds <= effectDuration)
        {
           if(isOccupied)
           {
               //do damage
           }
           yield return new WaitForSeconds(damageTickDuration);
        }

        durationTimer.Stop();
        durationTimer.Reset();

        yield return null;
    }

}
