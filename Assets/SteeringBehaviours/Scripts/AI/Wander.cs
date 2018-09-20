using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;
namespace SteeringBehaviours
{
    public class Wander : SteeringBehaviour
    {
        #region Variables
        public float offset = 1.0f;
        public float radius = 1.0f;
        public float jitter = 0.2f;

        private Vector3 targetDir;
        private Vector3 randomDir;
        #endregion

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            float randX = Random.Range(0, 0x7fff) - (0x7fff / 2);
            float randZ = Random.Range(0, 0x7fff) - (0x7fff / 2);
            #region Calculate RandomDir
            randomDir = new Vector3(randX, 0, randZ);
            randomDir.Normalize();
            randomDir *= jitter;
            #endregion
            
            #region Calculate TargetDir
            targetDir += randomDir;
            targetDir.Normalize();
            targetDir *= radius;
            #endregion

            Vector3 seekPos = transform.position + targetDir;
            seekPos += transform.forward * offset;

            #region GizmosGL
            GizmosGL.color = Color.red;
            GizmosGL.AddCircle(seekPos + Vector3.up * .11f, .5f, Quaternion.LookRotation(Vector3.down));
            Vector3 offsetPos = transform.position + transform.forward * offset;

            GizmosGL.color = Color.blue;
            GizmosGL.AddCircle(offsetPos + Vector3.up * .1f, radius, Quaternion.LookRotation(Vector3.down));

            GizmosGL.color = Color.cyan;
            GizmosGL.AddLine(transform.position, offsetPos, .1f, .1f);
            #endregion

            Vector3 direction = seekPos - transform.position;
            Vector3 desiredForce = Vector3.zero;
            if (direction != Vector3.zero)
            {
                desiredForce = direction.normalized * weighting;
                force = desiredForce - owner.velocity;
            }

            return force;
        }
    }
}