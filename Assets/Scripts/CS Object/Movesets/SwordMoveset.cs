using UnityEngine;

public class SwordMoveset : Moveset
{
    public SwordMoveset(Animator animator) : base(MovesetNames.Sword, typeof(SwordMoveset), animator)
    {

    }

    public void LightAttack()
    {
        OnGoingAttack = AttackTypes.Light;
        MovesetAnimator.SetTrigger("LightAttack1");
    }

    public void HeavyAttack()
    {
        OnGoingAttack = AttackTypes.Heavy;
        MovesetAnimator.SetTrigger("HeavyAttack");
    }
}
