using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris
{
    public class Grid : MonoBehaviour
    {
        #region Singleton
        public static Grid Instance;
        private void Awake()
        {
            Instance = this;
        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        public int width = 10, height = 20;
        public Transform[,] data;

        private void OnDrawGizmos()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.DrawWireCube(new Vector3(x, y), Vector3.one);
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            data = new Transform[width, height];
        }

        public bool InsideBorder(Vector2 pos)
        {
            int x = (int)pos.x;
            int y = (int)pos.y;
            if (x >= 0 && x < width && y >= 0)
            {
                return true;
            }
            return false;
        }
        public void DeleteRow(int y)
        {
            for (int x = 0; x < width; x++)
            {
                Destroy(data[x, y].gameObject);
                data[x, y] = null;
            }
        }
        public void DecreaseRow(int y)
        {
            for (int x = 0; x < width; x++)
            {
                if (data[x, y] != null)
                {
                    data[x, y - 1] = data[x, y];
                    data[x, y] = null;
                    data[x, y - 1].position += Vector3.down;
                }     
            }
        }

        public void DecreaseRowsAbove(int y)
        {
            for (int i = y; i < height; i++)
            {
                DecreaseRow(i);
            }
        }

        public bool IsRowFull(int y)
        {
            for (int x = 0; x < width; x++)
            {
                if (data[x, y] == null) {return false;}
            }
            return true;
        }
        public int DeleteFullRows()
        {
            int clearedRows = 0;
            for (int y = 0; y < height; y++)
            {
                if (IsRowFull(y))
                {
                    clearedRows++;
                    DeleteRow(y);
                    DecreaseRowsAbove(y + 1);
                    y--;
                }
            }
            if (clearedRows > 0)
            {
                // Tell GameManager how many rows were cleared
            }
            return clearedRows;
        }
        public Vector2 RoundVect2(Vector2 v)
        {
            float roundX = Mathf.Round(v.x);
            float roundY = Mathf.Round(v.y);
            return new Vector2(roundX, roundY);
        }
    }

}