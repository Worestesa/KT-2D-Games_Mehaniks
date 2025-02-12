using UnityEngine;

public class Splinter : MonoBehaviour
{
    [SerializeField] private float _lifetime = 3f;
    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}
