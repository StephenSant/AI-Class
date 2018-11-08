using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoHome
{
    public class OnEmpty : MonoBehaviour
    {
        public UnityEvent onEmpty;

        void Update()
        {
            if (transform.childCount == 0)
            {
                onEmpty.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}