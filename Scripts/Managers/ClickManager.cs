using System;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static Action onClickAction;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClickAction?.Invoke();
        }
    }
}
