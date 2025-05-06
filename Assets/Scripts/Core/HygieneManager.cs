// HygieneManager.cs
using UnityEngine;
using UnityEngine.UI; // 기본 UI Text를 사용한다면 필요
using TMPro;          // TextMeshPro를 사용한다면 이 줄을 추가하세요!

public class HygieneManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image avatarHatImage;
    // public Text feedbackText; // 만약 기본 UI Text를 사용했다면 이 줄을 사용
    public TextMeshProUGUI feedbackText; // TextMeshPro를 사용했다면 이 줄로 변경하세요!

    [Header("Clothing Data")]
    public ClothingItem[] hatOptions;
    private ClothingItem currentHat;

    void Start()
    {
        if (avatarHatImage != null)
        {
            avatarHatImage.sprite = null;
            avatarHatImage.enabled = false;
        }
        if (feedbackText != null)
        {
            feedbackText.text = "착용할 위생모를 선택하세요.";
        }
    }

    public void OnHatSelected(int hatIndex)
    {
        if (hatOptions == null || hatIndex < 0 || hatIndex >= hatOptions.Length)
        {
            Debug.LogError("Hat options not set up correctly or index out of bounds.");
            return;
        }

        ClothingItem selectedHat = hatOptions[hatIndex];
        currentHat = selectedHat;

        if (avatarHatImage != null)
        {
            avatarHatImage.sprite = selectedHat.itemSprite;
            avatarHatImage.enabled = true;
        }

        if (feedbackText != null)
        {
            feedbackText.text = selectedHat.feedbackMessage;
            if (!selectedHat.isCorrect && !string.IsNullOrEmpty(selectedHat.ruleViolationMessage))
            {
                feedbackText.text += "\n(위반 사유: " + selectedHat.ruleViolationMessage + ")";
            }
        }
    }

    public void CheckFinalCompliance()
    {
        // ... (이전 코드와 동일)
        if (currentHat == null)
        {
            feedbackText.text = "모자를 선택하지 않았습니다! (실격 또는 감점)";
            return;
        }

        if (currentHat.isCorrect)
        {
            feedbackText.text = "모자 착용: 규정 준수! 다음 단계를 진행하세요.";
        }
        else
        {
            feedbackText.text = "모자 착용: 규정 위반 (" + currentHat.ruleViolationMessage + ") 최종 평가에서 감점/실격될 수 있습니다.";
        }
    }
}