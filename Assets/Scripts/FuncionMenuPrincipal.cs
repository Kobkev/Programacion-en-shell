using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionMenuPrincipal : MonoBehaviour
{
    public AudioSource buttonPress;
    public GameObject pantallaOpciones;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        buttonPress.Play();
        Application.Quit();
    }

    public void Opciones()
    {
        buttonPress.Play();
        pantallaOpciones.SetActive(true);
    }
}
