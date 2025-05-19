using System;
using UnityEngine;

public class FieldSelector : MonoBehaviour
{
    private void Awake()
    {
        InputController.clickAction += SelectField;
    }

    private void SelectField()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Field")
            {
                
            }
        }
    }
}
