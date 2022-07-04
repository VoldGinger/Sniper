using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using EventSystem = CustomInputSystem.EventSystem;

public class RotationZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector2 _direction;
    private CameraController _cameraController;
    private bool _isHover;
    private GameData _data;

    private void Start()
    {
        _cameraController = FindObjectOfType<CameraController>();
        _data = Resources.Load<GameData>("Game Data");
        EventSystem.OnAimButtonUp += () => _isHover = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        _isHover = true;
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _isHover = false;
    }


    private void Update()
    {
        if(_isHover)
            _cameraController.RotateCamera(_direction * Time.deltaTime * _data.AdditionalRotationForce);
    }

    
    
  
}
