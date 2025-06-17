using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    [SerializeField] private GameObject _pinPrefab;
    [SerializeField] private Transform _pinTransform;

    public event Action OnExploded;

    private WaitForSeconds _delay;
    private float _countTime = 5f;

    private void Awake() => Init();

    private void Init()
    {
        _delay = new WaitForSeconds(_countTime);
        Instantiate(_pinPrefab, _pinTransform.position, _pinTransform.rotation);
    }

    public void PinOut(SelectExitEventArgs args)
    {
        args.interactableObject.transform.gameObject.layer = LayerMask.NameToLayer("Default");
        StartCoroutine(StartCountDown());
    }

    private void Explosion()
    {
        Debug.Log("Explosion");
        OnExploded?.Invoke();
    }

    private IEnumerator StartCountDown()
    {
        yield return _delay;

        Explosion();
    }
}
