using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTwoInputBehaivor : MonoBehaviour
{
    private CharacterMovementBehavior _characterMovement;

    [SerializeField]
    private CharacterOneInputBehavior _characterOne;

    // Start is called before the first frame update
    void Awake()
    {
        _characterMovement = GetComponent<CharacterMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterMovement.MoveDirection = new Vector3(Input.GetAxisRaw("CharacterTwoHorizontal"), 0, Input.GetAxisRaw("CharacterTwoVertical")).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the other is a collectable...
        if (other.CompareTag("Collectable"))
        {
            // ...destroy it and add one to Character One's ammo count.
            Destroy(other.gameObject);
            _characterOne.Ammo++;
        }
    }
}
