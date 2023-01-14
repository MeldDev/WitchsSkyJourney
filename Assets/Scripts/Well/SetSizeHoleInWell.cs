using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSizeHoleInWell : MonoBehaviour
{
    [SerializeField] private Transform _topWell;
    [SerializeField] private Transform _bottomWell;
    
    public void SetSizeHole(float size)
    {
        _topWell.localPosition = new Vector3(0, size,10);
        _bottomWell.localPosition = new Vector3(0, -size,10);
    }
}
