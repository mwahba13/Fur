using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct ResourceStruct
{
    
    public int tokens;
    public int beaverPelts;
    public int buffaloPelts;
    public int pemmican;

}


public class PlayerResources : MonoBehaviour
{
    public ResourceStruct playerResources;    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
