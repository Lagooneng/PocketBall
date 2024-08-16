using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lagooneng.PocketBall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject WhiteBall;
        private Rigidbody whiteBallRB;

        private void Awake()
        {
            whiteBallRB = WhiteBall.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            InputManager.Input.User.LeftButton.performed += SetWhiteBallV;
        }

        public void SetWhiteBallV(InputAction.CallbackContext context)
        {
            whiteBallRB.AddForce(100.0f, 0.0f, 0.0f);
        }
    }
}