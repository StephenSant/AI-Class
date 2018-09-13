using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameras
{
    public class MoveWithinBounds : MonoBehaviour
    {
        public float moveSpeed = 15f;
        public float zoomSpeed = 5;
        public CameraBounds camBounds;

        void LateUpdate()
        {
            // Move the camera left + right
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            Vector3 inputDir = new Vector3(inputH, 0 , inputV);
            transform.position += inputDir * moveSpeed * Time.deltaTime;
            // Zoom the camera in + out
            float inputScroll = Input.GetAxis("Mouse ScrollWheel");
            transform.position += transform.forward * inputScroll *  zoomSpeed * Time.deltaTime;
            // Cap the position to stay within camera bounds
            transform.position = camBounds.GetAdjustedPosition(transform.position);
        }
    }
}