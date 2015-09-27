using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ability {

    private BasicObjectInformation objectInfo;
    private List<AbilityBehaviours> behaviours;
    private bool requiresTarget;
    private bool canCastOnSelf;
    private float cooldown; //secs
    private GameObject particleEffect; // needs assigned when we create the ability
    private float castTime; // seconds
    private float cost;
    private AbilityType type;

    public enum AbilityType
    {
        Spell,
        Melee
    }

    public Ability(BasicObjectInformation aBasicInfo ,List<AbilityBehaviours> abehaviours)
    {
        objectInfo = aBasicInfo;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = 0;
        requiresTarget = false;
        canCastOnSelf = false;
    }

    public Ability(BasicObjectInformation aBasicInfo, List<AbilityBehaviours> abehaviours, bool arequiresTarget, float acooldown, GameObject aparticle)
    {
        objectInfo = aBasicInfo;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = acooldown;
        requiresTarget = arequiresTarget;
        canCastOnSelf = false;
        particleEffect = aparticle;
    }

    public BasicObjectInformation AbilityInfo
    {
        get { return objectInfo; }
    }

    public float AbilityCooldown
    {
        get { return cooldown; }
    }

    public List<AbilityBehaviours> AbilityBehaviours
    {
        get { return behaviours; }
    }

    //Method that will used when ability is used
    public void UseAbility()
    {
    
    }
}
