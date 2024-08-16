using UnityEngine;
using UnityEngine.InputSystem;  // 유니티 인풋 시스템 네임스페이스 추가

namespace Lagooneng.PocketBall
{
    public class InputManager : MonoBehaviour
    {
        public static UserInputAction Input { get; private set; }  // Getter/Setter 수정

        private void Awake()
        {
            Input = new UserInputAction();
            Input.User.Enable();
        }
    }
}