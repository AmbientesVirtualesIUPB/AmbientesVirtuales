using UnityEngine;

[AddComponentMenu("Exploración/Variables/E Interruptores")]
public class EInterruptores : MonoBehaviour
{
	public bool[] interruptores;

	public void InvertirInterruptor(int cual)
	{
		interruptores[cual] = !interruptores[cual];
	}

	public void ActivarInterruptor(int cual)
	{
		interruptores[cual] = true;
	}

	public void DesactivarInterruptor(int cual)
	{
		interruptores[cual] = false;
	}

	public bool LeerInterruptor(int cual)
	{
		if (cual >= interruptores.Length)
			return false;
		return (interruptores[cual]);
	}
}
