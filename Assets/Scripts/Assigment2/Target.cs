using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform _shootingTarget;
    
    private Rigidbody[] _rigidbody;

    public Transform ShootingTarget => _shootingTarget;
    
    private void Awake()
    {
        _rigidbody = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in _rigidbody)
        {
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out Projectile projectile)) return;
        
        foreach (var rb in _rigidbody)
        {
            rb.isKinematic = false;
        }
    }
}