using UnityEngine;
using UnityEngine.UI;

public class OpenLock : MonoBehaviour
{
    ParticleSystem _particleSystem;
    Animator _animator;
    Image _image;
    [SerializeField] float speedOpen =1;
    private void OnEnable()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _animator = GetComponent<Animator>();
        _image = GetComponentInParent<Image>();
    }
    public void Open() => Opening();

    private void Opening()
    {
        _animator.SetTrigger("open");
        //_particleSystem.Play();
        _image.color = Color.clear;
    }
}
