using UnityEngine;
using UnityEngine.UI;

public class JoystickMappingListener : MonoBehaviour
{
    private Text _outputMessage;

    private string[] _joysticks;
    private AvatarController[] _avatarControllers;

    private void Start()
    {
        _outputMessage = FindObjectOfType<Text>();

        _joysticks = new string[0];

        _avatarControllers = FindObjectsOfType<AvatarController>();
        for (int i=0; i<_avatarControllers.Length; i++)
        {
            _avatarControllers[i].AxisIndex = -1;
            SetMessage("Registering " + _avatarControllers[i].name + " as  avatar " + i);
        }

        string startState = "Active sticks at startup: ";
        string[] sticks = Input.GetJoystickNames();
        for (int i=0; i < sticks.Length; i++)
        {
            if (!string.IsNullOrEmpty(sticks[i]))
            {
                startState += i + ", ";
            }
        }

        SetMessage(startState + " (" + sticks.Length + " sticks listed)");
    }

    private void Update()
    {
        UpdateStickStates();
    }

    private void UpdateStickStates()
    {
        string[] updatedJoysticks = Input.GetJoystickNames();
        for (int i = 0; i < Mathf.Max(_joysticks.Length, updatedJoysticks.Length); i++)
        {
            if (i >= _joysticks.Length)
            {
                if ((i < updatedJoysticks.Length) && (!string.IsNullOrEmpty(updatedJoysticks[i])))
                {
                    ActivateJoystick(i);
                }
            }
            else if (i >= updatedJoysticks.Length)
            {
                DeactivateJoystick(i);
            }
            else
            {
                if ((!string.IsNullOrEmpty(_joysticks[i])) && (string.IsNullOrEmpty(updatedJoysticks[i])))
                {
                    DeactivateJoystick(i);
                }

                if ((string.IsNullOrEmpty(_joysticks[i])) && (!string.IsNullOrEmpty(updatedJoysticks[i])))
                {
                    ActivateJoystick(i);
                }
            }
        }

        _joysticks = updatedJoysticks;
    }

    private void ActivateJoystick(int stickIndex)
    {
        for (int i=0; i < _avatarControllers.Length; i++)
        {
            if (_avatarControllers[i].AxisIndex < 0)
            {
                _avatarControllers[i].AxisIndex = stickIndex;
                SetMessage("Joystick " + stickIndex + " assigned to " + _avatarControllers[i].name);
                break;
            }
        }
    }

    private void DeactivateJoystick(int stickIndex)
    {
        for (int i = 0; i < _avatarControllers.Length; i++)
        {
            if (_avatarControllers[i].AxisIndex == stickIndex)
            {
                _avatarControllers[i].AxisIndex = -1;
                SetMessage("Joystick " + stickIndex + " disconnected from " + _avatarControllers[i].name);
                break;
            }
        }
    }

    private void SetMessage(string message)
    {
        _outputMessage.text = message;
        Debug.Log(message);
    }
}
