using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public enum EResolveButtonState
{
    EResolve,
    EContinue
};

public class ResolveButton : MonoBehaviour
{

    public Material continueMaterial;
    public Material resolveMaterial;
    
    public delegate void OnResolveTurn();

    public static OnResolveTurn resolveTurnEvent;

    private EResolveButtonState _buttonState = EResolveButtonState.EResolve;

    public delegate void OnEndResolve();

    public static OnEndResolve endResolveEvent;

    private Outline _outline;
    
    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.eraseRenderer = true;
        //_mat = resolveMaterial;
    }

    private void OnMouseDown()
    {
        switch (_buttonState)
        {
            case EResolveButtonState.EResolve:
                resolveTurnEvent?.Invoke();
                _buttonState = EResolveButtonState.EContinue;
                GetComponent<MeshRenderer>().material = continueMaterial;
                break;
            case EResolveButtonState.EContinue:
                endResolveEvent?.Invoke();
                _buttonState = EResolveButtonState.EResolve;
                GetComponent<MeshRenderer>().material = resolveMaterial;
                break;
        }
    }

    private void OnMouseEnter()
    {
        try
        {
            _outline.eraseRenderer = false;
        }
        catch (NullReferenceException e)
        {
 
        }
    }
    
    private void OnMouseExit()
    {
        try
        {
            _outline.eraseRenderer = true;
        }
        catch (NullReferenceException e)
        {
 
        }

    }
}
