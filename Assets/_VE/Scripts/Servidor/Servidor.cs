using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Best.WebSockets;
public class Servidor : MonoBehaviour
{
    public delegate void Evento();

    public string url = "ws://127.0.0.1:8080";
    public UnityEngine.UI.Text txt;
    WebSocket ws;
    public GestionMensajesServidor gestorMensajes;
    public Evento EventoConectado;
    public static Servidor singleton;



    private void Awake()
    {
        singleton = this;
    }

    public void Conectar()
    {
        var webSocket = new WebSocket(new Uri(url));
        ws = webSocket;
        webSocket.OnOpen += OnWebSocketOpen;
        webSocket.OnMessage += OnMessageReceived;
        webSocket.OnClosed += OnWebSocketClosed;
        webSocket.Open();
    }

    private void OnWebSocketOpen(WebSocket webSocket)
    {
        Debug.Log("Websocket abierto!");
        txt.text += "\n" + ("Websocket abierto!");

        EventoConectado();
        Presentacion p = ControlUsuario.singleton.GetPresentacion();
        string pJson = JsonUtility.ToJson(p);

        webSocket.Send("PR00" + pJson);
        webSocket.Send("AC00 ");

    }

    private void OnMessageReceived(WebSocket webSocket, string message)
    {
        Debug.Log("Mensaje recibido: " + message);
        txt.text += "\n" + ("Mensaje recibido: " + message);
        if (txt.text.Length > 500)
        {
            txt.text = txt.text.Substring(txt.text.Length - 455);

        }
        if (gestorMensajes != null)
        {
            gestorMensajes.RecibirMensaje(message.Substring(2));
        }
    }

    private void OnWebSocketClosed(WebSocket webSocket, WebSocketStatusCodes code, string message)
    {
        Debug.Log("WebSocket is now Closed!");

        if (code == WebSocketStatusCodes.NormalClosure)
        {
            // Closed by request
        }
        else
        {
            // Error
        }
    }
    public void EnviarMensaje(string msj)
    {
        ws.Send(msj);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount>0)
        //{
        //          ws.Send("Aiya-> " + UnityEngine.Random.Range(0, 1895));
        //      }
    }
}
