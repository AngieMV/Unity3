using System.Collections;
using UnityEngine;

namespace ObjectPooling
{
    /// <summary>
    /// Sets the object as a <see cref="PoolableObject"/>, with a specific <see cref="_LifeSpan"/>. Once disabled, it gets back to the <see cref="PoolManager"/>.
    /// </summary>
    public class PoolableObject : MonoBehaviour
    {
        [SerializeField]
        private float _LifeSpan = 3f;

        [HideInInspector]
        public int Id;

        private void OnEnable()
        {
            StartCoroutine(Disabler());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Disabler()
        {
            yield return new WaitForSeconds(_LifeSpan);
            gameObject.SetActive(false);
            PoolManager.AddObjectToPool(this);
        }
    }
}
