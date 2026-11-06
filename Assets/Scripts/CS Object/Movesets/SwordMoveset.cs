using UnityEngine;

public class SwordMoveset : Moveset
{
    public SwordMoveset(Animator animator) : base(MovesetNames.Sword, typeof(SwordMoveset), animator)
    {

    }

    public void LightAttack()
    {
        MovesetAnimator.SetTrigger("LightAttack1");
    }

    public void HeavyAttack()
    {
        MovesetAnimator.SetTrigger("HeavyAttack");
    }
}
