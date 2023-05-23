using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabInteractable : XRGrabInteractable
{
    [SerializeField] private Transform _mainModel;
    private void Update()
    {
        if (!isSelected && _mainModel != null)
        {
            transform.position = _mainModel.position;
            transform.rotation = _mainModel.rotation;
        } 
    }
}
