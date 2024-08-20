using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lagooneng.PocketBall
{
    public class Player : MonoBehaviour
    {
        public Vector3 ForceVec { get; set; }
        [SerializeField] float power = 10.0f;
        [SerializeField] GameObject whiteBall;
        [SerializeField] GameObject gameEnd;
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

            if( shotCount == 3 )
            {
                Invoke("GameEnd", 10.0f);
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