using UnityEngine.EventSystems;
using UnityEngine;

public class Example : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _gameObject;
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        _gameObject.SetActive(true);
    }

    
    public void OnPointerExit(PointerEventData pointerEventData)
    {

        _gameObject.SetActive(false);
    }
}
