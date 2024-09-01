using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

namespace Lagooneng.PocketBall
{
    public class Player : MonoBehaviour
    {
        public Vector3 ForceVec { get; set; }
        [SerializeField] float power = 10.0f;
        [SerializeField] GameObject whiteBall;
        [SerializeField] GameObject gameEnd;
        [SerializeField] TMP_Text gameEndCountText;
        [SerializeField] TMP_Text remainingChallenges;
        [SerializeField] private FadeFilter fadeFilter;
        private Rigidbody whiteBallRB;

        private int shotCount = 0;

        private void Awake()
        {
            whiteBallRB = whiteBall.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            InputManager.Input.User.LeftButton.performed += SetWhiteBallV;
        }

        public void SetWhiteBallV(InputAction.CallbackContext context)
        {
            if (shotCount > 2) return; 

            whiteBallRB.AddForce(ForceVec * power, ForceMode.Impulse);
            ++shotCount;

            remainingChallenges.text = (3 - shotCount).ToString();

            if( shotCount == 3 )
            {
                StartCoroutine(GameEndCount());
                fadeFilter.fadeOut();
                Invoke("GameEnd", 10.0f);
            }
        }

        public IEnumerator GameEndCount()
        {
            gameEndCountText.enabled = true;

            for( int i = 0; i < 10; ++i )
            {
                gameEndCountText.text = (10 - i).ToString();

                yield return new WaitForSeconds(1.0f);
            }
        }

        public void GameEnd()
        {
            gameEnd.SetActive(true);
        }

        public void ReLoadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }
}