using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public DiceRow diceRow;
    
    [SerializeField]
    private int _diceCount;
    


    public void GainDice()
    {
        if(diceRow.AddDiceToRow())
            _diceCount++;
    }

    public void LoseDice()
    {

        if (diceRow.RemoveDiceFromRow())
            _diceCount--;
    }
    

    public bool IsDiceAvailable()
    {
        return _diceCount > 0;
    }

    public int GetDiceCount()
    {
        return _diceCount;
    }
}
