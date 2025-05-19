using UnityEngine;
using System;
using UnityEngine.PlayerLoop;

public class InputController : MonoBehaviour
{
    public static Action clickAction;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickAction?.Invoke();
        }
        
    }
}
