﻿using System.Collections;
using UnityEngine;

namespace ObjectPooling
{
    public class PoolableObject : MonoBehaviour
    {
        [SerializeField]
        private float _LifeSpan = 3f;

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
        }
    }
}
