using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    ManagerStatus managerStatus { get; }
    public void Startup();
}
