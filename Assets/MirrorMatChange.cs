using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class MirrorMatChange : XRGrabInteractable

{
    public Material Clear;
    public Material Mirror;
    public GameObject lensMat;

    void Start()
    {
        lensMat.GetComponent<Renderer>().material = Clear;
    }

    protected override void Grab()
    {
        base.Grab();
        SetMatMirror();
    }

    protected override void Drop()
    {
        base.Drop();
        SetMatClear();
    }

    public void SetMatClear()
    {
        lensMat.GetComponent<Renderer>().material = Clear;
    }

	public void SetMatMirror()
	{
        lensMat.GetComponent<Renderer>().material = Mirror;
	}
}
