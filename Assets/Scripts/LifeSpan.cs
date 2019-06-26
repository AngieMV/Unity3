using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    [SerializeField]
    private float _LifeSpan = 3f;

    private void Awake()
    {
        Destroy(gameObject, _LifeSpan);
    }
}
