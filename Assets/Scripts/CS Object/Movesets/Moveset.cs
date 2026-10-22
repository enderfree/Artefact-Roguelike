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

    public Dictionary<string, Action> _combos = new Dictionary<string, Action>();
    public List<string> _potentiallyMatchingCombos;
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
    public virtual void HandleComboes(char actionUTFcode)
    {
        if (_pendingCombo == "")
        {
            _potentiallyMatchingCombos = new List<string>(_combos.Keys);
        }

        _pendingCombo += actionUTFcode;

        List<string> potentiallyMatchingComboes = _potentiallyMatchingCombos;
        int i = _pendingCombo.Length - 1;

        foreach (string combo in potentiallyMatchingComboes)
        {
            if (combo.Length >= _pendingCombo.Length && 
                combo[i] == _pendingCombo[i])
            {
                if (combo.Length == _pendingCombo.Length)
                {
                    _combos[_pendingCombo]();
                    _pendingCombo = "";
                }
            } 
            else 
            {
                _potentiallyMatchingCombos.Remove(combo);
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
