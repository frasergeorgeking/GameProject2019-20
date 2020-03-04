// GENERATED AUTOMATICALLY FROM 'Assets/Other/Input Actions/MenuControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MenuControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @MenuControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuControls"",
    ""maps"": [
        {
            ""name"": ""MainMenu"",
            ""id"": ""c066d454-ae14-498a-834f-0fff88065e9e"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""e42bc6d1-cdd6-49f1-b683-332d60c8608a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu Down"",
                    ""type"": ""Button"",
                    ""id"": ""c19ada7c-04c9-4300-b866-0c57fa81811a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu Up"",
                    ""type"": ""Button"",
                    ""id"": ""145614fb-558d-4f59-8d31-b5cbaed54add"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a131b0c8-5b11-40df-84de-0ac53bed9025"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa665dac-f2d3-4fe7-873c-e9b0c1ae38d6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29b63788-fb5d-4cc2-8964-ba3e4e312281"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec0aa66f-e25c-4466-a3fd-db9292dd8938"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e51ef30-190b-4cfb-a384-2d4e21eda979"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e090fbf-4826-468c-a8c2-d9a4bf531759"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7e26d44-02b5-4539-aaaa-7a7fd9f955ce"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50df61b8-411b-4f3c-bb05-dd374006040c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Select = m_MainMenu.FindAction("Select", throwIfNotFound: true);
        m_MainMenu_MenuDown = m_MainMenu.FindAction("Menu Down", throwIfNotFound: true);
        m_MainMenu_MenuUp = m_MainMenu.FindAction("Menu Up", throwIfNotFound: true);
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

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Select;
    private readonly InputAction m_MainMenu_MenuDown;
    private readonly InputAction m_MainMenu_MenuUp;
    public struct MainMenuActions
    {
        private @MenuControls m_Wrapper;
        public MainMenuActions(@MenuControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_MainMenu_Select;
        public InputAction @MenuDown => m_Wrapper.m_MainMenu_MenuDown;
        public InputAction @MenuUp => m_Wrapper.m_MainMenu_MenuUp;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelect;
                @MenuDown.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMenuDown;
                @MenuDown.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMenuDown;
                @MenuDown.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMenuDown;
                @MenuUp.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMenuUp;
                @MenuUp.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMenuUp;
                @MenuUp.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMenuUp;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MenuDown.started += instance.OnMenuDown;
                @MenuDown.performed += instance.OnMenuDown;
                @MenuDown.canceled += instance.OnMenuDown;
                @MenuUp.started += instance.OnMenuUp;
                @MenuUp.performed += instance.OnMenuUp;
                @MenuUp.canceled += instance.OnMenuUp;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface IMainMenuActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMenuDown(InputAction.CallbackContext context);
        void OnMenuUp(InputAction.CallbackContext context);
    }
}
