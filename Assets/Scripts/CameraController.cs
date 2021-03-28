using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace popspells.scripts.controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target = null;
        [SerializeField] private Vector3 _offset = new Vector3();
        [SerializeField] private float _pitch = 2f;

        private void LateUpdate()
        {
            transform.position = _target.position - _offset;
            transform.LookAt(_target.position + Vector3.up * _pitch);
        }
    }
}
