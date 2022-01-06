using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySolver : MonoBehaviour
{
    public int NumOfDice;

    public ActivityCard[] ActivityCards;

    private int _initialNumDice;
    // Start is called before the first frame update
    void Start()
    {
        _initialNumDice = NumOfDice;
        StartTurn();
        ResolveButton.endResolveEvent += StartTurn;
    }

//TODO - figure out basic enemy AI
    public void StartTurn()
    {
        foreach (var card in ActivityCards)
        {
            card.ClearCard();
        }

        NumOfDice = _initialNumDice;
        
        //randomly assign dice
        for (int i = 0; i < NumOfDice; i++)
        {
            if(!ActivityCards[Random.Range(0, 3)].AddDice())
                Debug.Log("failed to generate dice");
        }
        
    }
}
