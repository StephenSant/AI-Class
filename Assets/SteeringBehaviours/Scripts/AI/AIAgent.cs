using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SteeringBehaviours
{
    public class AIAgent : MonoBehaviour
    {
        public float maxSpeed=10;
        public float maxDis=5;
        public bool updatePos=true, updateRot=true;
        public Vector3 velocity;

        private Vector3 force;
        private List<SteeringBehaviour> behaviours;
        private NavMeshAgent agent;

        private void Awake()
        {
            
        }
        private void Update()
        {
            
        }
        private void ComputeForces()
        {

        }
        private void ApplyVelocity()
        {

        }
    }
}
