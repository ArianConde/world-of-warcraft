using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleccion : MonoBehaviour
{
    public bool Fenixelegido = false;
    public bool Arthaselegido = false;
    private GameObject Background;
    private robarAlianza robarAlianza;
    private RobarHorda robarHorda;

    void Start()
    {
        Background = GameObject.Find("Fondo");
        robarAlianza= GameObject.Find("Mazo CDA").GetComponent<robarAlianza>();
        robarHorda = GameObject.Find("Mazo Mordor").GetComponent<RobarHorda>();
    }

    void Update()
    {
        // Ahora solo se inicializan una vez en Start(), no en cada frame
    }

    public void SelectCards()
    {
        if(robarAlianza.robo1)
        {
            Fenixelegido = true;
            gameObject.transform.SetParent(Background.transform, false);
        }

        if(robarHorda.robo1)
        {
            Arthaselegido = true;
            gameObject.transform.SetParent(Background.transform, false);
        }
    }
}