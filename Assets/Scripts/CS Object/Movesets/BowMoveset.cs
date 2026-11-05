using System;
using UnityEngine;

public class BowMoveset : Moveset
{
    public BowMoveset(Animator animator) : base(MovesetNames.Bow, typeof(BowMoveset), animator)
    {
    }
}
