using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    private bool _isReload;


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
