using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosFranjaManager : MonoBehaviour
{
    public static PuntosFranjaManager Instance { get; private set; } 
    public Text puntosFranjaUI; 
    public GameObject CuerpoaCuerpo, Distancia, Asedio; 

    private int sumaFranja = 0;

    void Awake()
    {
        if (Instance!= null && Instance!= this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        CalcularSumaFranja();
        ActualizarUI();
    }

    private void CalcularSumaFranja()
    {
        int sumaTotal = 0;
        sumaTotal += CuerpoaCuerpo.GetComponent<ClaseFranja>().Suma;
        sumaTotal += Distancia.GetComponent<ClaseFranja>().Suma;
        sumaTotal += Asedio.GetComponent<ClaseFranja>().Suma;
        sumaFranja = sumaTotal;
    }

    private void ActualizarUI()
    {
        puntosFranjaUI.text = sumaFranja.ToString();
    }
}