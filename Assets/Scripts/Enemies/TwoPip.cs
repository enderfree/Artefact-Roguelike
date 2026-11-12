using UnityEngine;

public class TwoPip : Enemy
{
    // Fields
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _animator;
    [SerializeField] private LineRenderer _lr;
    [SerializeField] private Vector3 _laserHeightAdjustment;
    [SerializeField] private float _laserMaxRange;
    [SerializeField] private float _laserGrowthRate; 

    private bool _idle = true;
    private bool _laserOn = false;
    private float _laserSize = 0f;

    // Monobehaviour
    private void FixedUpdate()
    {
        Vector3 direction = _playerTransform.position - transform.position;

        if (_idle)
        {
            if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, direction.magnitude))
            {
                _idle = false;

                _animator.speed = AttackSpeed;
                _animator.SetTrigger("Attack");
            }
        }
        else
        {
            // transform.LookAt(_playerTransform); // too eficient
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                Quaternion.LookRotation(direction), 
                MovementSpeed * Time.fixedDeltaTime
            );

            if (_laserOn)
            {
                LaserSize += _laserGrowthRate * Time.fixedDeltaTime;

                _lr.SetPosition(0, transform.position + _laserHeightAdjustment);
                _lr.SetPosition(1, GetEndOfTheLine() + _laserHeightAdjustment);

                // Physics.BoxCast(_lr.GetPosition(0), new Vector3(0.5f, 0.5f, 0.05f), direction.normalized, out RaycastHit hit, Quaternion.LookRotation(direction), LaserSize);
                Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, LaserSize);

                if (hit.collider != null && hit.collider.gameObject.TryGetComponent<IBlessable>(out IBlessable blessable))
                {
                    blessable.HP -= Damage * Time.fixedDeltaTime;
                }
            }
        }
    }

    // Functions
    private Vector3 GetEndOfTheLine()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, LaserSize))
        {
            return hit.point;
        }
        else
        {
            return transform.forward * LaserSize;
        }
    }

    // Called by Animation
    public void FireLaser()
    {
        _laserOn = true;
    }

    public void StopLazer()
    {
        _laserOn = false;

        _lr.SetPosition(0, Vector3.zero);
        _lr.SetPosition(1, Vector3.zero);

        LaserSize = 0f;
    }

    public void AttackStop()
    {
        _idle = true;
    }

    // Getters and Setters
    private float LaserSize
    {
        get
        {
            return 100f; //_laserSize;
        }
        set
        {
            _laserSize = value;

            if (_laserSize > _laserMaxRange)
            {
                _laserSize = _laserMaxRange;
            }
        }
    }
}
