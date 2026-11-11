using UnityEngine;

public class OnePip : Enemy
{
    // Fields
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;

    private bool _idle = true;

    // Monobehavior
    private void FixedUpdate()
    {
        if (_idle)
        {
            LookForTarget(out bool directPathFound, out Vector3 direction);

            if (directPathFound)
            {
                Attack(direction);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player playerStats))
        {
            playerStats.HP -= Damage;
        }
    }

    // Functions
    private void LookForTarget(out bool directPathFound, out Vector3 direction)
    {
        direction = _playerTransform.position - transform.position;

        directPathFound = Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, direction.magnitude);
    }

    private void Attack(Vector3 direction)
    {
        _idle = false;

        _animator.speed = AttackSpeed;
        _animator.SetTrigger("Attack");

        _rb.useGravity = true;
        _rb.AddForce(direction * MovementSpeed, ForceMode.Impulse);
    }

    /// <summary>
    /// Stop in place when the attack animation is over
    /// </summary>
    public void AttackStop()
    {
        _rb.useGravity = false;
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        _idle = true;
    }
}
