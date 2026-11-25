using System.Collections;
using UnityEngine;

public class MeleeHurtBox : MonoBehaviour
{
    // Fields
    private Player _player;

    // Monobehavior
    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
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

        enemy.HP -= _player.Damage;
    }
}
