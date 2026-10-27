using System.Collections.Generic;

public abstract class BlessingEffect
{
    // Fields
    public static List<BlessingEffect> BlessingEffects = new List<BlessingEffect>();

    private BlessingEffectNames _name;
    private string _description;
    private BlessingRarities _rarity;
    private List<int> _validFaces = new List<int>();

    // Constructors
    public BlessingEffect(BlessingEffectNames name, string description, BlessingRarities rarity, List<int> validFaces)
    {
        _name = name;
        _description = description;
        _rarity = rarity;
        _validFaces = validFaces;

        BlessingEffects.Add(this);
    }

    // Functions
    public abstract void ApplyEffect();

    public abstract void RemoveEffect();

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
}
