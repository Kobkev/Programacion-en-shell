using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGlobal : MonoBehaviour
{
    public static bool inventarioAbierto = false;
    public static bool desactivarMovimiento = false;

    void Update()
    {
        if (desactivarMovimiento == true)
        {
            inventarioAbierto = true;
        }
        else
        {
            inventarioAbierto = false;
        }
    }
}
