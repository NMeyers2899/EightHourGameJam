using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterOneInputBehavior : MonoBehaviour
{
    private CharacterMovementBehavior _characterMovement;

    [SerializeField]
    private ProjectileSpawnerBehavior _gun;

    [SerializeField]
    private bool _infiniteAmmo = true;

    [SerializeField]
    private int _ammo = 0;

    [SerializeField]
    private Text _deathText;

    [SerializeField]
    private Button _returnButton;

    public int Ammo
    {
        get { return _ammo; }
        set { _ammo = value; }
    }

    public bool CheckHasAmmo()
    {
        if (_infiniteAmmo) return true;

        return _ammo > 0;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _characterMovement = GetComponent<CharacterMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterMovement.MoveDirection = new Vector3(Input.GetAxisRaw("CharacterOneHorizontal"), 0, Input.GetAxisRaw("CharacterOneVertical")).normalized;
        _characterMovement.MouseDirection = new Vector2(Input.GetAxisRaw("MouseX"), Input.GetAxisRaw("MouseY")).normalized;

        // If the player presses the space key, and as long as they have ammo...
        if (Input.GetKeyDown(KeyCode.Space) && CheckHasAmmo())
        {
            // ...fire a projectile.
            _gun.Fire();
            Ammo--;
        }       
    }

    public void Destroy()
    {
        OnDeath();
        Destroy(gameObject);
    }

    public void OnDeath()
    {
        _deathText.enabled = true;
        _returnButton.gameObject.SetActive(true);
    }
}
