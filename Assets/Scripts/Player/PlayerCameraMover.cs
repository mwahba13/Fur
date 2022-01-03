using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMover : MonoBehaviour
{

    
    public Vector3 MarketPos;
    public Vector3 MarketRot;
    public Vector3 BoardPos;
    public Vector3 BoardRot;
    public Vector3 UpgradePos;
    public Vector3 UpgradeRot;
    
    public float movementSpeed;
    
    private bool _isMoving;
    private GameObject _cam;
    [SerializeField]
    private Transform targetTransform;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newGo = new GameObject();
        targetTransform = newGo.transform;
        
        _cam = Camera.main.gameObject;

        targetTransform.position = BoardPos;
        targetTransform.rotation = Quaternion.Euler(BoardRot);
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
        
        else if (newState == EPlayerState.EUpgrade)
        {
            
            targetTransform.position = UpgradePos;
            targetTransform.rotation = Quaternion.Euler(UpgradeRot);
        }
        
        _isMoving = true;

    }
}
