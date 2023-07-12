using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputController : MonoBehaviour
{
    protected static Dictionary<KeyCode, bool> keyDowns = new Dictionary<KeyCode, bool>();
    protected static Dictionary<KeyCode, bool> keyHolds = new Dictionary<KeyCode, bool>();

    public static KeyCode FireButtonKeyCode { get; protected set; }
    public static KeyCode ReloadButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon1ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon2ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon3ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon4ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon5ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon6ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon7ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon8ButtonKeyCode { get; protected set; }
    public static KeyCode SelectWeapon9ButtonKeyCode { get; protected set; }

    private void Awake()
    {
        FireButtonKeyCode = KeyCode.Mouse0;
        ReloadButtonKeyCode = KeyCode.Mouse1;
        SelectWeapon1ButtonKeyCode = KeyCode.Alpha1;
        SelectWeapon2ButtonKeyCode = KeyCode.Alpha2;
        SelectWeapon3ButtonKeyCode = KeyCode.Alpha3;
        SelectWeapon4ButtonKeyCode = KeyCode.Alpha4;
        SelectWeapon5ButtonKeyCode = KeyCode.Alpha5;
        SelectWeapon6ButtonKeyCode = KeyCode.Alpha6;
        SelectWeapon7ButtonKeyCode = KeyCode.Alpha7;
        SelectWeapon8ButtonKeyCode = KeyCode.Alpha8;
        SelectWeapon9ButtonKeyCode = KeyCode.Alpha9;

        keyDowns.Add(FireButtonKeyCode, false);
        keyDowns.Add(ReloadButtonKeyCode, false);
        keyDowns.Add(SelectWeapon1ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon2ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon3ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon4ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon5ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon6ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon7ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon8ButtonKeyCode, false);
        keyDowns.Add(SelectWeapon9ButtonKeyCode, false);

        keyHolds.Add(FireButtonKeyCode, false);
    }

    public static bool FireButton
    {
        get { return keyDowns[FireButtonKeyCode]; }
    }

    public static bool FireHold
    {
        get { return keyHolds[FireButtonKeyCode]; }
    }

    public static bool ReloadButton
    {
        get { return keyDowns[ReloadButtonKeyCode]; }
    }

    public static bool SelectWeapon1Button
    {
        get { return keyDowns[SelectWeapon1ButtonKeyCode]; }
    }

    public static bool SelectWeapon2Button
    {
        get { return keyDowns[SelectWeapon2ButtonKeyCode]; }
    }

    public static bool SelectWeapon3Button
    {
        get { return keyDowns[SelectWeapon3ButtonKeyCode]; }
    }

    public static bool SelectWeapon4Button
    {
        get { return keyDowns[SelectWeapon4ButtonKeyCode]; }
    }

    public static bool SelectWeapon5Button
    {
        get { return keyDowns[SelectWeapon5ButtonKeyCode]; }
    }

    public static bool SelectWeapon6Button
    {
        get { return keyDowns[SelectWeapon6ButtonKeyCode]; }
    }

    public static bool SelectWeapon7Button
    {
        get { return keyDowns[SelectWeapon7ButtonKeyCode]; }
    }

    public static bool SelectWeapon8Button
    {
        get { return keyDowns[SelectWeapon8ButtonKeyCode]; }
    }

    public static bool SelectWeapon9Button
    {
        get { return keyDowns[SelectWeapon9ButtonKeyCode]; }
    }

    void Update()
    {
        KeyCode[] keyDownKeys = keyDowns.Keys.ToArray();

        for (int i = 0; i < keyDownKeys.Length; i++)
        {
            KeyCode keyCode = keyDownKeys[i];
            bool down = Input.GetKeyDown(keyCode);
            keyDowns[keyCode] = down;
        }

        KeyCode[] keyHoldKeys = keyHolds.Keys.ToArray();

        for (int i = 0; i < keyHoldKeys.Length; i++)
        {
            KeyCode keyCode = keyHoldKeys[i];
            bool down = Input.GetKey(keyCode);
            keyHolds[keyCode] = down;
        }
    }
}