using UnityEngine;
using System.Collections;

public class AbilityBehaviours : MonoBehaviour {


    private BasicObjectInformation objectInfo;
    private BehaviourStartTimes startTime;
    
    public AbilityBehaviours(BasicObjectInformation basicInfo, BehaviourStartTimes sTime)
    {
        objectInfo = basicInfo;
        startTime = sTime;
    }

    public enum BehaviourStartTimes
    {
        Beginning,
        Middle,
        End
    }

    //We want a gameobject, our target
    public virtual void ActivateBehaviour(GameObject objectHit)
    {
        Debug.Log("Need to add behaviour");
    }

   public BasicObjectInformation AbilityBehavioursInfo
    {
        get { return objectInfo; }
    }

    public BehaviourStartTimes AbilityBehaviourStartTime
   {
       get { return startTime; }
   }

}
