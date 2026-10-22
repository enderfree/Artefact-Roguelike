using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// A Moveset is mostly a mapping between an input and an animation
/// </summary>
public abstract class Moveset
{
    // Fields
    public static Dictionary<MovesetNames, Moveset> Movesets = new Dictionary<MovesetNames, Moveset>();

    [SerializeField] private MovesetNames _name;
    [SerializeField] private Animator _animator;
    [SerializeField] private Type _type;

    public Dictionary<string, Action> Combos = new Dictionary<string, Action>();
    public List<string> PotentiallyMatchingCombos;
    protected string _pendingCombo = "";

    // Constructors
    public Moveset(MovesetNames name, Type type, Animator animator)
    {
        _name = name;
        _animator = animator;
        _type = type;

        Movesets.Add(name, this);
    }

    // Functions
    public virtual void HandleComboes(char actionUnicode)
    {
        if (_pendingCombo == "")
        {
            PotentiallyMatchingCombos = new List<string>(Combos.Keys);
        }

        _pendingCombo += actionUnicode;

        List<string> potentiallyMatchingComboes = PotentiallyMatchingCombos;
        int i = _pendingCombo.Length - 1;

        foreach (string combo in potentiallyMatchingComboes)
        {
            if (combo.Length >= _pendingCombo.Length && 
                combo[i] == _pendingCombo[i])
            {
                if (combo.Length == _pendingCombo.Length)
                {
                    Combos[_pendingCombo]();
                    _pendingCombo = "";
                }
            } 
            else 
            {
                PotentiallyMatchingCombos.Remove(combo);
            }
        }
    }

    // Getters and Setters
    public virtual Animator MovesetAnimator
    {
        get
        {
            return _animator;
        }
        set
        {
            _animator = value;
        }
    }

    public virtual Type MovesetType
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

    public virtual MovesetNames Name
    {
        get
        {
            return _name;
        }
    }
}
