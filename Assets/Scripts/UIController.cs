using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomInputSystem;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIController : MonoBehaviour
{
    public Button AimButton => _aimButton;

    [SerializeField] private CanvasGroup _startingGroup;
    [SerializeField] private CanvasGroup _aimUIGroup;
    [SerializeField] private Button _aimButton;
    [SerializeField] private CanvasGroup _missionGroup;
    [SerializeField] private Transform _bulletsTransform;
    [SerializeField] private Transform _rotationZonesTransform;
    [SerializeField] private GameObject _winWindowPrefab;
    [SerializeField] private GameObject _loseWindowPrefab;


    
    private GameData _data;
    private Image[] _bulletsImages;

    public void SetStartingUIFade(float value)
    {
        _startingGroup.DOFade(value, _data.DurationTime);
    }
    public void SetAimUIFade(float value)
    {
        _aimUIGroup.DOFade(value, _data.DurationTime);

    }


    //using in Trigger event component
    public void AimButtonUpEventInvoke()
    {
        EventSystem.InvokeEvent(EventSystem.OnAimButtonUp);
    }


    public void AimButtonDownEventInvoke()
    {
        EventSystem.InvokeEvent(EventSystem.OnAimButtonDown);

    }
    private void Awake()
    {
        EventSystem.OnAimButtonDown += HideMissionUI;
        EventSystem.OnAimButtonDown += () => _rotationZonesTransform.gameObject.SetActive(true);
        EventSystem.OnAimButtonUp += () => _rotationZonesTransform.gameObject.SetActive(false);
        EventSystem.OnShooted += UpdateBullets;
        EventSystem.Win += ShowWinWindow;
        EventSystem.Lose += ShowLoseWindow;
        _bulletsImages = _bulletsTransform.GetComponentsInChildren<Image>();
    }
   
    private void Start()
    {

        _data = Resources.Load<GameData>("Game Data");

    }



    private void HideMissionUI()
    {
        EventSystem.OnAimButtonDown -= HideMissionUI; 
        _missionGroup.DOFade(0, _data.DurationTime);
        StartCoroutine(DestroyMissionPlane());
    }

    

    private IEnumerator DestroyMissionPlane()
    {
        yield return new WaitForSeconds(_data.DurationTime);
        if (_missionGroup != null)
        {
            Destroy(_missionGroup.gameObject);
        }

    }

    private void UpdateBullets(int value)
    {
        foreach (var image in _bulletsImages)
        {
            if (value <= 0)
            {
                image.color = Color.white;
                continue;
            }
            image.color = Color.yellow;
            value--;
            
        }
    }



    private void ShowWinWindow()
    {
        Instantiate(_winWindowPrefab, transform.GetChild(0).transform);

    }
    
    private void ShowLoseWindow()
    {
        Instantiate(_loseWindowPrefab, transform.GetChild(0).transform);

    }





}
