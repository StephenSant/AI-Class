using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SteeringBehaviours
{
    public class Flee : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance;

        public override Vector3 GetForce()
        {
            Vector3 direction =  owner.transform.position - target.position;
            direction.Normalize();
            return direction * owner.maxSpeed;
        }
    }
}