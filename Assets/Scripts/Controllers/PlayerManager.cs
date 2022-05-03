using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    //Makes only one instance of this
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    //Didn't have time to continue with this
    public GameObject player;


}
