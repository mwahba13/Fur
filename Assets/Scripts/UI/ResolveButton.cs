using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EResolveButtonState
{
    EResolve,
    EContinue
};

public class ResolveButton : MonoBehaviour
{
    public delegate void OnResolveTurn();

    public static OnResolveTurn resolveTurnEvent;

    private EResolveButtonState _buttonState = EResolveButtonState.EResolve;

    public delegate void OnEndResolve();

    public static OnEndResolve endResolveEvent;

    private Material _mat;

    private void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown()
    {
        switch (_buttonState)
        {
            case EResolveButtonState.EResolve:
                resolveTurnEvent?.Invoke();
                _buttonState = EResolveButtonState.EContinue;
                _mat.color = Color.gray;
                break;
            case EResolveButtonState.EContinue:
                endResolveEvent?.Invoke();
                _buttonState = EResolveButtonState.EResolve;
                _mat.color = Color.green;
                break;
        }
    }

}
