// GENERATED AUTOMATICALLY FROM 'Assets/Other/Input Actions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""8c4a054d-03e1-476b-a71b-fa0df48fa2db"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""883c4020-9310-4123-ba2e-41d9afb4ecc0"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""a2739362-d384-4d0b-ba40-2f2769b2e56b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""86a9b0c1-efc5-4d49-b73b-6af1b50060db"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""89715159-2c5c-404a-97c9-1d6672059b7c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2e62ea45-0a32-4053-8b60-2610a8156291"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""104dcc5d-602c-4d32-803d-b8896cd141fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8c4ea1e7-92fe-4d63-8249-ec2324360b07"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aad3c72a-3298-4240-a46d-26a647daf053"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""824b2231-9c3c-4e1b-a966-9d38952e5be7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""34f4fb10-4a20-4537-9e67-6e48edcbb2ce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7bf51a60-bd9c-4e70-96e2-3736ed976e4f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e397e706-b1d5-4202-8047-9cf4db2fab72"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""689ee6e4-9518-43cb-8d7c-510de7c091d3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d4072eec-fc4f-4068-9beb-b8d1ccc5a1d3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""6729af22-b074-481d-9506-947db4ed2fe2"",
            ""actions"": [
                {
                    ""name"": ""LeftButtonDebug"",
                    ""type"": ""Button"",
                    ""id"": ""a807d678-c2d4-4484-b89b-181dfec439a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightButtonDebug"",
                    ""type"": ""Button"",
                    ""id"": ""dcd8ae28-be7b-4ec5-a0b7-21fe9c6b7954"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpButtonDebug"",
                    ""type"": ""Button"",
                    ""id"": ""55a703f3-93a2-4885-a0c8-e69d5298009b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownButtonDebug"",
                    ""type"": ""Button"",
                    ""id"": ""7b1bc7e0-8426-495c-b077-157dde6e13a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonDebug"",
                    ""type"": ""Button"",
                    ""id"": ""1d1cde2e-b02b-4ae6-a98d-b12928d30b42"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButtonDebug"",
                    ""type"": ""Button"",
                    ""id"": ""b2f56491-4cd9-41a9-ba25-afe1beff6d3c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8c92bf8-52e1-40e6-8b66-639e7c6f6d6c"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""683c45c2-da3a-423f-9d10-05017979ec0a"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aad3b03c-6993-4214-9a21-b3a81a4d3e2a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4e023dd-f393-40f7-b32d-1112d2ec2f72"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41630e78-1043-4285-a8c2-38d2b5d23839"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e38c0031-b7d8-4217-9407-56fe2ce65557"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d73b438f-da42-4161-b888-e3325e409fb2"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dab65ba1-9e6b-4046-81e2-8138e06e592d"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e8e4d1e-e285-4431-81d4-18ef6f1193ce"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3ba62ed-2d78-4656-9206-fc6e4a955a60"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""320d42ba-3e52-474d-80ed-0373b5a85321"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bb20045-731c-431d-b213-6f0d18780be7"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButtonDebug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_LeftButtonDebug = m_Debug.FindAction("LeftButtonDebug", throwIfNotFound: true);
        m_Debug_RightButtonDebug = m_Debug.FindAction("RightButtonDebug", throwIfNotFound: true);
        m_Debug_UpButtonDebug = m_Debug.FindAction("UpButtonDebug", throwIfNotFound: true);
        m_Debug_DownButtonDebug = m_Debug.FindAction("DownButtonDebug", throwIfNotFound: true);
        m_Debug_SelectButtonDebug = m_Debug.FindAction("SelectButtonDebug", throwIfNotFound: true);
        m_Debug_StartButtonDebug = m_Debug.FindAction("StartButtonDebug", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Shoot;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_LeftButtonDebug;
    private readonly InputAction m_Debug_RightButtonDebug;
    private readonly InputAction m_Debug_UpButtonDebug;
    private readonly InputAction m_Debug_DownButtonDebug;
    private readonly InputAction m_Debug_SelectButtonDebug;
    private readonly InputAction m_Debug_StartButtonDebug;
    public struct DebugActions
    {
        private @PlayerControls m_Wrapper;
        public DebugActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftButtonDebug => m_Wrapper.m_Debug_LeftButtonDebug;
        public InputAction @RightButtonDebug => m_Wrapper.m_Debug_RightButtonDebug;
        public InputAction @UpButtonDebug => m_Wrapper.m_Debug_UpButtonDebug;
        public InputAction @DownButtonDebug => m_Wrapper.m_Debug_DownButtonDebug;
        public InputAction @SelectButtonDebug => m_Wrapper.m_Debug_SelectButtonDebug;
        public InputAction @StartButtonDebug => m_Wrapper.m_Debug_StartButtonDebug;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @LeftButtonDebug.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnLeftButtonDebug;
                @LeftButtonDebug.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnLeftButtonDebug;
                @LeftButtonDebug.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnLeftButtonDebug;
                @RightButtonDebug.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnRightButtonDebug;
                @RightButtonDebug.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnRightButtonDebug;
                @RightButtonDebug.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnRightButtonDebug;
                @UpButtonDebug.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnUpButtonDebug;
                @UpButtonDebug.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnUpButtonDebug;
                @UpButtonDebug.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnUpButtonDebug;
                @DownButtonDebug.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnDownButtonDebug;
                @DownButtonDebug.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnDownButtonDebug;
                @DownButtonDebug.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnDownButtonDebug;
                @SelectButtonDebug.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnSelectButtonDebug;
                @SelectButtonDebug.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnSelectButtonDebug;
                @SelectButtonDebug.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnSelectButtonDebug;
                @StartButtonDebug.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartButtonDebug;
                @StartButtonDebug.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartButtonDebug;
                @StartButtonDebug.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnStartButtonDebug;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftButtonDebug.started += instance.OnLeftButtonDebug;
                @LeftButtonDebug.performed += instance.OnLeftButtonDebug;
                @LeftButtonDebug.canceled += instance.OnLeftButtonDebug;
                @RightButtonDebug.started += instance.OnRightButtonDebug;
                @RightButtonDebug.performed += instance.OnRightButtonDebug;
                @RightButtonDebug.canceled += instance.OnRightButtonDebug;
                @UpButtonDebug.started += instance.OnUpButtonDebug;
                @UpButtonDebug.performed += instance.OnUpButtonDebug;
                @UpButtonDebug.canceled += instance.OnUpButtonDebug;
                @DownButtonDebug.started += instance.OnDownButtonDebug;
                @DownButtonDebug.performed += instance.OnDownButtonDebug;
                @DownButtonDebug.canceled += instance.OnDownButtonDebug;
                @SelectButtonDebug.started += instance.OnSelectButtonDebug;
                @SelectButtonDebug.performed += instance.OnSelectButtonDebug;
                @SelectButtonDebug.canceled += instance.OnSelectButtonDebug;
                @StartButtonDebug.started += instance.OnStartButtonDebug;
                @StartButtonDebug.performed += instance.OnStartButtonDebug;
                @StartButtonDebug.canceled += instance.OnStartButtonDebug;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnLeftButtonDebug(InputAction.CallbackContext context);
        void OnRightButtonDebug(InputAction.CallbackContext context);
        void OnUpButtonDebug(InputAction.CallbackContext context);
        void OnDownButtonDebug(InputAction.CallbackContext context);
        void OnSelectButtonDebug(InputAction.CallbackContext context);
        void OnStartButtonDebug(InputAction.CallbackContext context);
    }
}
