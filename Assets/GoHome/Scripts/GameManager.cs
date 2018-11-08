using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml.Serialization;
using System.IO;

namespace GoHome
{
    [Serializable]
    public class GameData
    {
        public int score;
        public int level;
        public Vector3 position;
    }

    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        private void Awake()
        {
            Instance = this;
            fullPath = Application.dataPath + "/GoHome/Data/" + fileName + ".xml";
            if (File.Exists(fullPath))
            {
                Load();
            }
        }
        private void OnDestroy()
        {
            Save();
            Instance = null;
            
        }
        #endregion

        public int currectLevel = 0;
        public int currectScore = 0;
        public bool isGameRunning = true;
        public Transform levelContainer;

        private GameObject player;
        private Level[] levels;
        private string fullPath;
        private GameData data = new GameData();

        [Header("UI")]
        public Text scoreText;
        [Header("Game Saves")]
        public string fileName = "GameData";

        private void Save()
        {
            data.score = currectScore;
            data.level = currectLevel;
            data.position = player.transform.position;
            var serializer = new XmlSerializer(typeof(GameData));
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                serializer.Serialize(stream, data);
            }
        }

        private void Load()
        {
            var serializer = new XmlSerializer(typeof(GameData));
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                data = serializer.Deserialize(stream) as GameData;
            }
            currectScore = data.score;
            GameObject.Find("Player").transform.position = data.position;
            currectLevel = data.level;
        }


        private void Start()
        {
            levels = levelContainer.GetComponentsInChildren<Level>();
            SetLevel(currectLevel);
            scoreText.text = "Score: " + currectScore;
            player = GameObject.Find("Player");
        }

        private void SetLevel(int levelIndex)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                GameObject level = levels[i].gameObject;
                level.SetActive(false);
                if (i == levelIndex)
                {
                    level.SetActive(true);
                }
            }
        }

        public void GameOver()
        {
            isGameRunning = false;
        }
        public void AddScore(int scoreToAdd)
        {
            currectScore += scoreToAdd;
            scoreText.text = "Score: " + currectScore;
        }
        public void AddScore(int scoreToAdd, int modifier)
        {
            AddScore(scoreToAdd * modifier);
        }
        public void NextLevel()
        {
            currectLevel++;
            if (currectLevel >= levels.Length)
            {
                GameOver();
            }
            else
            {
                SetLevel(currectLevel);
            }
        }
    }
}
