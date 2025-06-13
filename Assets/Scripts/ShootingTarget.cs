using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootingTarget : MonoBehaviour
{
    [SerializeField] private Transform _joint;

    private Vector3 _attackedRotate = new Vector3(90, 0, 0);

    private WaitForSeconds _delay = new WaitForSeconds(3f);
    private Coroutine _delayCoroutine;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if(_delayCoroutine == null)
            {
                _delayCoroutine = StartCoroutine(AttackedTarget());
            }
        }
    }

    private IEnumerator AttackedTarget()
    {
        _joint.DOLocalRotateQuaternion(Quaternion.Euler(_attackedRotate), 1f);

        yield return _delay;

        _joint.DOLocalRotateQuaternion(Quaternion.Euler(Vector3.zero), 1f);
        _delayCoroutine = null;
    }
}
