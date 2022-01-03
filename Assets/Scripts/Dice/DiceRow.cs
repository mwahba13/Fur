using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRow : MonoBehaviour
{

    public DiceSpot[] diceSpots = new DiceSpot[]{};
    public GameObject dicePrefab;
    
    private int _spotIndex;

    //stack of instantiated dice
    private Stack<GameObject> _diceStack = new Stack<GameObject>();

    private void Start()
    {
        InitDiceRow();        
    }

    private void InitDiceRow()
    {
        GameObject player = GameObject.FindWithTag("Player");
        int numDice = player.GetComponent<DiceManager>().GetDiceCount();
        
        for(int i = 0; i < numDice; i++)
            AddDiceToRow();
    }

    public bool AddDiceToRow()
    {
        if (_spotIndex != diceSpots.Length)
        {

            Transform newDiceTrans = diceSpots[_spotIndex].transform;
            _spotIndex++;

            GameObject newDice = Instantiate<GameObject>(dicePrefab, newDiceTrans.position,
                Quaternion.identity);

            _diceStack.Push(newDice);
            
            return true;
        }
        
        return false;


    }

    public bool RemoveDiceFromRow()
    {

        if (_spotIndex != 0)
        {
            GameObject removedObj = _diceStack.Pop();
            Destroy(removedObj);
            _spotIndex--;
            return true;
        }
        return false;
    }
    
    
}
