using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _gunObject;
    [SerializeField] private GameObject _magObject;

    private Gun _gun;

    private void Awake()
    {
        _gun = _gunObject.GetComponent<Gun>();

        _gunObject.GetComponent<Rigidbody>().isKinematic = true;
        _magObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        WaitForSeconds delay = new WaitForSeconds(1f);

        while (true)
        {
            _gun.Shoot();
            yield return delay;
        }
    }
}
