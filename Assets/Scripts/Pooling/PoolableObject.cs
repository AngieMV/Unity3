using System.Collections;
using UnityEngine;

namespace ObjectPooling
{
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
