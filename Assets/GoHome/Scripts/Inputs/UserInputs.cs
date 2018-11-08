using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoHome
{
    public class UserInputs : MonoBehaviour
    {
        public PlayerController player;

        void Update()
        {
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            player.Move(inputH, inputV);
        }
    }
}