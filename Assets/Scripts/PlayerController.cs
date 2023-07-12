using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseController
{
    public static int Ammo;
    public static float ReloadTime;
    public Slider _slider;
    public static bool isRealoading;
    public static float reloadTime;
    public TextMeshProUGUI ammoAmountText;
    [SerializeField] private Joystick leftJoystick;

    public Joystick LeftJoystick
    {
        set { leftJoystick = value; }
    }

    [SerializeField] private Joystick rightJoystick;

    public Joystick RightJoystick
    {
        set { rightJoystick = value; }
    }

    protected List<Weapon> Weapons = new List<Weapon>();

    public float Horizontal;
    public float Vertical;
    public Vector2 Direction;

    public float Speed = 5f;
    public Vector2 Velocity = new Vector2();

    public float Rotation = 0;

    public Vector2 Position
    {
        get { return tf.position; }
    }

    [SerializeField] protected int currentWeaponIndex;

    public Weapon CurrentWeapon
    {
        get { return Weapons[currentWeaponIndex]; }
    }

    protected override void Awake()
    {
        base.Awake();

        Weapon[] weapons = GetComponentsInChildren<Weapon>();
        Weapons.AddRange(weapons);

        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        ChangeWeapon(0);
    }

    public void ChangeWeapon(int index)
    {
        CurrentWeapon.gameObject.SetActive(false);
        currentWeaponIndex = index;
        CurrentWeapon.gameObject.SetActive(true);
    }

    public Vector3 MousePosition;
    private float fillTime = 0;
    void FillSlider()
    {
        _slider.value = Mathf.Lerp(_slider.minValue, _slider.maxValue, reloadTime);

        fillTime += 0.375f * Time.deltaTime;
    }
 
    void ResetSlider()
    {
        _slider.value = _slider.minValue;
    }
    private void Update()
    {
        if (isRealoading)
        {
            FillSlider();
        }
        else
        {
            ResetSlider();
        }

        ammoAmountText.text = $"{Ammo}";
        // Horizontal = leftJoystick.Horizontal;
        // Vertical = leftJoystick.Vertical;

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Velocity = new Vector2(Horizontal, Vertical) * Speed;

        Direction = rightJoystick.Direction;

        if (Direction.magnitude > 0.1f)
        {
            Rotation = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90f;
        }

        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float deltaX = MousePosition.x - tf.position.x;
        float deltaY = MousePosition.y - tf.position.y;
        Rotation = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg - 90f;

        tf.rotation = Quaternion.Euler(0, 0, Rotation);

        rb.velocity = Velocity;

        bool fireButton = false;
        switch (CurrentWeapon.Mode)
        {
            case FireMode.None:
                Debug.LogError($"Weapon {CurrentWeapon.name} has mode None");
                Debug.Break();
                break;
            case FireMode.Semi:
                fireButton = InputController.FireButton;
                break;
            case FireMode.Auto:
                fireButton = InputController.FireHold;
                break;
            default:
                Debug.LogError($"Weapon {CurrentWeapon.name} default case");
                Debug.Break();
                break;
        }

        if (fireButton)
        {
            CurrentWeapon.Fire();
        }

        if (InputController.ReloadButton)
        {
            CurrentWeapon.Reload();
        }

        if (InputController.SelectWeapon1Button)
        {
            ChangeWeapon(0);
        }

        if (InputController.SelectWeapon2Button)
        {
            ChangeWeapon(1);
        }

        if (InputController.SelectWeapon3Button)
        {
            ChangeWeapon(2);
        }

        if (InputController.SelectWeapon4Button)
        {
            ChangeWeapon(3);
        }

        if (InputController.SelectWeapon5Button)
        {
            ChangeWeapon(4);
        }

        if (InputController.SelectWeapon6Button)
        {
            ChangeWeapon(5);
        }

        if (InputController.SelectWeapon7Button)
        {
            ChangeWeapon(6);
        }

        if (InputController.SelectWeapon8Button)
        {
            ChangeWeapon(7);
        }

        if (InputController.SelectWeapon9Button)
        {
            ChangeWeapon(8);
        }
    }
}