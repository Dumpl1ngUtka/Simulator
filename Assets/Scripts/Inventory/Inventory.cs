using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SelectionArea[] areas;
    [SerializeField] private Camera _camera;
    private Dictionary<int, SelectionArea> selectionAreas = new Dictionary<int, SelectionArea>();
    private PlayerInputSystem _playerInput;
    private int _currentZone;
    private SelectionArea _currentSelectionArea;
    
    private double degree
    {
        get { return _currentZone; }
        set 
        {
            if (value > 330)
                _currentZone = 4;
            else if (value > 300)
                _currentZone = 5;
            else if (value > 270)
                _currentZone = 6;
            else if (value > 240)
                _currentZone = 7;
            else if (value > 210)
                _currentZone = 8;
            else if (value > 180)
                _currentZone = 9;
            else if (value > 150)
                _currentZone = 10;
            else if (value > 120)
                _currentZone = 11;
            else if (value > 90)
                _currentZone = 12;
            else if (value > 60)
                _currentZone = 1;
            else if (value > 30)
                _currentZone = 2;
            else
                _currentZone = 3;
        }
    }
    private void OnEnable()
    {
        _playerInput.Enable();
        _currentZone = -1;
    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
    private void Awake()
    {
        _playerInput = new PlayerInputSystem();
        foreach (var area in areas)
            foreach (var zoneNumber in area.ZoneNumbers)
                selectionAreas.Add(zoneNumber, area);
    }
    private void Update()
    {
        transform.LookAt(_camera.transform);
        Vector2 axisValue = _playerInput.UI.ChooseRightArea.ReadValue<Vector2>() ;
        if (axisValue.magnitude > 0.7f)
        {
            var currentDegree = Vector2.SignedAngle(Vector2.right, axisValue);
            if (currentDegree < 0)
                currentDegree += 360;
            degree = currentDegree;
        }
        else
        {
            if (_currentZone != -1)
                ChooseArea(_currentZone);
            else
                _currentZone = -1;
        }
    }
    private void ChooseArea(int zone)
    {
        SelectionArea currentSelectionArea = selectionAreas[zone];
        currentSelectionArea.Choosed();
        this.gameObject.SetActive(false);
    }
}
