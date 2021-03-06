﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateNewRoomView : MonoBehaviour {
    [SerializeField]
    private Text m_RoomName = null;
    [SerializeField]
    private Text m_MaxPlayers = null;

    public void CreateNewRoom()
    {
        if (!m_RoomName) { return; }
        if (!m_MaxPlayers) { return; }

        string name = !string.IsNullOrEmpty(m_RoomName.text) ? m_RoomName.text : null;
        RoomOptions options = new RoomOptions();
        if (!byte.TryParse(m_MaxPlayers.text, out options.maxPlayers)) { options.maxPlayers = 0; };
        options.isOpen = true;
        options.cleanupCacheOnLeave = true;
        PhotonNetwork.CreateRoom(name, options, TypedLobby.Default);
    }
}
