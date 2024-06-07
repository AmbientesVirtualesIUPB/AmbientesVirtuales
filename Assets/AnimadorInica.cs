using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorInica : MonoBehaviour
{
    public Animator anim;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			anim.SetBool("cerca", true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			anim.SetBool("cerca", false);
		}
	}
}
