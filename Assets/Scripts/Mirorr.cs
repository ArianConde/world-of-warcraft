using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CartaMirador : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;
    Text descripcion;
    bool visible = false;

    void Start()
    {
        image = GetComponent<Image>();
        descripcion = GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        visible = true;
        image.enabled = true;
        descripcion.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        visible = false;
        image.enabled = false;
        descripcion.enabled = false;
    }
}