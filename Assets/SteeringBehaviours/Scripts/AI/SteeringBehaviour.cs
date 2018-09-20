using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SteeringBehaviours
{
    public abstract class SteeringBehaviour : MonoBehaviour
    {
        public float weighting;
        [HideInInspector] public AIAgent owner;

        private void Awake()
        {
            owner = GetComponent<AIAgent>();
        }

        public virtual Vector3 GetForce()
        {
            return Vector3.zero;
        }
    }
}