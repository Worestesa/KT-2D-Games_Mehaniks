using UnityEngine;

public class BoxKill : MonoBehaviour
{
    [SerializeField] private int _boxhp;
    [SerializeField] private GameObject _splinterPrefab;
    [SerializeField] private int _splinterCount = 10;
    [SerializeField] private float _explosionForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet _))
        {
            _boxhp -= 25;
            if (_boxhp <= 0)
            {
                Crumble();
                Destroy(gameObject);
            }
        }
    }

    private void Crumble()
    {
        if (_splinterPrefab != null)
        {
            for (int i = 0; i < _splinterCount; i++)
            {
                GameObject splinter = Instantiate(_splinterPrefab, transform.position, Quaternion.identity);

                float randomRotation = Random.Range(0f, 360f);
                splinter.transform.Rotate(0f, 0f, randomRotation);

                Rigidbody2D rb = splinter.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 randomDirection = Random.insideUnitCircle.normalized;
                    rb.AddForce(randomDirection * _explosionForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
