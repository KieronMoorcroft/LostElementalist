using UnityEngine;
using System.Collections;

public class Ranged : AbilityBehaviours {

    private const string name = "Ranged";
    private const string description = "A ranged attack";
    private const BehaviourStartTimes startTime = BehaviourStartTimes.Beginning;
    //private Sprite icon = Resources.Load()

    private float minDistance;
    private float maxDistance;
    public bool isRandomOn;
    private float lifeDistance;

    public Ranged(float minDist, float maxDist, bool isRandom)
        : base (new BasicObjectInformation(name, description),startTime)
    {
        minDistance = minDist;
        maxDistance = maxDist;
        isRandomOn = isRandom;
    }

    public override void ActivateBehaviour(GameObject objectHit)
    {
        lifeDistance = isRandomOn ? Random.Range(minDistance, maxDistance) : maxDistance;

        StartCoroutine(CheckDistance(objectHit));
    }

    private IEnumerator CheckDistance(Vector3 startPosition)
    {
        float tempDistance = Vector3.Distance(startPosition, this.transform.position);
        while(tempDistance < lifeDistance)
        {
            tempDistance = Vector3.Distance(startPosition, this.transform.position);
        }

        this.gameObject.SetActive(false); //object pool code if want or destroy
        yield return null;

    }

    public float MinDistance
    {
        get { return minDistance; }
    }

    public float MaxDistance
    {
        get { return maxDistance; }
    }
}
