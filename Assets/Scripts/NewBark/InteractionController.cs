using NewBark.Attributes;
using NewBark.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NewBark
{
    [RequireComponent(typeof(PlayerController))]
    public class InteractionController : MonoBehaviour
    {
        [Layer] public int interactableLayer = 8;
        public float raycastDistance = 1f;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }

        protected void OnButtonAPerformed(InputAction.CallbackContext ctx)
        {
            Vector3 direction = _playerController.GetFaceDirection();
            RaycastHit2D hit = _playerController.CheckHit(direction, interactableLayer, raycastDistance);

            var pos = transform.position;

            Debug.DrawRay(pos, direction, Color.green);
            Debug.DrawRay(pos, hit.point, Color.blue);

            hit.collider.SendMessage("OnInteract", GameButton.A, SendMessageOptions.DontRequireReceiver);
        }
    }
}
