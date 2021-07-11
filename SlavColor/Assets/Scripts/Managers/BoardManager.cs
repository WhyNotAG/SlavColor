using 
System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour, IManager
{
    public ManagerStatus managerStatus { get; private set; }

    public void Startup()
    {
        Debug.Log("Board manager started");
        managerStatus = ManagerStatus.Started;
    }
    
    
}
