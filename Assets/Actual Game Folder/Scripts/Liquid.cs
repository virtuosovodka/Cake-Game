using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    public GameObject liquidPrefab;
    public GameObject liquidParticlePrefab;

    private void Start()
    {
        liquidPrefab.SetActive(false);
        liquidParticlePrefab.SetActive(false);
    }

}
