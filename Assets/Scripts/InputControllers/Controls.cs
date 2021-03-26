using UnityEngine;

namespace Assets.Scripts.InputControllers
{
    public class Controls : MonoBehaviour
    {
        public string myName = "testName";
        // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
        public GameObject myPrefab;
        private CharacterController _controller;
        private Transform _transform;

        // Start is called before the first frame update
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            _controller.center.Set(0.0f, 13.0f, 0.0f);
            _transform = GetComponent<Transform>();
            _transform.position = new Vector3(-14.0f, 13.17f, 0.0f);
            _transform.rotation = Quaternion.Euler(58.0f, 0.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            _transform.position.Set(0.0f, 13.17f, 0.0f);
            _transform.rotation.eulerAngles.Set(90.0f, 0.0f, 0.0f);
            // Maybe add IfSelected() so logic is applied only if selected?
            KeyboardLogic();
        }

        void KeyboardLogic()
        {
            // If we have enough different implementations of this we should make it an interface
            // and implement the action for the keys
            Vector3 deltaVector;
            deltaVector.x = 0;
            deltaVector.y = 0;
            deltaVector.z = 0;
            float delta = 0.01f;

            // We should have a map that contains pairs of key:functionality
            // This would facilitate key rebinding
            if (Input.GetKey(KeyCode.W))
            {
                deltaVector.z += delta;
            }
            if (Input.GetKey(KeyCode.S))
            {
                deltaVector.z -= delta;
            }
            if (Input.GetKey(KeyCode.D))
            {
                deltaVector.x += delta;
            }
            if (Input.GetKey(KeyCode.A))
            {
                deltaVector.x -= delta;
            }
            _controller.Move(deltaVector);
        }
    }
}
