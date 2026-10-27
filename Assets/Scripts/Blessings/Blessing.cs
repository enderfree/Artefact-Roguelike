using System.Collections.Generic;
using UnityEngine;

public class Blessing: MonoBehaviour
{
    // Fields
    public static List<Blessing> Blessings;

    // Maybe replace that by a name generator?
    private BlessingNames _name;
    private BlessingEffect _effect;
    private BlessingEffect _curse;

    // Constructor
    public Blessing(BlessingNames name, BlessingEffect effect, BlessingEffect curse)
    {
        _name = name;
        _effect = effect;
        _curse = curse;

        Blessings.Add(this);
    }

    // Getters and Setters
    public virtual BlessingNames Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public virtual BlessingEffect Effect
    {
        get
        {
            return _effect;
        }
        set
        {
            _effect = value;
        }
    }

    public virtual BlessingEffect Curse
    {
        get
        {
            return _curse;
        }
        set
        {
            _curse = value;
        }
    }
}
