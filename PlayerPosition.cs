using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

    #region Singleton

    public static PlayerPosition instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
