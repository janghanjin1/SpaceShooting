using UnityEngine;
using UnityEngine.Pool;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;
    
    // 메모리 풀로 사용할 게임 오브젝트
    [SerializeField] Bullet lazerPrefab;

    // 메모리 풀로 사용할 클래스
    private IObjectPool<Bullet> lazerPool;

    private void Awake()
    {
        // 1. 생성하는 함수
        // 2. 활성화 하는 함수
        // 3. 비활성화 하는 함수
        // 4. 게임 오브젝트를 파괴하는 함수
        // 5. maxSize 메모리에 저장하고 싶은 갯수
        
        lazerPool = new ObjectPool<Bullet>(LazerCreate, LazerGet, ReleaseLazer, DestroyLazer, maxSize : 20); 
    }

    void Start()
    { 
        InvokeRepeating(nameof(InfiniteLazer), 0, 0.025f);
    }

    public void InfiniteLazer()
    {
        if (GameManager.instance.state == false) return;

        var bullet = lazerPool.Get();
        SoundManager.instance.SoundStart(0);
        bullet.transform.position = centerMuzzle.transform.position;
    }

    void Update()
    {
        
        float x = Input.GetAxis("Mouse X");

        Vector3 direction = new Vector3(x, 0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // 게임 오브젝트 위치를 스크린 공간으로 변환합니다.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        // 좌표 정보를 기준으로 조건문을 작성합니다.
        if (position.x < 0.1f) position.x = 0.1f;
        if (position.x > 0.9f) position.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(position);
        
    }

    // 게임 오브젝트를 생성하는 함수
    public Bullet LazerCreate()
    {
        Bullet bullet = Instantiate(lazerPrefab).GetComponent<Bullet>();
        bullet.SetPool(lazerPool);
        return bullet;
    }

    // Get이 실행될 때 실행되는 함수
    // 게임 오브젝트를 활성화하는 함수
    public void LazerGet(Bullet lazer)
    {
        lazer.gameObject.SetActive(true);
    }

    // 게임 오브젝트를 비활성화하는 함수
    public void ReleaseLazer(Bullet lazer)
    {
        lazer.gameObject.SetActive(false);
    }

    // 게임 오브젝트를 파괴하는 함수
    public void DestroyLazer(Bullet lazer)
    {
        Destroy(lazer.gameObject);
    }
}
