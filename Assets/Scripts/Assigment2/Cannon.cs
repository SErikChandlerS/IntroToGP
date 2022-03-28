using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private const float AimTime = 0.3f;
    [SerializeField] private float _maxHorizontalAngle = 45f;
    [SerializeField] private float _cooldown = 1.5f;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Transform _cannonModel;

    private readonly List<Target> _activeTargets = new List<Target>();
    private Target _chosenTarget;
    private float _timer;

    private void Awake()
    {
        _activeTargets.AddRange(FindObjectsOfType<Target>());
    }

    private void Update()
    {
        if (_timer < _cooldown)
        {
            _timer += Time.deltaTime;
            return;
        }

        _timer = 0;

        FindTargetAndShoot();
    }

    private void FindTargetAndShoot()
    {
        var availableTargets = _activeTargets.FindAll(CheckTargetAngleDelta);
        
        if (availableTargets.Count <= 0) return;
        
        _chosenTarget = availableTargets[Random.Range(0, availableTargets.Count)];

        _activeTargets.Remove(_chosenTarget);
        _cannonModel.DOLookAt(_chosenTarget.transform.position, AimTime, AxisConstraint.Y).OnComplete(ShootProjectile);
    }


    private bool CheckTargetAngleDelta(Target target)
    {
        var targetDir = target.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        return angle <= _maxHorizontalAngle;
    }
    
    private void ShootProjectile()
    {
        var newProjectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
        var direction = _chosenTarget.ShootingTarget.position - _projectileSpawnPoint.position;

        newProjectile.Shoot(direction.normalized);
    }
}