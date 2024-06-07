using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Exploración/Varios/E Escenas")]
public class EEscenas : MonoBehaviour
{

    public void CambiarEscena(string nombre)
	{
		SceneManager.LoadScene(nombre);
	}

	public void CambiarEscena(EVariables variable)
	{
		SceneManager.LoadScene(variable.variablePalabra);
	}

	public void ReiniciarEscena()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Salir()
	{
		Application.Quit();
	}
}
