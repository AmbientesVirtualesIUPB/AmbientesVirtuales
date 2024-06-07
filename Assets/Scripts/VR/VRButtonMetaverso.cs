using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class VRButtonMetaverso : MonoBehaviour
{
    public InputActionProperty accionReferencia;
    public UnityEvent mouseSobre;
    public UnityEvent mouseFuera;
    public UnityEvent mouseClick;
    public bool activo;

    bool fueActivado;

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { MouseSobre((PointerEventData)data); });
        trigger.triggers.Add(entry);


        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((data) => { MouseFuera((PointerEventData)data); });
        trigger.triggers.Add(entry2);


    }


    public void MouseSobre(PointerEventData data)
    {
        activo = true;
        mouseSobre.Invoke();
        if (UISonidoDefault.singleton != null) UISonidoDefault.singleton.ReproducirAudio(0);
    }

    public void MouseFuera(PointerEventData data)
    {
        activo = false;
        mouseFuera.Invoke();
    }

    public void MouseClick()
    {
        mouseClick.Invoke();
        if (UISonidoDefault.singleton != null) UISonidoDefault.singleton.ReproducirAudio(1);

    }

    private void Update()
    {
        if (activo && !fueActivado && accionReferencia.action.ReadValue<float>()>0.5f)
        {
            StartCoroutine(ActivaClick());
        }
    }

    public IEnumerator ActivaClick()
    {
        fueActivado = true;
        MouseClick();
        int cuenta = 0;
        while (fueActivado && accionReferencia.action.ReadValue<float>()>0.5f)
        {
            yield return new WaitForSeconds(0.5f);
            cuenta++;
            if (cuenta >= 4)
            {
                fueActivado = false;
            }
        }
        fueActivado = false;
    }

}
