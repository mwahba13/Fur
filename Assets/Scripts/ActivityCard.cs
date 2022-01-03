using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ECardType
{
    EHuntBeaver,EHuntBuffalo, EProcessBeaver,EProcessBuffalo,
}

public class ActivityCard : MonoBehaviour
{
    [Header("Card Params")] 
    public ECardType cardType;

    public int maxDiceCount;
    
    public DiceSpot[] diceSpots;
    public GameObject dicePrefab;
    
    
    private Stack<GameObject> _diceStack = new Stack<GameObject>();
    private int _numDice;

    public bool AddDice()
    {
        if (_numDice != maxDiceCount)
        {
            UpdateCard(true);
            _numDice++;

            return true;
        }
        ThrowDiceError();
        return false;
    

    }

    public bool SubtractDice()
    {

        if (_numDice != 0)
        {
            UpdateCard(false);
            _numDice--;

            return true;
        }
    
        ThrowDiceError();
        return false;

    }

    //updates state of activity card
    //todo: update graphical state of activity card
    private void UpdateCard(bool isAdding)
    {
        if (isAdding)
        {
            Transform newtrans = diceSpots[_numDice].transform;

            GameObject newDice = Instantiate<GameObject>(dicePrefab,
                newtrans.position, newtrans.rotation);
            
            _diceStack.Push(newDice);
        }
        else
        {
            GameObject deleteDice = _diceStack.Pop();
            Destroy(deleteDice);
            
        }
        
        
    }

    public void UpgradeCard()
    {
        if (maxDiceCount != 6)
            maxDiceCount++;
    }

    //TODO: dice error box if try to add too many dice
    private void ThrowDiceError()
    {
        
    }
    
    
}
