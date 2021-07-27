using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private bool _isActive;
    private GameObject _inventoryPanel;

    private void Start()
    {
        _isActive = false;
        _inventoryPanel = this.gameObject.GetComponentInChildren<Inventory>().gameObject;
        _inventoryPanel.SetActive(_isActive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _isActive = !_isActive;
            //_inventoryPanel.GetComponent<Inventory>().Render();
            _inventoryPanel.SetActive(_isActive);
        }
    }
}
