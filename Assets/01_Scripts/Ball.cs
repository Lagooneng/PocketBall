using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lagooneng.PocketBall
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private bool isBlack = false;
        [SerializeField] private bool isStripe = false;

        private void OnTriggerEnter(Collider other)
        {
            if( other.CompareTag( "Hole" ) )
            {
                if( isBlack )
                {
                    ScoreManager.Instance.Score -= 3;
                }
                else if( isStripe )
                {
                    ScoreManager.Instance.Score += 1;
                }
                else
                {
                    ScoreManager.Instance.Score -= 1;
                }

                ScoreManager.Instance.UpdateScore();

                Destroy(this.gameObject);
            }
        }
    }

}