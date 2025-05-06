// ClothingItem.cs
using UnityEngine;

[System.Serializable] // Inspector 창에서 보기 좋게 배열로 표시하기 위함
public class ClothingItem
{
    public string itemName; // 아이템 이름 (예: "정답 위생모", "패션모자")
    public Sprite itemSprite; // UI 버튼 및 아바타에 표시될 스프라이트
    public bool isCorrect; // 정답 아이템인지 여부
    public string feedbackMessage; // 선택 시 표시될 피드백 메시지 (정답/오답 모두)
    public string ruleViolationMessage; // (오답일 경우) 어떤 규정 위반인지 설명
}