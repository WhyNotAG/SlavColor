using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
  [SerializeField] private Text _nameField;
  [SerializeField] private Image _iconField;

  public event Action Ejecting;
  private Transform _draggingParent;
  private Transform _originalParent;
  public void Render(IItem item)
  {
    _nameField.text = item.Name;
    _iconField.sprite = item.UIIcon;
  }

  public void Init(Transform draggingParent)
  {
    _draggingParent = draggingParent;
    _originalParent = transform.parent;
  }

  public void OnDrag(PointerEventData eventData)
  {
    transform.position = Input.mousePosition;
  }

  private void Eject()
  {
    Ejecting?.Invoke();
  }

  private void InsertInGrid()
  {
    int closestIndex = 0;

    for (int i = 0; i < _originalParent.transform.childCount; i++)
    {
      if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) <
          Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
      {
        closestIndex = i;
      }
    }

    transform.parent = _originalParent;
    transform.SetSiblingIndex(closestIndex);
  }

  private bool In(RectTransform originalParent)
  {
    return originalParent.rect.Contains(transform.position);
  }
  
  public void OnEndDrag(PointerEventData eventData)
  {
    if (In((RectTransform) _originalParent))
    {
      InsertInGrid();
    }
    else
    {
      Eject();
    }
  }

  public void OnBeginDrag(PointerEventData eventData)
  {
    transform.parent  = _draggingParent;
  }
}
