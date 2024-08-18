using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lagooneng.PocketBall
{
    public class ArrowVector : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform whiteBall;

        private void Update()
        {
            Vector2 mousePos = InputManager.Input.User.MousePos.ReadValue<Vector2>();

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 mouseWorldPosition = hit.point;
                Vector3 direction = (mouseWorldPosition - transform.position).normalized;

                direction.y = 0.0f;

                if (direction.sqrMagnitude > 0.00001f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    Quaternion originalRotation = Quaternion.Euler(-90, 0, -180);
                    transform.rotation = targetRotation * originalRotation;

                    transform.position = new Vector3(whiteBall.position.x,
                                whiteBall.position.y,
                                whiteBall.position.z);

                    player.ForceVec = direction;
                }
            }
        }
    }
}
