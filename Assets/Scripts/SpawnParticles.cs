using ObjectPooling;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField]
    private PoolableObject _Particles;

    private bool _IsDisabled;

    private void OnDisable()
    {
        if (_IsDisabled)
        {
            PoolManager.GetNext(_Particles, this.gameObject.transform.position, Quaternion.identity);
        }
        _IsDisabled = true;
    }
}
