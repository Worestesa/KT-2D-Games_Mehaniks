using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private bool isAiming;
    [SerializeField] private GameObject bullyPrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask damageLayerMask;
    private float _currTimer;
    private Transform _player;
   

    private void Start()
    {
        _currTimer = shootDelay;
        _player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    private void Update()
    {
        DelayShoot();
    }

    private void DelayShoot()
    {
        if (_currTimer > 0)
        {
            _currTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            _currTimer = shootDelay;
        }


    }
    private void Shoot()
    {
        Vector2 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        Instantiate(bullyPrefab, firePoint.position, bulletRotation);       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (LayerMaskUtil.ContainsLayer(damageLayerMask, collision.gameObject))
        {
            gameObject.SetActive(false);
        }
    }


}
