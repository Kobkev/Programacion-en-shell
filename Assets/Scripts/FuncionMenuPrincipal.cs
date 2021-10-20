using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionMenuPrincipal : MonoBehaviour
{
    public AudioSource buttonPress;

    public void PlayGame()
    {
        buttonPress.Play();
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
