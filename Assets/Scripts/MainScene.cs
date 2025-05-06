using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void Start()
    {
        // 기본 해상도 설정 (모바일 기기 대응)
        Screen.SetResolution(1080, 1920, false);
    }
    
    public void LoadHygieneCheckScene()
    {
        SceneManager.LoadScene("HygieneCheckScene");
    }
}