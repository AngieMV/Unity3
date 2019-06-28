using ObjectPooling;
using UnityEngine;

/// <summary>
/// Spawn a <see cref="PoolableObject" /> as Particles when the game object gets disabled.
/// </summary>
public class SpawnParticles : MonoBehaviour
{
    [SerializeField]
    private PoolableObject _Particles;

    private void OnDisable()
    {
        PoolManager.GetNext(_Particles, this.gameObject.transform.position, Quaternion.identity);   
    }
}
