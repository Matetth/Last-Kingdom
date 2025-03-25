using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : MonoBehaviour
{
    void Start()
    {
        Income.Instance.gold_income += 1;
    }
}
