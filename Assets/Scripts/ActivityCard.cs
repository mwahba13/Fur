using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;
using Random = UnityEngine.Random;


public enum ECardType
{
    EHuntBeaver,EHuntBuffalo, EProcessBeaver,EProcessBuffalo,
}

public class ActivityCard : MonoBehaviour
{
    [Header("Card Params")] 
    public ECardType cardType;

    public bool isPlayerCard;
    public int maxDiceCount;
    
    public DiceSpot[] diceSpots;
    public GameObject dicePrefab;
    
    private Stack<GameObject> _diceStack = new Stack<GameObject>();
    private Stack<int> _diceRolls = new Stack<int>();
    private DiceManager _diceManager;
    private Outline _outline;
    private int _numDice;

    private void Start()
    {
        UpdateDiceSpots();
        _diceManager = GameObject.FindWithTag("Player").GetComponent<DiceManager>();

        if (isPlayerCard)
        {
         
            _outline = GetComponent<Outline>();
            _outline.eraseRenderer = true;   
        }
        ResolveButton.endResolveEvent += ClearPlayerCard;

    }

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

    public Stack<int> RollDice()
    {
        Stack<int> output = new Stack<int>();

        for (int i = 0; i < _diceStack.Count; i++)
        {
            output.Push(Random.Range(1,7));
        }

        _diceRolls = output;
        
        return output;
    }
    
    public void ClearCard()
    {
            while (_numDice != 0)
            {
                UpdateCard(false);
                _numDice--;
                if(isPlayerCard)
                    _diceManager.GainDice();
            }   

    }

    public void ClearPlayerCard()
    {
        if (isPlayerCard)
        {
            while (_numDice != 0)
            {
                UpdateCard(false);
                _numDice--;
                _diceManager.GainDice();
            }
        }
    }


    //updates state of activity card
    private void UpdateCard(bool isAdding)
    {
        if (isAdding)
        {
            Transform newtrans = diceSpots[_numDice].transform;

            GameObject newDice = Instantiate<GameObject>(dicePrefab,
                newtrans.position, newtrans.rotation,this.transform);

            newDice.transform.localScale = new Vector3(500f, 500f, 500f);
            _diceStack.Push(newDice);
        }
        else
        {
            GameObject deleteDice = _diceStack.Pop();
            Destroy(deleteDice);
            
        }
        
        
    }

    private void UpdateDiceSpots()
    {
        //activate all possible spaces
        for (int i = 0; i < maxDiceCount; i++)
        {
            diceSpots[i].gameObject.SetActive(true);
        }
        
        //hide the occupied ones
        for (int i = 0; i < _diceStack.Count; i++)
        {
            diceSpots[i].gameObject.SetActive(false);
        }
    }

    public void UpgradeCard()
    {
        if (maxDiceCount != 6)
        {
            maxDiceCount++;
            UpdateDiceSpots();            
        }
    }

    public bool CardCanBeUpgraded()
    {
        return maxDiceCount != 6;
    }
    
    private void ThrowDiceError()
    {
        
    }


    //i is dice index
    //rollOutcome is what the value of the roll is/was
    //didWin is if true if this dice "beat" an enemy dice
    public void AnimateDice(int i, int rollOutcome, bool didWin)
    {
        
    }

    private void OnMouseEnter()
    {
        
        if(isPlayerCard)
        {
            try
            {
                _outline.eraseRenderer = false;
            }
            catch (NullReferenceException e)
            {
 
            }
            
        }
        
        
    }

    private void OnMouseExit()
    {
        if (isPlayerCard)
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
}
