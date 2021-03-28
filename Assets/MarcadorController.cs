using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcadorController : MonoBehaviour
{

    PelotaController pelotaController;

    public Text marcador;
    int points = 0;
    void Start()
    {
        pelotaController = FindObjectOfType<PelotaController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        points++;
        marcador.text = points.ToString();
        pelotaController.ResetPelota();
    }
}
