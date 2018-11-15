using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] groups;
        public int nextIndex = 0;

        public void SpawnNext()
        {
            Instantiate(groups[nextIndex], transform.position
                , Quaternion.identity);
            nextIndex = Random.Range(0, groups.Length);
        }

        void Start()
        {
            SpawnNext();
        }
    }
}