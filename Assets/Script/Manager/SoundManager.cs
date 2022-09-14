using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // SoundStart() �Լ��� �Ű����� count���� ���� �ٸ� ���尡 ��µ˴ϴ�.
    public void SoundStart(int count)
    {
        // PlayOneShot() �Լ��� ����� Ŭ���� ���� ���尡 �� �� ȣ��Ǵ� �Լ��Դϴ�.
        audioSource.PlayOneShot(audioClips[count]); 
    }
}
