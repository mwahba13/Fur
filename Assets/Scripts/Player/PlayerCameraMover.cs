using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMover : MonoBehaviour
{

    
    public Vector3 MarketPos;
    public Vector3 MarketRot;
    public Vector3 BoardPos;
    public Vector3 BoardRot;

    
    public float movementSpeed;
    
    private bool _isMoving;
    private GameObject _cam;
    [SerializeField]
    private Transform targetTransform;

    private void Awake()
    {
     
        _cam = Camera.main.gameObject;

        
        GameObject newGo = new GameObject();
        targetTransform = newGo.transform;
        targetTransform.position = BoardPos;
        targetTransform.rotation = Quaternion.Euler(BoardRot); 
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_cam.transform.localPosition == targetTransform.position)
        {
            _isMoving = false;
        }
        
        if (_isMoving)
        {
            _cam.transform.localPosition = Vector3.Lerp(_cam.transform.localPosition,
                targetTransform.position,
                movementSpeed * Time.deltaTime);
            
            _cam.transform.localRotation = Quaternion.Lerp(
                _cam.transform.localRotation,
                targetTransform.rotation,
                movementSpeed*Time.deltaTime
                );
        }
    }

    public void MoveCamera(EPlayerState newState)
    {

        
        if (newState == EPlayerState.EBoard)
        {
            targetTransform.position = BoardPos;
            targetTransform.rotation = Quaternion.Euler(BoardRot);
        }
        else if (newState == EPlayerState.EMarket)
        {
            
            targetTransform.position = MarketPos;
            targetTransform.rotation = Quaternion.Euler(MarketRot);
        }

        
        _isMoving = true;

    }
}
