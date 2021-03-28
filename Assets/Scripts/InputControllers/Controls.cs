using UnityEngine;
using static System.Math;

namespace Assets.Scripts.InputControllers
{
    public class Controls : MonoBehaviour
    {
        public string myName = "testName";
        // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
        public GameObject myPrefab;
        private CharacterController _controller;
        private Transform _transform;
        private Transform _camera;

        // Local constants
        [SerializeField]
        const float _CamMaxSpeed = 60.0f;
        [SerializeField]
        const float _CamAcceleration = 1.0f;
        [SerializeField]
        const float _CamHeight = 20.0f;
        const float _MinDelta = 0.1f;
        // Local variables
        float _camSpeed = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            _transform = GetComponent<Transform>();
            _camera = GetComponent<Transform>();
            _transform.position = new Vector3(-14.0f, 20.17f, 0.0f);
            _transform.rotation = Quaternion.Euler(58.0f, 0.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            _transform.position.Set(0.0f, 13.17f, 0.0f);
            _transform.rotation.eulerAngles.Set(90.0f, 0.0f, 0.0f);
            // Maybe add IfSelected() so logic is applied only if selected?
            KeyboardLogic();
            AjustPosition();
        }

        void KeyboardLogic()
        {
            // If we have enough different implementations of this we should make it an interface
            // and implement the action for the keys
            // IS THIS MEMORY EFFICIENT!?!?
            Vector3 deltaVector = new Vector3();
            float delta = 0.1f;

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

        // Computes the new position based on preferences such as 
        // https://docs.unity3d.com/ScriptReference/Collider.Raycast.html
        void AjustPosition()
        {
            // TODO_DEBUG: we could have that rayHit being shown on screen
            RaycastHit rayHit;
            Vector3 deltaVector = new Vector3();

            //TODO_FEATURE: Check if is collision with "camera collision object" such as terrain but not props
            Physics.Raycast(_camera.position, new Vector3(0.0f, -1.0f, 0.0f), out rayHit);
            float heightDiff = _camera.position.y - rayHit.point.y;
            float delta = _CamHeight - heightDiff;

            if (Abs(delta) < _MinDelta)
            {
                _camSpeed = 0.0f;
                return;
            }

            int deltaSign = Sign(delta);
            var tempSpeed = _CamAcceleration * Time.deltaTime * deltaSign;
            _camSpeed += Min(Abs(tempSpeed), _CamMaxSpeed) * deltaSign;

            deltaVector.y += Min(Abs(_camSpeed), Abs(delta)) * deltaSign;

            _controller.Move(deltaVector);
        }
    }
}
