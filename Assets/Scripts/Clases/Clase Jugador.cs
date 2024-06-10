using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseJugador : MonoBehaviour
{
      private GameObject cardEntry;
    public List<GameObject> cardsInFrange;
    public int cards = 0;
    public int cardsReturned = 0;
    public bool rendered = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cardEntry = collision.gameObject;
        if (!cardsInFrange.Contains(cardEntry)) // Verificar si la carta ya está en la lista
        {
            cardsInFrange.Add(cardEntry);
            cards += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (cardsInFrange.Count > 0) // Verificar si la lista no está vacía
        {
            cardsInFrange.RemoveAt(cards - 1); // Ajustar el índice basado en el número total de cartas
            cards -= 1;
        }
    }
}

