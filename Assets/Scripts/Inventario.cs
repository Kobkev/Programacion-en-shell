using System;
using System.Collections;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject pantallaInventario;
    public AudioSource abrirInventario;
    public AudioSource cerrarInventario;
    public bool estaAbierto = false;
    public bool puedeCerrar = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && estaAbierto == false && puedeCerrar == false)
        {
            estaAbierto = true;
            ControlGlobal.inventarioAbierto = true;
            abrirInventario.Play();
            StartCoroutine(InvControl());
        }
        else if (Input.GetKey(KeyCode.Tab) && estaAbierto == true && puedeCerrar == true)
        {
            estaAbierto = false;
            ControlGlobal.inventarioAbierto = false;
            cerrarInventario.Play();
            StartCoroutine(InvControl());
        }
    }

    public void botonSalir()
    {
        estaAbierto = false;
        cerrarInventario.Play();
        StartCoroutine(InvControl());
    }

    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(0.25f);
        if (estaAbierto == true)
        {
            pantallaInventario.SetActive(true);
        }
        else
        {
            pantallaInventario.SetActive(false);
        }
        if (estaAbierto == true)
        {
            puedeCerrar = true;
            /* Time.timeScale = 0;
            Cursor.visible = true; */
        }
        else
        {
            puedeCerrar = false;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
