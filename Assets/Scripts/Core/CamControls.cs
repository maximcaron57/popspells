using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;
using static Assets.Utilities.Inputs.InputManager;


public class CamControls : MonoBehaviour
{
    private CharacterController _controller;
    private Transform           _transform;
    private Transform           _camera;

    // Local constants
    [SerializeField]
    const float _camMaxSpeed = 60.0f;
    [SerializeField]
    const float _camAcceleration = 1.0f;
    [SerializeField]
    const float _camHeight = 20.0f;
    [SerializeField]
    float _speed = 15.0f;

    const float _minDelta = 0.1f;
    // Local variables
    float _haSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform  = GetComponent<Transform>();
        _camera     = GetComponent<Transform>();
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
        float dTime = Time.deltaTime;

        // We should have a map that contains pairs of key:functionality
        // This would facilitate key rebinding
        if (Input.GetKey(GetKeyCode(InputNames.ForwardFunction)))  deltaVector.z += _speed * dTime;
        if (Input.GetKey(GetKeyCode(InputNames.BackwardFunction))) deltaVector.z -= _speed * dTime;
        if (Input.GetKey(GetKeyCode(InputNames.RightFunction)))    deltaVector.x += _speed * dTime;
        if (Input.GetKey(GetKeyCode(InputNames.LeftFunction)))     deltaVector.x -= _speed * dTime;
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
        float delta = _camHeight - heightDiff;

        if (Abs(delta) < _minDelta)
        {
            _haSpeed = 0.0f;
            return;
        }

        int deltaSign = Sign(delta);
        var tempSpeed = _camAcceleration * Time.deltaTime * deltaSign;
        _haSpeed += Min(Abs(tempSpeed), _camMaxSpeed) * deltaSign;
        
        deltaVector.y += Min(Abs(_haSpeed), Abs(delta)) * deltaSign;

        _controller.Move(deltaVector);

    }
}
