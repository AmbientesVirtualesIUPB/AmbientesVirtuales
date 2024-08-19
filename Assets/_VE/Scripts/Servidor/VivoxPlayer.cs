using System.Collections;
using System.Collections.Generic;
using Unity.Services.Vivox;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Android;
//using VivoxUnity;

public class VivoxPlayer : MonoBehaviour
{
    public static VivoxPlayer singleton;

    //private VivoxVoiceManager _vvm;
    //IChannelSession _chan;
    //private int PermissionAskedCount;
    //public string VoiceChannelName = "CIS";
    //float _nextUpdate = 0;

    public Transform xrCam; 

	private void Awake()
	{
        singleton = this;
	}

	async void Start()
    {
        if (xrCam == null) xrCam = transform;

        await InitializeAsync();
    }

    async Task InitializeAsync()
	{
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        await VivoxService.Instance.InitializeAsync();
        print("Hola ke hace");
	}

}