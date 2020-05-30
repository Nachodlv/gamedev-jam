// GENERATED AUTOMATICALLY FROM 'Assets/Gamedev jam.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public class @InputActionController : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActionController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Gamedev jam"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""95906fec-1071-42b7-90b1-ef9bf3f38cb1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4179e3fc-ffbe-44fb-a05b-4a2451aaa246"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""733945dc-6e74-43c4-b1e7-13215d5d54e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""51b47bd0-041a-47be-9d93-6bebcd76dff1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b2942d07-d95c-43d2-a768-cd3ace6fa164"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""9f4227f5-9fe6-464e-a6c5-05372cb9258e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TimeStop"",
                    ""type"": ""Button"",
                    ""id"": ""0cd27f93-0082-4cf8-84c6-52dc63f4f990"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""31a0b820-15fb-479c-a81c-0b4b441d4d70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""43916536-0a14-4adf-b474-2808f5713398"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b32dcba4-9ffe-4658-9fd4-42fad45408ad"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5be2c90f-70f6-456b-bcef-86926e6ad0d5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""cb120461-87a7-45b5-a462-69b4a12f642b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d6793696-7a16-4d87-8794-6f030459a42d"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c0acef29-6127-4d1e-a556-d9c93d3f36bf"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WD [Keyboard]"",
                    ""id"": ""d0e1782b-b307-4419-9887-7ed174873122"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""46f8462c-96c2-4604-903d-592a2b7b0b40"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0f76c945-4e1c-411b-b5db-9e51e7ca9f8c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows [Keyboard]"",
                    ""id"": ""ccf490bf-c6ec-475f-9fe9-2b4d2614c096"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6857bb9b-9308-4c23-9084-2dac29458c52"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""008c5663-df1f-4a89-b63e-e0fcc51c7a88"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c1f7a91b-d0fd-4a62-997e-7fb9b69bf235"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c8e490b-c610-4785-884f-f04217b23ca4"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e5f5442-8668-4b27-a940-df99bad7e831"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143bb1cd-cc10-4eca-a2f0-a3664166fe91"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05f6913d-c316-48b2-a6bb-e225f14c7960"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""886e731e-7071-4ae4-95c0-e61739dad6fd"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Touch"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee3d0cd2-254e-47a7-a8cb-bc94d9658c54"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8255d333-5683-4943-a58a-ccb207ff1dce"",
                    ""path"": ""<XRController>/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3685476c-da55-46eb-a120-5331b5417246"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28ac43ef-49ac-4a07-afed-1b27a6939037"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""432f2eda-784d-4312-b6aa-fabafd45db07"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b42357c7-da6b-42c8-bcbe-6d11a06afae7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51870c64-dbf1-4e34-a8c5-51ee89ff8f83"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20736279-3bec-4aef-9d4b-3279b05885d5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcf2bd31-7283-45db-bd7c-ea3e36d8a455"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a06ff6-d4eb-4880-9bd2-4711391949e2"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c11fdd02-65de-4468-812c-444b72807c3f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bf9f80d-c202-453d-a687-fa1adff7fe63"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""TimeStop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26d895ff-55a6-4baf-874d-a544683e6381"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""45e2b8af-2136-4e70-a833-b93da2604de4"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""3b652cf9-20d6-4dd8-9719-c621a955861c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""6ccac6a3-1d7d-4859-aa2a-3ad0849bb61e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""4d65eca3-5a5e-4949-b3c4-fce1f13ea0a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a810e16b-5472-42f7-b806-77c014b58bf2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6cc4ef0a-c4bd-4d39-a662-c600501c531f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6da82659-6115-4fb8-ab77-589e5e9b2336"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f7a9f037-2973-4852-9a71-8f265b3f319f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""05e29b73-919c-45e0-a5c2-331c136e204a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3705cc48-93e6-4546-9625-630f93cf889b"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""de2f762f-73f9-4982-b8ea-0a88950fdeae"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""809f371f-c5e2-4e7a-83a1-d867598f40dd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""14a5d6e8-4aaf-4119-a9ef-34b8c2c548bf"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9144cbe6-05e1-4687-a6d7-24f99d23dd81"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2db08d65-c5fb-421b-983f-c71163608d67"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""58748904-2ea9-4a80-8579-b500e6a76df8"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ba04515-75aa-45de-966d-393d9bbd1c14"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""712e721c-bdfb-4b23-a86c-a0d9fcfea921"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcd248ae-a788-4676-a12e-f4d81205600b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f04d9bc-c50b-41a1-bfcc-afb75475ec20"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fb8277d4-c5cd-4663-9dc7-ee3f0b506d90"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""e25d9774-381c-4a61-b47c-7b6b299ad9f9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3db53b26-6601-41be-9887-63ac74e79d19"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cb3e13e-3d90-4178-8ae6-d9c5501d653f"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0392d399-f6dd-4c82-8062-c1e9c0d34835"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""942a66d9-d42f-43d6-8d70-ecb4ba5363bc"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ff527021-f211-4c02-933e-5976594c46ed"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""563fbfdd-0f09-408d-aa75-8642c4f08ef0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eb480147-c587-4a33-85ed-eb0ab9942c43"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2bf42165-60bc-42ca-8072-8c13ab40239b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""85d264ad-e0a0-4565-b7ff-1a37edde51ac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""74214943-c580-44e4-98eb-ad7eebe17902"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cea9b045-a000-445b-95b8-0c171af70a3b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8607c725-d935-4808-84b1-8354e29bab63"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4cda81dc-9edd-4e03-9d7c-a71a14345d0b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9e92bb26-7e3b-4ec4-b06b-3c8f8e498ddc"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82627dcc-3b13-4ba9-841d-e4b746d6553e"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c52c8e0b-8179-41d3-b8a1-d149033bbe86"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1394cbc-336e-44ce-9ea8-6007ed6193f7"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5693e57a-238a-46ed-b5ae-e64e6e574302"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4faf7dc9-b979-4210-aa8c-e808e1ef89f5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d66d5ba-88d7-48e6-b1cd-198bbfef7ace"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47c2a644-3ebc-4dae-a106-589b7ca75b59"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb9e6b34-44bf-4381-ac63-5aa15d19f677"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38c99815-14ea-4617-8627-164d27641299"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24066f69-da47-44f3-a07e-0015fb02eb2e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c191405-5738-4d4b-a523-c6a301dbf754"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7236c0d9-6ca3-47cf-a6ee-a97f5b59ea77"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23e01e3a-f935-4948-8d8b-9bcac77714fb"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Configuration"",
            ""id"": ""6109c0db-81eb-4784-a1dd-cc7ee178a8d4"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""214caca2-83dd-4f3e-951b-82ed81ee2562"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3c6453e5-2363-4cb8-a7c4-95947deeae76"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
            m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
            m_Player_TimeStop = m_Player.FindAction("TimeStop", throwIfNotFound: true);
            m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
            m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
            m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
            m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
            m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
            m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
            m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
            m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
            m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
            m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
            // Configuration
            m_Configuration = asset.FindActionMap("Configuration", throwIfNotFound: true);
            m_Configuration_Pause = m_Configuration.FindAction("Pause", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Attack;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Crouch;
        private readonly InputAction m_Player_TimeStop;
        private readonly InputAction m_Player_Dash;
        public struct PlayerActions
        {
            private @InputActionController m_Wrapper;
            public PlayerActions(@InputActionController wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Look => m_Wrapper.m_Player_Look;
            public InputAction @Attack => m_Wrapper.m_Player_Attack;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
            public InputAction @TimeStop => m_Wrapper.m_Player_TimeStop;
            public InputAction @Dash => m_Wrapper.m_Player_Dash;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                    @TimeStop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTimeStop;
                    @TimeStop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTimeStop;
                    @TimeStop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTimeStop;
                    @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                    @TimeStop.started += instance.OnTimeStop;
                    @TimeStop.performed += instance.OnTimeStop;
                    @TimeStop.canceled += instance.OnTimeStop;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Navigate;
        private readonly InputAction m_UI_Submit;
        private readonly InputAction m_UI_Cancel;
        private readonly InputAction m_UI_Point;
        private readonly InputAction m_UI_Click;
        private readonly InputAction m_UI_ScrollWheel;
        private readonly InputAction m_UI_MiddleClick;
        private readonly InputAction m_UI_RightClick;
        private readonly InputAction m_UI_TrackedDevicePosition;
        private readonly InputAction m_UI_TrackedDeviceOrientation;
        public struct UIActions
        {
            private @InputActionController m_Wrapper;
            public UIActions(@InputActionController wrapper) { m_Wrapper = wrapper; }
            public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
            public InputAction @Submit => m_Wrapper.m_UI_Submit;
            public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
            public InputAction @Point => m_Wrapper.m_UI_Point;
            public InputAction @Click => m_Wrapper.m_UI_Click;
            public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
            public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
            public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
            public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
            public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Navigate.started += instance.OnNavigate;
                    @Navigate.performed += instance.OnNavigate;
                    @Navigate.canceled += instance.OnNavigate;
                    @Submit.started += instance.OnSubmit;
                    @Submit.performed += instance.OnSubmit;
                    @Submit.canceled += instance.OnSubmit;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                    @Point.started += instance.OnPoint;
                    @Point.performed += instance.OnPoint;
                    @Point.canceled += instance.OnPoint;
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                    @ScrollWheel.started += instance.OnScrollWheel;
                    @ScrollWheel.performed += instance.OnScrollWheel;
                    @ScrollWheel.canceled += instance.OnScrollWheel;
                    @MiddleClick.started += instance.OnMiddleClick;
                    @MiddleClick.performed += instance.OnMiddleClick;
                    @MiddleClick.canceled += instance.OnMiddleClick;
                    @RightClick.started += instance.OnRightClick;
                    @RightClick.performed += instance.OnRightClick;
                    @RightClick.canceled += instance.OnRightClick;
                    @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                    @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                    @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                    @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                }
            }
        }
        public UIActions @UI => new UIActions(this);

        // Configuration
        private readonly InputActionMap m_Configuration;
        private IConfigurationActions m_ConfigurationActionsCallbackInterface;
        private readonly InputAction m_Configuration_Pause;
        public struct ConfigurationActions
        {
            private @InputActionController m_Wrapper;
            public ConfigurationActions(@InputActionController wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_Configuration_Pause;
            public InputActionMap Get() { return m_Wrapper.m_Configuration; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ConfigurationActions set) { return set.Get(); }
            public void SetCallbacks(IConfigurationActions instance)
            {
                if (m_Wrapper.m_ConfigurationActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_ConfigurationActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_ConfigurationActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_ConfigurationActionsCallbackInterface.OnPause;
                }
                m_Wrapper.m_ConfigurationActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                }
            }
        }
        public ConfigurationActions @Configuration => new ConfigurationActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_TouchSchemeIndex = -1;
        public InputControlScheme TouchScheme
        {
            get
            {
                if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
                return asset.controlSchemes[m_TouchSchemeIndex];
            }
        }
        private int m_JoystickSchemeIndex = -1;
        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }
        private int m_XRSchemeIndex = -1;
        public InputControlScheme XRScheme
        {
            get
            {
                if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
                return asset.controlSchemes[m_XRSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnTimeStop(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnNavigate(InputAction.CallbackContext context);
            void OnSubmit(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
            void OnPoint(InputAction.CallbackContext context);
            void OnClick(InputAction.CallbackContext context);
            void OnScrollWheel(InputAction.CallbackContext context);
            void OnMiddleClick(InputAction.CallbackContext context);
            void OnRightClick(InputAction.CallbackContext context);
            void OnTrackedDevicePosition(InputAction.CallbackContext context);
            void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        }
        public interface IConfigurationActions
        {
            void OnPause(InputAction.CallbackContext context);
        }
    }
}
