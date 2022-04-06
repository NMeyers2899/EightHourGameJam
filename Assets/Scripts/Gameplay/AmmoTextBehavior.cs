using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;

    [SerializeField]
    private CharacterOneInputBehavior _characterOne;

    // Update is called once per frame
    void Update()
    {
        float ammo = _characterOne.Ammo;

        _ammoText.text = "Ammo : " + ammo;
    }
}
