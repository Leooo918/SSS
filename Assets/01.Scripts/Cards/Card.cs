using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _cardExplainText;
    [SerializeField] private Image _cardImage;

    public void InitCard(string cardName, string cardExplain, Sprite image)
    {
        _cardNameText.SetText(cardName);
        _cardExplainText.SetText(cardExplain);
        _cardImage.sprite = image;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
