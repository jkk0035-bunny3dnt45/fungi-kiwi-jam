using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Controllers
{
    public class DimensionController : MonoBehaviour
    {
        public GameObject player;
        public Transform fungiWorldSpawnRef;
        public InputActionReference swapAction;

        private Vector3 _worldOffset;
        public CharacterController characterController;

        void OnEnable()
        {
            swapAction.action.Enable();
        }

        void OnDisable()
        {
            swapAction.action.Disable();
        }

        private void Start()
        {
            // Calculates the relative directional vector from Player to Fungi World Spawn
            _worldOffset = fungiWorldSpawnRef.position - player.transform.position;
        }

        private void Update()
        {
            if (swapAction == null || !swapAction.action.triggered) return;

            // Determine target destination based on current world state
            Vector3 targetPosition = GameData.inOverWorld
                ? player.transform.position + _worldOffset
                : player.transform.position - _worldOffset;

            GameData.inOverWorld = !GameData.inOverWorld;

            SwapPlayerPosition(targetPosition);
        }

        public void SwapPlayerPosition(Vector3 newPosition)
        {
            characterController.enabled = false;
            player.transform.position = newPosition;
            characterController.enabled = true;
            player.transform.position = newPosition;
        }
    }
}