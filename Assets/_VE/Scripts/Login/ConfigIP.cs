using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigIP : MonoBehaviour
{
    public TMPro.TMP_InputField inpIP;

    void Start()
    {
		if (inpIP!=null)
		{
            inpIP.text = GetIP();
        }
    }

    public string GetIP()
	{
        return PlayerPrefs.GetString("ip", "127.0.0.1");
    }

    public void GuardarIP(string nIp)
	{
        PlayerPrefs.SetString("ip", nIp!= ""? nIp:"127.0.0.1");
    }
}
