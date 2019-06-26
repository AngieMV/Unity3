using ObjectPooling;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField]
    private GameObject _NotPooledBullet;

    [SerializeField]
    private PoolableObject _PooledBullet;

    private void Start()
    {
        PoolManager.CreatePool(_PooledBullet, 3);
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
    }

}
