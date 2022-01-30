using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint spawn;
    public GameObject tilda;
    public GameObject mort;

    private void Awake()
    {
        spawn = this;
    }
}
