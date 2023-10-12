using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel; // 팝업을 나타낼 Panel GameObject
    public Text popupText; // "잔액이 부족합니다" 텍스트를 표시할 Text UI 요소
    public Button Button_Popup;
    public Text Text_PopUP;

    public void ShowBalanceInsufficientPopup()
    {
        popupPanel.SetActive(true);
        popupText.text = "잔액이 부족합니다";
        Button_Popup.gameObject.SetActive(true);
        Text_PopUP.gameObject.SetActive(true);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
    public void ClosePopup()
    {
        Button_Popup.gameObject.SetActive(false);
        Text_PopUP.gameObject.SetActive(false);
    }
}
