using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {
        public AIAgent agent;
        public Transform holdingPoint;
        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Try to get seek component on agent
                Seek seek = agent.GetComponent<Seek>();
                // if seek is not null
                if (seek)
                {
                    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(camRay, out hit, 1000f))
                    {
                        holdingPoint.position = hit.point;
                        seek.target = holdingPoint;
                    }
                }
            }
        }
    }
}