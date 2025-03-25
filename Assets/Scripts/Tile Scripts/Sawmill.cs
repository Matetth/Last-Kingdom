using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawmill : MonoBehaviour
{
    void Start()
    {
        Income.Instance.wood_income += 2;
    }
}
