using System;
using System.Collections.Generic;
using UnityEngine;

public class StatMod : BlessingEffect
{
    private PlayerStatNames _targetedStat;
    private float _multiplyer;

    public StatMod(PlayerStatNames targetedStat, float multiplyer, List<int> validFaces, int mustBeOn, int canBeOn) : base(
        BlessingEffectNames.StatMod, 
        targetedStat.ToString() + (multiplyer < 1 ? "Down!": "Up!"),
        (multiplyer < 1 ? BlessingRarities.Curse : BlessingRarities.Boon), 
        validFaces, 
        mustBeOn, 
        canBeOn, 
        typeof(StatMod))
    {
        _targetedStat = targetedStat;
        _multiplyer = multiplyer;
    }

    public override void ApplyEffect(IBlessable target)
    {
        switch (TargetedStat)
        {
            case PlayerStatNames.Health:
                target.HP *= Multiplyer;
                target.MaxHP *= Multiplyer;
                break;
            default: 
                Debug.Log("StatMod/ApplyEffect: Blessing modifies an unhandled stat.");
                break;
        }
    }

    public override void RemoveEffect(IBlessable target)
    {
        switch (TargetedStat)
        {
            case PlayerStatNames.Health:
                target.MaxHP /= Multiplyer;
                target.HP /= Multiplyer;
                break;
            default:
                Debug.Log("StatMod/RemoveEffect: Blessing modifies an unhandled stat.");
                break;
        }
    }

    public PlayerStatNames TargetedStat
    {
        get
        {
            return _targetedStat;
        }
    }

    public float Multiplyer
    {
        get
        {
            return _multiplyer;
        }
    }
}
