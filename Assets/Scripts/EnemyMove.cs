using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float shakeIntensityPosition = 0.1f; // ˆÊ’u‚Ì—h‚ê‚Ì‹­‚³
    public float shakeIntensityRotation = 1f;   // ‰ñ“]‚Ì—h‚ê‚Ì‹­‚³
    public float shakeTime = 0.5f;              // —h‚ê‚ª‘±‚·‚éŠÔ
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
            // ƒ‰ƒ“ƒ_ƒ€‚È—h‚ê‚ğ“K—p
            Vector3 randomPosition = originalPosition + Random.insideUnitSphere * shakeIntensityPosition;
            Quaternion randomRotation = originalRotation * Quaternion.Euler(Random.insideUnitSphere * shakeIntensityRotation);

            transform.localPosition = randomPosition;
            transform.localRotation = randomRotation;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
            // —h‚ê‚ªI—¹‚µ‚½‚çŒ³‚ÌˆÊ’u‚Æ‰ñ“]‚É–ß‚·
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartShaking();
    }

    // —h‚ê‚ğŠJn‚·‚éŠÖ”
    public void StartShaking()
    {
        shakeTimer = shakeTime;
    }
}
