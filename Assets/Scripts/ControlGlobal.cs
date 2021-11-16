using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGlobal : MonoBehaviour
{
    public static bool inventarioAbierto = false;
    public static bool pausaAbierto = false;

    void Update()
    {
        if (pausaAbierto == true)
        {
            inventarioAbierto = true;
        }
        else
        {
            inventarioAbierto = false;
        }
    }
}
