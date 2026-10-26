using System.Collections.Generic;
using UnityEngine;

public class Blessing: MonoBehaviour
{
    // Fields
    public static List<Blessing> Blessings;

    // Maybe replace that by a name generator?
    private BlessingNames _name;
    private BlessingEffect _p1Effect;
    private BlessingEffect _p2Effect;

    // Constructor
    public Blessing(BlessingNames name, BlessingEffect p1Effect, BlessingEffect p2Effect)
    {
        _name = name;
        _p1Effect = p1Effect;
        _p2Effect = p2Effect;

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

    public virtual BlessingEffect P1Effect
    {
        get
        {
            return _p1Effect;
        }
        set
        {
            _p1Effect = value;
        }
    }

    public virtual BlessingEffect P2Effect
    {
        get
        {
            return _p1Effect;
        }
        set
        {
            _p1Effect = value;
        }
    }
}
