using ObjectPooling;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField]
    private GameObject _NotPooledBullet;

    [SerializeField]
    private PoolableObject _PooledBullet;

    [SerializeField]
    private PoolableObject _ExploitablePooledBullet;

    [SerializeField]
    private PoolableObject _PooledParticles;

    private void Start()
    {
        PoolManager.CreatePool(_PooledBullet, 3);
        PoolManager.CreatePool(_ExploitablePooledBullet, 3);
        PoolManager.CreatePool(_PooledParticles, 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            System.GC.Collect();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(_NotPooledBullet, Vector3.left, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PoolManager.GetNext(_PooledBullet, Vector3.right, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PoolManager.GetNext(_ExploitablePooledBullet, Vector3.right, Quaternion.identity);
        }
    }

}
