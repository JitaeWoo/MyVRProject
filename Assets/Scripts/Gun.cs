using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootPower = 10f;

    private bool _isReload;

    public void Shoot(ActivateEventArgs args)
    {
        if (!_isReload) return;

        GameObject bullte = Instantiate(_bulletPrefab, _muzzlePoint.position, _muzzlePoint.rotation);

        bullte.GetComponent<Rigidbody>().AddForce(bullte.transform.forward * _shootPower, ForceMode.Impulse);
    }

    public void Reload(SelectEnterEventArgs arg)
    {
        arg.interactableObject.transform.gameObject.layer = LayerMask.NameToLayer("LoadedMag");
        _isReload = true;
    }

    public void Unload(SelectExitEventArgs arg)
    {
        arg.interactableObject.transform.gameObject.layer = LayerMask.NameToLayer("Default");
        _isReload = false;
    }
}
