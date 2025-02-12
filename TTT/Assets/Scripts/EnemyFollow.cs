using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private Transform _followTarget;
    [SerializeField] private LayerMask damageLayerMask;
    private bool _isCollided;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        if (_followTarget && !_isCollided)
        {
            transform.position = Vector2.MoveTowards(transform.position, _followTarget.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController _))
        {
            _isCollided = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (LayerMaskUtil.ContainsLayer(damageLayerMask, collision.gameObject))
        {
            gameObject.SetActive(false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController _))
        {
            _isCollided = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out PlayerController _))
        {
            _followTarget = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out PlayerController _))
        {
            _followTarget = null;
        }
    }

}
