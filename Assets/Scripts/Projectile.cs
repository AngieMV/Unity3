using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    [SerializeField]
    private float _ProjectileSpeed = 20f;

    private Rigidbody _RB;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _RB.angularVelocity = Vector3.zero;
        _RB.velocity = transform.forward * _ProjectileSpeed;
    }
}
