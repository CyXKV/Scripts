using System;
using Unity.VisualScripting;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private void Awake()
    {
        ClickManager.onClickAction += IsTowerHere;
    }

    void IsTowerHere()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            if (hit.collider.tag == "Tile")
            {
                if (hit.collider.GetComponent<Cell>().getIsTowerHere())
                {
                    //Открываем менюшку тавера
                }
                else
                {
                    //Открываем менюшку клетки
                }
                
            }
        }
    }
    void PointWithoutTower()
    {
        
    }

    void PointWithTower()
    {
        
    }
}
