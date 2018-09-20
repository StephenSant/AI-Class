using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {
        public AIAgent[] agents;
        public Transform holdingPoint;

        private void OnDrawGizmosSelected()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
        }

        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(camRay, out hit, 1000f))
                {
                    foreach (var agent in agents)
                    {
                        Seek seek = agent.GetComponent<Seek>();
                        Flee flee = agent.GetComponent<Flee>();
                        holdingPoint.position = hit.point;

                        if (seek)
                        {
                            seek.target = holdingPoint;
                        }

                        if (flee)
                        {
                            flee.target = holdingPoint;
                        }
                    }
                }
            }
        }
    }
}