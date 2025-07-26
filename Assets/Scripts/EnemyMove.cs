using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float shakeIntensityPosition = 0.1f; // �ʒu�̗h��̋���
    public float shakeIntensityRotation = 1f;   // ��]�̗h��̋���
    public float shakeTime = 0.5f;              // �h�ꂪ�������鎞��
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
            // �����_���ȗh���K�p
            Vector3 randomPosition = originalPosition + Random.insideUnitSphere * shakeIntensityPosition;
            Quaternion randomRotation = originalRotation * Quaternion.Euler(Random.insideUnitSphere * shakeIntensityRotation);

            transform.localPosition = randomPosition;
            transform.localRotation = randomRotation;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
            // �h�ꂪ�I�������猳�̈ʒu�Ɖ�]�ɖ߂�
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartShaking();
    }

    // �h����J�n����֐�
    public void StartShaking()
    {
        shakeTimer = shakeTime;
    }
}
