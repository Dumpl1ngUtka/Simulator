
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGrabInteractable : XRGrabInteractable
{
    /*
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable> ();
    private XRBaseInteractor secondInteractor;
    private void Start()
    {
        foreach (XRSimpleInteractable secondHandGrabPoint in secondHandGrabPoints)
        {
            secondHandGrabPoint.onSelectEnter.AddListener(OnSecondHandGrab);
            secondHandGrabPoint.onSelectExit.AddListener(OnSecondHandRelease);
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor && selectingInteractor)
            selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        base.ProcessInteractable(updatePhase);
    }
    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        secondInteractor = interactor;
    }    
    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        secondInteractor = null;
    }
    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        bool isAlreadyGrabble = isSelected && !interactor.Equals(isSelected);
        return base.IsSelectableBy(interactor) && !isAlreadyGrabble;
    }
    */
}
