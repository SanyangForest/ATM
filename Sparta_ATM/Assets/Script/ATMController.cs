using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour
{
    public Text balanceText; // 잔액을 표시할 UI Text 요소
    public Text cashText; // 현금을 표시할 UI Text 요소
    public InputField depositInput; // 사용자가 입금할 금액을 입력할 InputField
    public InputField withdrawInput;

    private int balance = 50000; // 초기 잔액
    private int cash = 100000; // 초기 현금

    public Text nameText; // 이름을 표시할 UI Text 요소
    public InputField inputName; // 사용자로부터 이름을 입력받을 InputField
    public Text confirmText; // 확인 메시지를 표시할 UI Text 요소
    public Button yesButton; // 예 버튼
    public Button noButton; // 아니오 버튼

    private string currentName; // 현재 이름 저장 변수

    public GameObject depositUI;
    public GameObject withdrawUI;
    public GameObject depositButton;
    public GameObject withdrawButton;
    public InputField InputField_Deposit; // 입금 금액을 입력하는 InputField
    public InputField InputField_Withdraw; // 출금 금액을 입력하는 InputField
    public Button DepositButton; // 입금 버튼
    public Button WithdrawButton; // 출금 버튼
    public Text P_Text_Rightbabe;
    public Button Return;
    
   

    
    public PopupManager popupManager;




    private void Start()
    {
        UpdateUI(); // UI 업데이트 함수 호출
        EnableNameInput();
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
        ClosePopup();
        InputField_Deposit.gameObject.SetActive(false);
        InputField_Withdraw.gameObject.SetActive(false);
        DepositButton.gameObject.SetActive(false);
        WithdrawButton.gameObject.SetActive(false);
        P_Text_Rightbabe.gameObject.SetActive(false);
        Return.gameObject.SetActive(false);
        
        
    }

    public void DepositButtonClick()
    {
        // 입금 버튼을 클릭했을 때
        // DepositUI 활성화, 입금 버튼 비활성화
        depositUI.SetActive(true);
        InputField_Deposit.gameObject.SetActive(true);
        DepositButton.gameObject.SetActive(true);
        P_Text_Rightbabe.gameObject.SetActive(true);
        Return.gameObject.SetActive(true);

        // Button_Deposit와 Button_withdraw를 비활성화
        GameObject depositButton = GameObject.Find("Button_Deposit");
        if (depositButton != null)
        {
            depositButton.SetActive(false);
        }

        // Button_withdraw를 비활성화
        if (withdrawButton != null)
        {
            withdrawButton.SetActive(false);
        }
        
    }

    public void WithdrawButtonClick()
    {
        // 출금 버튼을 클릭했을 때
        // WithdrawUI 활성화, 출금 버튼 비활성화
        if (withdrawUI != null)
        {
            withdrawUI.SetActive(true);
        }
        InputField_Withdraw.gameObject.SetActive(true);
        WithdrawButton.gameObject.SetActive(true);
        P_Text_Rightbabe.gameObject.SetActive(true);
        Return.gameObject.SetActive(true);

        // Button_Withdraw와 Button_Deposit를 비활성화
        if (withdrawButton != null)
        {
            withdrawButton.SetActive(false);
        }

        if (depositButton != null)
        {
            depositButton.SetActive(false);
        }
    }

    private void UpdateUI()
    {
        // UI Text 업데이트
        balanceText.text = "잔액: " + string.Format("{0:N0}", balance); 
        cashText.text = "현금: " + string.Format("{0:N0}", cash); 
    }
    

    private void ShowBalanceInsufficientPopup()
    {
        // 잔액 부족 팝업을 표시
        popupManager.ShowBalanceInsufficientPopup();
    }

    // 이름 입력을 시작하는 함수
    public void EnableNameInput()
    {
        confirmText.text = "이름을 입력해주세요.";
        inputName.interactable = true; // 이름 입력 활성화
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        inputName.text = ""; // 입력 필드 초기화
        inputName.Select(); // 입력 필드 선택
        inputName.onEndEdit.AddListener(delegate { SetName(); }); // Enter 키 이벤트 리스너 등록
    }

    // 이름을 설정하는 함수
    public void SetName()
    {
        string name = inputName.text;

        if (string.IsNullOrEmpty(name))
        {
            confirmText.text = "값을 입력해주세요.";
            return; // 값이 없으면 함수 종료
        }

        currentName = name;
        nameText.text = "이름: " + currentName;
        confirmText.text = "맞으신가요? (예/아니오)";
        inputName.interactable = false; // 이름 입력 비활성화
        yesButton.gameObject.SetActive(true); // 예 버튼 활성화
        noButton.gameObject.SetActive(true); // 아니오 버튼 활성화
        yesButton.onClick.AddListener(ConfirmName);
        noButton.onClick.AddListener(CancelName);
    }

    // 예 버튼 클릭 시 호출되는 함수
    public void ConfirmName()
    {
        // 이름 확정, UI 요소 숨김 및 다시 입력 활성화
        confirmText.text = "";
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        Destroy(inputName.gameObject);
    }

    // 아니오 버튼 클릭 시 호출되는 함수
    public void CancelName()
    {
        // 이름 취소, UI 요소 숨김 및 다시 입력 활성화
        confirmText.text = "값을 입력해주세요";
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        inputName.interactable = true;
        inputName.text = ""; // 입력 필드 초기화
        inputName.Select(); // 입력 필드 선택
        inputName.onEndEdit.AddListener(delegate { SetName(); }); // Enter 키 이벤트 리스너 재등록
    }

    public void On10000ButtonClick()
    {
        // [10000] 버튼 클릭 시 10,000원을 입금하는 로직
        DepositMoney(10000);
    }

    public void On30000ButtonClick()
    {
        // [30000] 버튼 클릭 시 30,000원을 입금하는 로직
        DepositMoney(30000);
    }

    public void On50000ButtonClick()
    {
        // [50000] 버튼 클릭 시 50,000원을 입금하는 로직
        DepositMoney(50000);
    }

    public void OnDepositButtonClick()
    {
        if (int.TryParse(InputField_Deposit.text, out int depositAmount))
        {
            if (depositAmount > 0)
            {
                if (depositAmount <= cash)
                {
                    balance += depositAmount;
                    cash -= depositAmount;
                    UpdateUI();
                    InputField_Deposit.text = "";
                }
                else
                {
                    ShowBalanceInsufficientPopup();
                }
            }
            else
            {
                // 유효하지 않은 금액 처리
                ShowInvalidAmountPopup("입금할 금액은 0 이상이어야 합니다.");
            }
        }
        else
        {
            // 정수로 변환할 수 없는 입력 처리
            ShowInvalidAmountPopup("올바른 숫자를 입력하세요.");
        }
    }
    private void DepositMoney(int amount)
    {
        // 사용자가 입력한 금액을 입금하고 잔액 업데이트
        if (amount <= cash)
        {
            balance += amount;
            cash -= amount;
            UpdateUI();
        }
        else
        {
            // 잔액 부족 시 처리 (예: 팝업 메시지 표시)
            ShowBalanceInsufficientPopup();
        }

    }
    public void On10000ButtonClickW()
    {
        // [10000] 버튼 클릭 시 10,000원을 출금하는 로직
        WithdrawMoney(10000);
    }

    public void On30000ButtonClickW()
    {
        // [30000] 버튼 클릭 시 30,000원을 출금하는 로직
        WithdrawMoney(30000);
    }

    public void On50000ButtonClickW()
    {
        // [50000] 버튼 클릭 시 50,000원을 출금하는 로직
        WithdrawMoney(50000);
    }

    private void WithdrawMoney(int amount)
    {
        // 사용자가 입력한 금액을 출금하고 잔액 업데이트
        if (amount <= balance)
        {
            balance -= amount;
            cash += amount;
            UpdateUI();
        }
        else
        {
            // 잔액 부족 시 처리 (예: 팝업 메시지 표시)
            ShowBalanceInsufficientPopup();
        }
    }
   
    public void OnWithdrawButtonClick()
    {
        if (int.TryParse(InputField_Withdraw.text, out int withdrawAmount))
        {
            if (withdrawAmount > 0)
            {
                if (withdrawAmount <= balance)
                {
                    balance -= withdrawAmount;
                    cash += withdrawAmount;
                    UpdateUI();
                    InputField_Withdraw.text = "";
                }
                else
                {
                    ShowBalanceInsufficientPopup();
                }
            }
            else
            {
                // 유효하지 않은 금액 처리
                ShowInvalidAmountPopup("출금할 금액은 0 이상이어야 합니다.");
            }
        }
        else
        {
            // 정수로 변환할 수 없는 입력 처리
            ShowInvalidAmountPopup("올바른 숫자를 입력하세요.");
        }
    }
    public void ClosePopup()
    {
        // PopupManager 스크립트의 ClosePopup 함수를 호출하여 팝업을 닫음
        popupManager.ClosePopup();
    }
    private void ShowInvalidAmountPopup(string message)
    {
        // 유효하지 않은 금액을 사용자에게 알리는 팝업 표시
        // 예를 들어, 팝업 메시지를 화면에 표시하는 등의 방법으로 처리합니다.
        Debug.LogError("유효하지 않은 금액: " + message);
    }

    public void ReturnToFirst()
    {
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
        InputField_Deposit.gameObject.SetActive(false);
        InputField_Withdraw.gameObject.SetActive(false);
        DepositButton.gameObject.SetActive(false);
        WithdrawButton.gameObject.SetActive(false);
        P_Text_Rightbabe.gameObject.SetActive(false);
        withdrawButton.SetActive(true);
        depositButton.SetActive(true);
    }
    
}

