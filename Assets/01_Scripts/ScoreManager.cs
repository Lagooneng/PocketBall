using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lagooneng.PocketBall
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        public int Score { get; set; }
        [SerializeField] private TMP_Text scoreText;

        private void Awake()
        {
            Score = 0;
            UpdateScore();
            Instance = this;
        }

        public void UpdateScore()
        {
            scoreText.text = "Score : " + Score.ToString();
        }
    }
}


