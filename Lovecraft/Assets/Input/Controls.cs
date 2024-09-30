//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""GlobalMap"",
            ""id"": ""7a05da98-f8c3-4317-a920-34e13aab828d"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""61814c93-c526-4be6-b5c0-df4469a1fd5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ad25243-23c0-473d-97ec-1ee073b583a9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GlobalMap
        m_GlobalMap = asset.FindActionMap("GlobalMap", throwIfNotFound: true);
        m_GlobalMap_Newaction = m_GlobalMap.FindAction("New action", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GlobalMap
    private readonly InputActionMap m_GlobalMap;
    private List<IGlobalMapActions> m_GlobalMapActionsCallbackInterfaces = new List<IGlobalMapActions>();
    private readonly InputAction m_GlobalMap_Newaction;
    public struct GlobalMapActions
    {
        private @Controls m_Wrapper;
        public GlobalMapActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_GlobalMap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_GlobalMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalMapActions set) { return set.Get(); }
        public void AddCallbacks(IGlobalMapActions instance)
        {
            if (instance == null || m_Wrapper.m_GlobalMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GlobalMapActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IGlobalMapActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IGlobalMapActions instance)
        {
            if (m_Wrapper.m_GlobalMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGlobalMapActions instance)
        {
            foreach (var item in m_Wrapper.m_GlobalMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GlobalMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GlobalMapActions @GlobalMap => new GlobalMapActions(this);
    public interface IGlobalMapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
