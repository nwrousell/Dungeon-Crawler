using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{

    private string lastRoom = "Room1";

    public void LoadRoom(string roomName)
    {
        SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        SceneManager.UnloadSceneAsync(lastRoom);

        lastRoom = roomName;
    }

}
