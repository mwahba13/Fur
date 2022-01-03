using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _cam;

    private DiceManager _diceManager;
    // Start is called before the first frame update
    void Start()
    {
        _diceManager = GetComponent<DiceManager>();
        _cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                
                GameObject hitObj = raycastHit.collider.gameObject;
                
                if (hitObj.GetComponent<ActivityCard>()
                    && _diceManager.IsDiceAvailable())
                {
                    if(hitObj.GetComponent<ActivityCard>().AddDice())
                        _diceManager.LoseDice();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            RaycastHit raycastHit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                
                GameObject hitObj = raycastHit.collider.gameObject;

                if (hitObj.GetComponentInChildren<ActivityCard>())
                {
                    if(hitObj.GetComponent<ActivityCard>().SubtractDice())
                        _diceManager.GainDice();
                }
                
            }
        }
        
        
    }
}
