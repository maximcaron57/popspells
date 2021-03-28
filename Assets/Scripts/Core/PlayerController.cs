using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace popspells.scripts.controllers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputAction movement = new InputAction();

        [SerializeField] private LayerMask layerMask = new LayerMask();
        
        private NavMeshAgent agent = null;
        private Camera cam = null;

        private void Start()
        {
            cam = Camera.main;
            agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            movement.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (movement.ReadValue<float>() == 1)
            {
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    PlayerMove(hit.point);
                }
            }
        }

        private void PlayerMove(Vector3 location)
        {
            agent.SetDestination(location);
        }
    }
}

