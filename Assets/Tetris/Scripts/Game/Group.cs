using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class Group : MonoBehaviour
    {
        #region Variables
        public float fallInterval = 1.0f;
        public float holdDuration = 1.0f;
        public float fastInterval = .25f;

        private float holdTimer = 0;
        private float fallTimer = 0;
        private bool isFallingFaster = false;
        private bool isSpacePressed = false;
        private Spawner spawner;
        #endregion

        bool IsBlockOwner(int x, int y)
        {
            Grid grid = Grid.Instance;

            return grid.data[x, y] != null && grid.data[x, y].parent == transform;
        }

        bool IsValidGridPos()
        {
            Grid grid = Grid.Instance;
            foreach (Transform child in transform)
            {
                Vector2 v = grid.RoundVect2(child.position);
                if (!grid.InsideBorder(v))
                {
                    return false;
                }
                int x = (int)v.x;
                int y = (int)v.y;
                if (grid.data[x, y] != null && grid.data[x, y].parent != transform)
                {
                    // Not a valid grid pos!
                    return false;
                }
            }
            return true;
        }
        void UpdateGrid()
        {
            Grid grid = Grid.Instance;
            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    if (IsBlockOwner(x, y))
                    {
                        grid.data[x, y] = null;
                    }
                }
            }
            foreach (Transform child in transform)
            {
                Vector2 v = grid.RoundVect2(child.position);
                int x = (int)v.x;
                int y = (int)v.y;
                grid.data[x, y] = child;
                child.position = v;
            }
        }
        void MoveLeftOrRight()
        {
            Vector3 moveDir = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveDir = Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveDir = Vector3.right;
            }
            if (moveDir.magnitude > 0)
            {
                transform.position += moveDir;
                if (IsValidGridPos())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += -moveDir;
                }
            }

        }
        void MoveUpOrDown()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, 90);
                if (IsValidGridPos())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.Rotate(0, 0, -90);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                transform.position += Vector3.down;

                if (IsValidGridPos())
                {

                    UpdateGrid();
                }
                else
                {

                    transform.position += Vector3.up;
                }

                holdTimer += Time.deltaTime;

                if (holdTimer >= holdDuration)
                {
                    isFallingFaster = true;
                }
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isFallingFaster = false;
                holdTimer = 0;
            }

        }
        void DetectFullRow()
        {
            Grid.Instance.DeleteFullRows();
            spawner.SpawnNext();
            enabled = false;
        }
        void Fall()
        {
            transform.position += Vector3.down;
            if (IsValidGridPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += Vector3.up;
                DetectFullRow();
            }
        }

        // Use this for initialization
        void Start()
        {
            spawner = FindObjectOfType<Spawner>();
            if (spawner == null)
            {
                Debug.LogError("Spawner does not exist!");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSpacePressed = true;
            }
            if (isSpacePressed)
            {
                Fall();
            }
            else
            {
                MoveLeftOrRight();
                MoveUpOrDown();
                /*
                  float currentInterval = fallInterval;
                  if (isFallingFaster)
                  {
                      currentInterval = fastInterval;
                  }
                  Ternary Operators
                */
                float currentInterval = isFallingFaster ? fastInterval : fastInterval;

                fallTimer += Time.deltaTime;
                if (fallTimer >= currentInterval)
                {
                    Fall();
                    fallTimer = 0;
                }
            }
        }
    }
}
