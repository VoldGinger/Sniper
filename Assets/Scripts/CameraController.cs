using System;
using System.Collections.Generic;
using CustomInputSystem;
using DG.Tweening;
using Health;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    [HideInInspector] public Vector2 Delta;

    [SerializeField] private float _additionalRotationForce;

    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private List<Material> _playerMats;
    [SerializeField] private float _xRotationClampMin;
    [SerializeField] private float _xRotationClampMax;
    [SerializeField] private float _yRotationClampMin;
    [SerializeField] private float _yRotationClampMax;

    private Camera _camera => Camera.main;
    private GameData _data;
    private Vector3 _cameraStartRotation;
    private Transform _cameraParent;

    private void Awake()
    {
        _cameraParent = transform.parent;
        _cameraStartRotation = _cameraParent.localEulerAngles;

        EventSystem.OnAimButtonUp += () =>
        {
            _cameraStartRotation =
                new Vector3(_cameraStartRotation.x + Delta.y, _cameraStartRotation.y - Delta.x, 0);
            Delta = Vector2.zero;
        };

        _data = Resources.Load<GameData>("Game Data");
    }


    public void AimMode()
    {
        Camera.main.DOFieldOfView(_data.AimFOV, _data.DurationTime);
        foreach (var mat in _playerMats)
        {
            mat.DOFade(0, _data.DurationTime);
        }
    }

    public void PersonMode()
    {
        _camera.DOFieldOfView(_data.PersonFOV, _data.DurationTime);
        foreach (var mat in _playerMats)
        {
            mat.DOFade(1, _data.DurationTime);
        }

    }


    public void RotateCamera(Vector2 value)
    {
        _cameraStartRotation += new Vector3(-value.y, -value.x);


    }







    private void OnDisable()
    {
        foreach (var mat in _playerMats)
        {
            mat.SetVector("_Color", new Vector4(1, 1, 1, 1));
        }

    }





    private void Update()
    {
        _cameraParent.rotation =
            Quaternion.Euler(_cameraStartRotation.x + Delta.y, _cameraStartRotation.y - Delta.x, 0);
        ClampRotation();

    }







    private void ClampRotation()
    {
        float modifiedXAngle =
            _cameraParent.localEulerAngles.x >= 180 ? _cameraParent.localEulerAngles.x - 360 : _cameraParent.localEulerAngles.x;

        float targetXRotation = Mathf.Clamp(modifiedXAngle, _xRotationClampMin, _xRotationClampMax);
        float targetYRotation = Mathf.Clamp(_cameraParent.localEulerAngles.y, _yRotationClampMin, _yRotationClampMax);
        var targetRotation = Quaternion.Euler(Vector3.up * targetYRotation) * Quaternion.Euler(Vector3.right * targetXRotation);
        _cameraParent.rotation = targetRotation;


    }

    public RaycastHit CastRayFromCamera()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(_raycastPoint.position);
        Physics.Raycast(ray, out hit);
        return hit;
    }


    public RaycastHit[] CastSphereFromCamera()
    {
        Ray ray = _camera.ScreenPointToRay(_raycastPoint.position);
        return Physics.SphereCastAll(ray, _data.WeaponSoundSphereRadius, 200, LayerMask.GetMask("Enemies"));

    }
}
