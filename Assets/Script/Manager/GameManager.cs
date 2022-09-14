using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    // bool ������ �ʱ�ȭ�� ���� ������ false ���� �ڵ����� ���ϴ�.
    public bool state;
    
    private void Awake() // Start �Լ� ������ ������ �˴ϴ�.
    {
        

        if (instance == null)
        {
            instance = this;
        }

        // ���� �����͸� ������ ������ �� �ҷ��ɴϴ�.
        Load();
    }

    public void Save()
    {
        // PlayerPrefs.SetInt �������� �����ϴ� �Լ�
        // KEY - VALUE�� ������ �����մϴ�.
        PlayerPrefs.SetInt("Score", score);
    }

    public void Load()
    {
        // PlayerPrefs.GetInt ������ �����͸� �ҷ����� �Լ�
        score = PlayerPrefs.GetInt("Score");
    }
}
