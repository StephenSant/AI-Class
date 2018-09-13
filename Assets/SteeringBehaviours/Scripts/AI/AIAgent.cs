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
        private SteeringBehaviour[] behaviours;
        private NavMeshAgent agent;

        private void Awake()
        {
            behaviours = GetComponents<SteeringBehaviour>();
            agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
        private void ComputeForces()
        {
            velocity = Vector3.zero; 
            for (int i = 0; i < behaviours.Length; i++)
            {
                Vector3 force = behaviours[i].GetForce();
                velocity += force;
            }
        }
        private void ApplyVelocity()
        {
            Vector3 point = transform.position + velocity * Time.deltaTime;
            agent.SetDestination(point);
        }
    }
}
