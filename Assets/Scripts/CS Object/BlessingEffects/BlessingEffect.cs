using System;
using System.Collections.Generic;

public abstract class BlessingEffect
{
    // Fields
    public static List<BlessingEffect> BlessingEffects = new List<BlessingEffect>();

    private BlessingEffectNames _name;
    private string _description;
    private BlessingRarities _rarity;
    // 0-5, not 1-6 for list utilities
    private List<int> _validFaces = new List<int>(); 
    // minimum number of faces
    private int _mustBeOn;
    // maximum number of faces
    private int _canBeOn;
    private Type _type;

    // Constructors
    public BlessingEffect(BlessingEffectNames name, string description, BlessingRarities rarity, List<int> validFaces, int mustBeOn, int canBeOn, Type type)
    {
        _name = name;
        _description = description;
        _rarity = rarity;
        _validFaces = validFaces;
        _mustBeOn = mustBeOn;
        _canBeOn = canBeOn;
        _type = type;

        BlessingEffects.Add(this);
    }

    // Functions
    public virtual void ApplyEffect(int face, IBlessable target)
    {
        target.BlessingEffects[face].Add(this);
    }

    public virtual void RemoveEffect(int face, IBlessable target)
    {
        target.BlessingEffects[face].Remove(this);
    }

    // getters and Setters
    public virtual BlessingEffectNames Name
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

    public virtual string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }

    public virtual BlessingRarities Rarity
    {
        get
        {
            return _rarity;
        }
        set
        {
            _rarity = value;
        }
    }

    public virtual List<int> ValidFaces
    {
        get
        {
            return _validFaces;
        }
    }

    /// <summary>
    /// minimum number of faces
    /// </summary>
    public virtual int MustBeOn
    {
        get
        {
            return _mustBeOn;
        }
        set
        {
            _mustBeOn = value;
        }
    }

    /// <summary>
    /// maximum number of faces
    /// </summary>
    public virtual int CanBeOn
    {
        get
        {
            return _canBeOn;
        }
        set
        {
            _canBeOn = value;
        }
    }

    public virtual Type BlessingEffectType
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }
}
