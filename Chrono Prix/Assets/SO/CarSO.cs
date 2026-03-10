using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Car", menuName = "Car")]
public class CarSO : ScriptableObject
{
    public float speed;
    public float angle;
    public float brake;
}
