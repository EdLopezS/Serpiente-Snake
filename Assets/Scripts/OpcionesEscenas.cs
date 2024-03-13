using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesEscenas : MonoBehaviour
{
    public void Jugar(int numeroNivel)
    {
        SceneManager.LoadScene(numeroNivel);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
