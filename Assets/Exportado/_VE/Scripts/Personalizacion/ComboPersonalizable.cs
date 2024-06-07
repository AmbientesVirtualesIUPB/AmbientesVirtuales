using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboPersonalizable : MonoBehaviour
{
    public Renderer[] mallas;
    public List<Material> materialesPiel;
    public List<Material> materialesPelo;
    public List<Material> materialesRopa;
    public int color0;
    public int color1;
    public int colorPiel0;
    public int colorPiel1;
    public int colorPelo0;
    public int colorPelo1;


    void Awake()
    {
        for (int i = 0; i < mallas.Length; i++)
        {
            for (int j = 0; j < mallas[i].materials.Length; j++)
			{
                Material m = mallas[i].materials[j];
				if (m.name.Length > 3)
				{
					if (m.name.Substring(0, 4) == "SKN_")
					{
                        materialesPiel.Add(m);
                    }
                    else if (m.name.Substring(0, 4) == "FRR_")
                    {
                        materialesPelo.Add(m);
                    }
                    else if (m.name.Substring(0, 4) == "TPR_")
                    {
                        materialesRopa.Add(m);
                    }
                }
			}
		}
    }

    public void ConfigurarColoresPiel(int _color0, int _color1, Color[] colores0, Color[] colores1)
    {
        colorPiel0 = _color0;
        colorPiel1 = _color1;
        for (int i = 0; i < materialesPiel.Count; i++)
        {
            materialesPiel[i].SetColor("_ColorPrincipal", colores0[_color0]);
            materialesPiel[i].SetColor("_ColorSecundario", colores1[_color1]);
        }
    }
    public void ConfigurarColoresPelo(int _color0, int _color1, Color[] colores0, Color[] colores1)
    {
        colorPelo0 = _color0;
        colorPelo1 = _color1;
        print("Cambiando dolores de " + materialesPiel.Count + " por un " + _color0 + " - " + _color1);
        for (int i = 0; i < materialesPelo.Count; i++)
        {
            materialesPelo[i].SetColor("_ColorPrincipal", colores0[_color0]);
            materialesPelo[i].SetColor("_ColorSecundario", colores1[_color1]);
        }
    }
    public void ConfigurarColoresRopa(int _color0, int _color1, Color[] colores0, Color[] colores1)
    {
        color0 = _color0;
        color1 = _color1;
        for (int i = 0; i < materialesRopa.Count; i++)
        {
            materialesRopa[i].SetColor("_ColorPrincipal", colores0[_color0]);
            materialesRopa[i].SetColor("_ColorSecundario", colores1[_color1]);
        }
    }
}
