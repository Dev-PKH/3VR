using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeScene : TeleportationAnchor
{
    public int sceneIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
	{
        SceneManager.LoadScene(sceneIndex);
        return true;
	}
}
