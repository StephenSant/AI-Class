using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgent : MonoBehaviour
    {

        public NavMeshAgent agent;

        private Vector3 point;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if (point.magnitude > 0)
            {
                agent.SetDestination(point);
            }
        }
        public void SetTarget(Vector3 point)
        {
            this.point = point;
        }
    }
}
