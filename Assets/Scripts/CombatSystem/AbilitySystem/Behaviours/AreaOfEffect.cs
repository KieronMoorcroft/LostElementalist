using UnityEngine;
using System.Collections;
using System.Diagnostics;

[RequireComponent(typeof(SphereCollider))]
public class AreaOfEffect : AbilityBehaviours {

    private const string abname = "Area Of Effect";
    private const string abdescription = "A AOE damage";
    private const BehaviourStartTimes startTime = BehaviourStartTimes.End; // On impact
    //private Sprite icon = Resources.Load()

    private float areaRadius; //Radius of sphere collider
    private float effectDuration; //Time length of the effect
    private Stopwatch durationTimer = new Stopwatch();
    private float baseEffectDamage;

    public bool isRandomOn;
    private float lifeDistance;
    private bool isOccupied;
    private float damageTickDuration;

    public AreaOfEffect(float ar, float ed, float bd)
        : base (new BasicObjectInformation(abname, abdescription),startTime)
    {
        areaRadius = ar;
        effectDuration = ed;
        baseEffectDamage = bd;
        isOccupied = false;
    }

    public override void ActivateBehaviour(GameObject objectHit)
    {
        SphereCollider sc = this.gameObject.GetComponent<SphereCollider>();

       /* if(this.gameObject.GetComponent<SphereCollider>() == null)
            sc = this.gameObject.AddComponent<SphereCollider>();
        else
             sc = this.gameObject.GetComponent<SphereCollider>();
        */
        sc.radius = areaRadius;
        sc.isTrigger = true;

        StartCoroutine(AOE());
    }

    private IEnumerator AOE()
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

    private void OnTriggerEnter(Collider other)
    {
        if(isOccupied)
        {
            //onDamage(list<target>,base damage);
        }
        else
        {

        }

        isOccupied = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
    }
}
