using System.Collections.Generic;

public abstract class BlessingEffect
{
    // Fields
    public static List<BlessingEffect> BlessingEffects = new List<BlessingEffect>();

    private BlessingEffectNames _name;
    private string _description;

    // Constructors
    public BlessingEffect(BlessingEffectNames name, string description)
    {
        _name = name;
        _description = description;

        BlessingEffects.Add(this);
    }

    // Functions
    public abstract void OnPickUp();

    public abstract void EffectOnEnemy();

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
}
