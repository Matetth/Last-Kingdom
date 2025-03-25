using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsUI : MonoBehaviour
{
    public GameObject Buildings_UI_1, Buildings_UI_2;

    public void NextUI()
    {
        if (Buildings_UI_1.activeSelf)
        {
            Buildings_UI_1.SetActive(false);
            Buildings_UI_2.SetActive(true);
        }
        else
        {
            Buildings_UI_1.SetActive(true);
            Buildings_UI_2.SetActive(false);
        }
    }
}

