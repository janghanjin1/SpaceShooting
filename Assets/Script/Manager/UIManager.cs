using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject mainMenu;
    [SerializeField] Image fadePanel;


    void Start()
    {
        
    }

    void Update()
    {
        score.text = "Kill : " + GameManager.instance.score; // �̱����� �̿��� ������    
    }

    // �� �Լ��� ��ư�� ����� �� ���� ������Ʈ �Ű� ������ ���� ������Ʈ�� ����� �� �ֽ��ϴ�.
    // ����� ���� ������Ʈ�� ��Ȱ��ȭ�� �� �ֽ��ϴ�.
    public void GameStart()
    {
        StartCoroutine(FadeIn(1));
 
        GameManager.instance.state = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Time.unscaledDeltaTime : Time Scale�� ������ ���� �ʴ� �ð� �Դϴ�.
    }

    // �Ű� ���� time�� FadeIn �Ǵ� �ð��� �����ϴ� �����Դϴ�.
    private IEnumerator FadeIn(float time)
    {
        Color color = fadePanel.color;

        // 0 ~ 255 (0 ~ 1)������ ������ ����մϴ�. => Unity�� Image Color
        // Image�� ���İ��� 0�� �Ǵ� ���� While���� Ż���մϴ�.
        while(color.a < 0f)
        {
            color.a -= Time.deltaTime / time;
            fadePanel.color = color; // ���İ��� ���ΰ��� ���� �ȴ�.
            yield return null; 
        }

        // �ڷ�ƾ �Լ��� �� ������ �� mainMenu�� ��Ȱ��ȭ�մϴ�.
        mainMenu.SetActive(false);
    }
}
