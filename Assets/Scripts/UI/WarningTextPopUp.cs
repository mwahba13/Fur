using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningTextPopUp : MonoBehaviour
{
    public delegate void WarningTextDelegate(string s);

    public static WarningTextDelegate WarningTextEvent;
    
    public GameObject warningCanvas;
    public TextMeshProUGUI warningText;

    private Queue<string> warningMessageQueue = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        WarningTextEvent += AddTextToQueue;
        warningCanvas.SetActive(false);
    }

    private void AddTextToQueue(string s)
    {
        warningMessageQueue.Enqueue(s);

        if (!warningCanvas.activeSelf)
        {
            warningText.text = warningMessageQueue.Dequeue();
            
            warningCanvas.SetActive(true);
            
        }
    }

    public void OnContButtonPressed()
    {
        
        if (warningMessageQueue.Count > 0)
        {
            warningText.text = warningMessageQueue.Dequeue();
            
        }
        else
        {
            warningCanvas.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
