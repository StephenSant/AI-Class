using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SteeringBehaviours
{
    public class CameraBounds : MonoBehaviour
    {
        public Vector3 size = new Vector3(50, 0, 20);

        public Vector3 GetAdjustedPosition(Vector3 incomingPos)
        {
            Vector3 pos = transform.position;
            Vector3 halfSize = size * 0.5f;
            
            if (incomingPos.x > pos.x + halfSize.x)
            {
                incomingPos.x = pos.x + halfSize.x;
            }
            if (incomingPos.x < pos.x - halfSize.x)
            {
                incomingPos.x = pos.x - halfSize.x;
            }
            if (incomingPos.y > pos.y + halfSize.y)
            {
                incomingPos.y = pos.y + halfSize.y;
            }
            if (incomingPos.y < pos.y - halfSize.y)
            {
                incomingPos.y = pos.y - halfSize.y;
            }
            if (incomingPos.z > pos.z + halfSize.z)
            {
                incomingPos.z = pos.z + halfSize.z;
            }
            if (incomingPos.z < pos.z - halfSize.z)
            {
                incomingPos.z = pos.z - halfSize.z;
            }
            return Vector3.zero;
        }
        // Update is called once per frame
        void Update()
        {
            GetAdjustedPosition(transform.position);
        }
    }
}