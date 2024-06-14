using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyMorion : MonoBehaviour
{
    public Joystick joystick;

	private void Update()
	{
		Inputstor.h1 = joystick.Horizontal;
		Inputstor.v1 = joystick.Vertical;
	}
}
