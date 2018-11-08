using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoHome
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 10;
        public float maxVelocity = 20;
        public Rigidbody rigid;

        private void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Collectable collectable = other.GetComponent<Collectable>();
            if (collectable)
            {
                collectable.Collect();
            }
        }

        public void Move(float inputH, float inputV)
        {
            Vector3 direction = new Vector3(inputH, 0, inputV);
            rigid.velocity = direction * speed;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(rigid.velocity);
            }
        }
    }
}
