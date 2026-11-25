using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class MeleeHurtBox : MonoBehaviour
{
    // Fields
    [SerializeField] float _onHitCameraShakeStrength;
    [SerializeField] float _heavyAttackDamageMtpl;

    private Player _player;
    private CinemachineImpulseSource _mainCameraImpulseSource;

    // Monobehavior
    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<Player>();

        // the on hit impulse is directly linked to the cinemachine because
        // I don't want to have to add it to all weapons, but if we want a different shake depending on the weapon, 
        // we should totally make it a field in the weapon
        // note that I still made the force variable
        _mainCameraImpulseSource = GameObject.FindAnyObjectByType<CinemachineCamera>().gameObject.GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _mainCameraImpulseSource.GenerateImpulse(_onHitCameraShakeStrength);
            StartCoroutine(FreezeTemporarily(enemy));
        }
    }

    // my functions
    private IEnumerator FreezeTemporarily(Enemy enemy)
    {
        MyCharacterController characterController = _player.GetComponent<MyCharacterController>();
        Animator playerAnimator = _player.GetComponentInChildren<Animator>();
        float playerAnimatorSpeed = playerAnimator.speed;

        bool enemyHasAnimator = enemy.gameObject.TryGetComponent<Animator>(out Animator enemyAnimator);
        float enemyAnimatorSpeed = 0f;

        playerAnimator.speed = 0f;
        characterController.AllowInput = false;

        if (enemyHasAnimator)
        {
            enemyAnimatorSpeed = enemyAnimator.speed;
            enemyAnimator.speed = 0f;
        }

        // How long do we freeze
        // (not a yet variable because only used here and we need to discuss how variable we make it)
        yield return new WaitForSeconds(0.05f);

        playerAnimator.speed = playerAnimatorSpeed;
        characterController.AllowInput = true;

        if (enemyHasAnimator)
        {
            enemyAnimator.speed = enemyAnimatorSpeed;
        }

        ApplyDamage(enemy);
    }

    private void ApplyDamage(Enemy enemy)
    {
        float damage = _player.Damage;

        // made a switch case in case we want more things that deal extra damage later
        switch (_player.Weapon.Moveset.OnGoingAttack)
        {
            case AttackTypes.Heavy: damage *= _heavyAttackDamageMtpl; break;
            default: break;
        }

        enemy.HP -= damage;
    }
}
