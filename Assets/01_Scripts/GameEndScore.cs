using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lagooneng.PocketBall
{
    public class GameEndScore : MonoBehaviour
    {
        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            text.text = "Score: " + ScoreManager.Instance.Score.ToString();
        }
    }
}


