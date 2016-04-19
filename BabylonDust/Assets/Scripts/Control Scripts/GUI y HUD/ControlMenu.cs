using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ControlMenu : MonoBehaviour
{

    // Detector Variable
    bool isControllerConnected = false;

    //GameObject Multiplayer
    public GameObject multiplay;

    // Identificador del control
    public string Controller = "";

    public bool detect = false;
    public bool detected = false;

    private bool[] Change = new bool[9];

    private KeyCode keypress;

    // Variables Teclado/Control
    public KeyCode PC_Move_Forward1, PC_Rotate_Right1, PC_Rotate_Left1, PC_Jump1, PC_Sprint1, PC_Action1, PC_ChangeRelic1, PC_Pause1, PC_AttackUse1, PC_Aim1;
    public KeyCode PC_Move_Forward2, PC_Rotate_Right2, PC_Rotate_Left2, PC_Jump2, PC_Sprint2, PC_Action2, PC_ChangeRelic2, PC_Pause2, PC_AttackUse2, PC_Aim2;

    public string Xbox_Move1, Xbox_Rotate1, Xbox_Jump1, Xbox_Sprint1, Xbox_Action1, Xbox_ChangeRelic1, Xbox_Pause1, Xbox_AttackUse1, Xbox_Aim1;

    string ControlScheme;//Player 1 || Player 2

    bool pause = false;
    //KeyCode PreviousKey;

    // Profiler
    public ControlProfile cProfile;

    void DetectController()
    {
        try
        {
            if (Input.GetJoystickNames()[0] != null)
            {
                isControllerConnected = true;
                cProfile = ControlProfile.Controller;
                IdentifyController();
            }
            else
                cProfile = ControlProfile.PC;
        }
        catch
        {
            isControllerConnected = false;
        }
    }

    void IdentifyController()
    {
        Controller = Input.GetJoystickNames()[0];
    }

    void SetDefaultValues()
    {
        ControlScheme = "Player 1";
        if (!isControllerConnected)
        {
            PC_Move_Forward1 = KeyCode.W;
            PC_Rotate_Right1 = KeyCode.D;
            PC_Rotate_Left1 = KeyCode.A;
            PC_Jump1 = KeyCode.Space;
            PC_Sprint1 = KeyCode.LeftShift;
            PC_Action1 = KeyCode.E;
            PC_ChangeRelic1 = KeyCode.R;
            PC_Pause1 = KeyCode.Escape;
            PC_AttackUse1 = KeyCode.Mouse0;
            PC_Aim1 = KeyCode.Mouse1;
            /*
            pcItem1 = KeyCode.Alpha1;
            pcItem2 = KeyCode.Alpha2;
            pcItem3 = KeyCode.Alpha3;
            pcItem4 = KeyCode.Alpha4;
            pcInv = KeyCode.I;
            pcPause = KeyCode.Escape;
            pcAttackUse = KeyCode.Mouse0;
            pcAim = KeyCode.Mouse1;
            orig_pcItem1 = pcItem1;
            orig_pcItem2 = pcItem2;
            orig_pcItem3 = pcItem3;
            orig_pcItem4 = pcItem4;
            orig_pcInv = pcInv;
            orig_pcPause = pcPause;*/
        }
        else
        {
            PC_Move_Forward1 = KeyCode.W;
            PC_Rotate_Right1 = KeyCode.D;
            PC_Rotate_Left1 = KeyCode.A;
            PC_Jump1 = KeyCode.Space;
            PC_Sprint1 = KeyCode.LeftShift;
            PC_Action1 = KeyCode.E;
            PC_ChangeRelic1 = KeyCode.R;
            PC_Pause1 = KeyCode.Escape;
            PC_AttackUse1 = KeyCode.Mouse0;
            PC_Aim1 = KeyCode.Mouse1;
            Xbox_Move1 = "Left Thumbstick";
            Xbox_Rotate1 = "Right Thumbstick";
            Xbox_ChangeRelic1 = "Button1";
            Xbox_Action1 = "D-Pad Up";
            Xbox_Pause1 = "D-Pad Down";
            Xbox_AttackUse1 = "D-Pad Left";
            Xbox_Aim1 = "D-Pad Right";
            /*
            pcItem1 = KeyCode.Alpha1;
            pcItem2 = KeyCode.Alpha2;
            pcItem3 = KeyCode.Alpha3;
            pcItem4 = KeyCode.Alpha4;
            pcInv = KeyCode.I;
            pcPause = KeyCode.Escape;
            pcAttackUse = KeyCode.Mouse0;
            pcAim = KeyCode.Mouse1;
            xInv = KeyCode.JoystickButton0;
            xPause = KeyCode.JoystickButton7;
            orig_pcItem1 = pcItem1;
            orig_pcItem2 = pcItem2;
            orig_pcItem3 = pcItem3;
            orig_pcItem4 = pcItem4;
            orig_pcInv = pcInv;
            orig_pcPause = pcPause;
            orig_xInv = xInv;
            orig_xPause = xPause;*/
        }
    }

    void Reset()
    {
        SetDefaultValues();
        pause = false;

        //PreviousKey = KeyCode.None;
    }

    void SwitchControlScheme(string Scheme)
    {
        switch (Scheme)
        {
            case "1":
                SetDefaultValues();
                break;
            case "2":
                if (multiplay.GetComponent<characterState>().multiplayer)
                {
                    if (!isControllerConnected)
                    {
                        PC_Move_Forward1 = KeyCode.W;
                        PC_Rotate_Right1 = KeyCode.D;
                        PC_Rotate_Left1 = KeyCode.A;
                        PC_Jump1 = KeyCode.Space;
                        PC_Sprint1 = KeyCode.LeftShift;
                        PC_Action1 = KeyCode.E;
                        PC_ChangeRelic1 = KeyCode.R;
                        PC_Pause1 = KeyCode.Escape;
                        PC_AttackUse1 = KeyCode.Mouse0;
                        PC_Aim1 = KeyCode.Mouse1;

                        /*pcItem1 = KeyCode.Keypad1;
                        pcItem2 = KeyCode.Keypad2;
                        pcItem3 = KeyCode.Keypad3;
                        pcItem4 = KeyCode.Keypad4;
                        pcInv = KeyCode.KeypadPlus;
                        pcPause = KeyCode.Return;
                        pcAttackUse = KeyCode.Mouse1;
                        pcAim = KeyCode.Mouse0;*/
                    }
                    else {
                        PC_Move_Forward1 = KeyCode.W;
                        PC_Rotate_Right1 = KeyCode.D;
                        PC_Rotate_Left1 = KeyCode.A;
                        PC_Jump1 = KeyCode.Space;
                        PC_Sprint1 = KeyCode.LeftShift;
                        PC_Action1 = KeyCode.E;
                        PC_ChangeRelic1 = KeyCode.R;
                        PC_Pause1 = KeyCode.Escape;
                        PC_AttackUse1 = KeyCode.Mouse0;
                        PC_Aim1 = KeyCode.Mouse1;
                        Xbox_Move1 = "Left Thumbstick";
                        Xbox_Rotate1 = "Right Thumbstick";
                        Xbox_ChangeRelic1 = "Button1";
                        Xbox_Action1 = "D-Pad Up";
                        Xbox_Pause1 = "D-Pad Down";
                        Xbox_AttackUse1 = "D-Pad Left";
                        Xbox_Aim1 = "D-Pad Right";

                        /*pcItem1 = KeyCode.Keypad1;
                        pcItem2 = KeyCode.Keypad2;
                        pcItem3 = KeyCode.Keypad3;
                        pcItem4 = KeyCode.Keypad4;
                        pcInv = KeyCode.KeypadPlus;
                        pcPause = KeyCode.Return;
                        pcAttackUse = KeyCode.Mouse1;
                        pcAim = KeyCode.Mouse0;
                        xInv = KeyCode.JoystickButton1;
                        xPause = KeyCode.JoystickButton6;*/
                    }
                }
                break;
        }
    }

    void SwitchProfile(ControlProfile Switcher)
    {
        cProfile = Switcher;
    }

    void Start()
    {
        DetectController();
        SetDefaultValues();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pause = !pause;
        }
    }



    private void buttonClicked(/*object sender, System.EventArgs e*/)
    {
        GUI.TextField(new Rect(0, 0, 600, 400), "Change Key");
    }

    void OnGUI()
    {
        if (detect)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keypress = e.keyCode;
                detected = true;
                detect = false;
            }
        }
        //KeyCode key;
        
            GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 100, 600, 400));
            GUI.Box(new Rect(0, 0, 600, 400), "");
            GUI.Label(new Rect(205, 40, 20, 20), "PC");
            GUI.Label(new Rect(340, 40, 125, 20), "Xbox 360 Controller");

            //Move
            GUI.Label(new Rect(25, 75, 125, 20), "Movement: ");
            if (GUI.Button(new Rect(150, 75, 135, 20), PC_Move_Forward1.ToString()) || Change[0])
            {
                detect = true;
                Change[0] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_Move_Forward1 = keypress;
                    detect = false;
                    detected = false;
                    Change[0] = false;
                }

            }
            GUI.Button(new Rect(325, 75, 135, 20), Xbox_Move1);

            //Rotate
            GUI.Label(new Rect(25, 100, 125, 20), "Rotate Right: ");
            if (GUI.Button(new Rect(150, 100, 135, 20), PC_Rotate_Right1.ToString()) || Change[1])
            {
                detect = true;
                Change[1] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_Rotate_Right1 = keypress;
                    detect = false;
                    detected = false;
                    Change[1] = false;
                }
            }
            GUI.Button(new Rect(325, 100, 135, 20), Xbox_Rotate1);

            GUI.Label(new Rect(25, 125, 125, 20), "Rotate Left: ");
            if (GUI.Button(new Rect(150, 125, 135, 20), PC_Rotate_Left1.ToString()) || Change[2])
            {
                detect = true;
                Change[2] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_Rotate_Left1 = keypress;
                    detect = false;
                    detected = false;
                    Change[2] = false;
                }
            }
            GUI.Button(new Rect(325, 125, 135, 20), Xbox_Rotate1);

            //Jump
            GUI.Label(new Rect(25, 150, 125, 20), "Jump: ");
            if (GUI.Button(new Rect(150, 150, 135, 20), PC_Jump1.ToString()) || Change[3])
            {
                detect = true;
                Change[3] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_Jump1 = keypress;
                    detect = false;
                    detected = false;
                    Change[3] = false;
                }
            }
            GUI.Button(new Rect(325, 150, 135, 20), Xbox_Jump1);

            //Sprint
            GUI.Label(new Rect(25, 175, 125, 20), "Sprint: ");
            if (GUI.Button(new Rect(150, 175, 135, 20), PC_Sprint1.ToString()) || Change[4])
            {
                detect = true;
                Change[4] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_Sprint1 = keypress;
                    detect = false;
                    detected = false;
                    Change[4] = false;
                }
            }
            GUI.Button(new Rect(325, 175, 135, 20), Xbox_Sprint1);

            //Action
            GUI.Label(new Rect(25, 200, 125, 20), "Action: ");
            if (GUI.Button(new Rect(150, 200, 135, 20), PC_Action1.ToString()) || Change[5])
            {
                detect = true;
                Change[5] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_Action1 = keypress;
                    detect = false;
                    detected = false;
                    Change[5] = false;
                }
            }
            GUI.Button(new Rect(325, 200, 135, 20), Xbox_Action1);

            //Change Relic
            GUI.Label(new Rect(25, 225, 125, 20), "Change Relic: ");
            if (GUI.Button(new Rect(150, 225, 135, 20), PC_ChangeRelic1.ToString()) || Change[6])
            {
                detect = true;
                Change[6] = true;
                GUI.Label(new Rect(200, 315, 250, 50), "Press any key to change the control");
                if (detected)
                {
                    PC_ChangeRelic1 = keypress;
                    detect = false;
                    detected = false;
                    Change[6] = false;
                }
            }
            GUI.Button(new Rect(325, 250, 135, 20), Xbox_ChangeRelic1);

            //Attack
            GUI.Label(new Rect(25, 275, 125, 20), "Attack: ");
            GUI.Button(new Rect(150, 275, 135, 20), PC_AttackUse1.ToString());
            GUI.Button(new Rect(325, 275, 135, 20), Xbox_AttackUse1);

            //Aim
            GUI.Label(new Rect(25, 250, 125, 20), "Aim: ");
            GUI.Button(new Rect(150, 250, 135, 20), PC_Aim1.ToString());
            GUI.Button(new Rect(325, 225, 135, 20), Xbox_Aim1);

            GUI.Label(new Rect(450, 345, 125, 20), "Current Controls");
            if (GUI.Button(new Rect(425, 370, 135, 20), cProfile.ToString()))
            {
                if (cProfile == ControlProfile.Controller)
                    SwitchProfile(ControlProfile.PC);
                else
                    SwitchProfile(ControlProfile.Controller);
            }

            //Reset Controls
            if (GUI.Button(new Rect(230, 370, 135, 20), "Reset Controls"))
            {
                Reset();
            }

            //Change Scheme
            GUI.Label(new Rect(70, 345, 125, 20), "Player");
            if (GUI.Button(new Rect(25, 370, 135, 20), ControlScheme))
            {
                if (ControlScheme == "Player 1" && multiplay.GetComponent<characterState>().multiplayer)
                {
                    SwitchControlScheme("2");
                    ControlScheme = "Player 2";
                }
                else {
                    SwitchControlScheme("1");
                    ControlScheme = "Player 1";
                }
            }
            GUI.EndGroup();
        
    }


}