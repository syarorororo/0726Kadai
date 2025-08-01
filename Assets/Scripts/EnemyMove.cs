using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float shakeIntensityPosition = 0.1f; // 位置の揺れの強さ
    public float shakeIntensityRotation = 1f;   // 回転の揺れの強さ
    public float shakeTime = 0.5f;              // 揺れが持続する時間
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float shakeTimer = 0f;

    void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            // ランダムな揺れを適用
            Vector3 randomPosition = originalPosition + Random.insideUnitSphere * shakeIntensityPosition;
            Quaternion randomRotation = originalRotation * Quaternion.Euler(Random.insideUnitSphere * shakeIntensityRotation);

            transform.localPosition = randomPosition;
            transform.localRotation = randomRotation;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
            // 揺れが終了したら元の位置と回転に戻す
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartShaking();
    }

    // 揺れを開始する関数
    public void StartShaking()
    {
        shakeTimer = shakeTime;
    }
}
