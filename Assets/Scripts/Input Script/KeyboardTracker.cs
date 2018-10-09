using System.Collections;
using UnityEngine;

public class KeyboardTracker : DeviceTracker {

    public KeyCode[] buttonKeys;
    public AxisKeys[] axisKeys;

    public override void Refresh()
    {
        im = GetComponent<InputManager>();

        //create two temp arrays for buttons and axes
        KeyCode[] newButtons = new KeyCode[im.buttonCount];
        AxisKeys[] newAxis = new AxisKeys[im.axisCount];

        if(buttonKeys != null)
        {
            for (int i = 0; i < Mathf.Min(newButtons.Length,buttonKeys.Length); i++)
            {
                newButtons[i] = buttonKeys[i];
            }
        }
        buttonKeys = newButtons;

        if (axisKeys != null)
        {
            for (int i = 0; i < Mathf.Min(newAxis.Length, axisKeys.Length); i++)
            {
                newAxis[i] = axisKeys[i];
            }
        }
        axisKeys = newAxis;
    }

    private void Reset()
    {
        im = GetComponent<InputManager>();
        axisKeys = new AxisKeys[im.axisCount];
        buttonKeys = new KeyCode[im.buttonCount];
    }
    // Update is called once per frame
    void Update () {
        //check for inputs, if inputs are detected, set newData to true
        //Populate input data to pass to the InputManager
        for (int i = 0; i < axisKeys.Length; i++)
        {
            float val = 0;

            if (Input.GetKey(axisKeys[i].positive))
            {
                val += 1f;
                newData = true;
            }
            if (Input.GetKey(axisKeys[i].negative))
            {
                val -= 1f;
                newData = true;
            }
            data.axes[i] = val;
        }
        for (int i = 0; i < buttonKeys.Length; i++)
        {
            if(Input.GetKey(buttonKeys[i]))
            {
                data.buttons[i] = true;
                newData = true;
            }
        }

        if(newData)
        {
            im.PassInput(data);
            newData = false;
            data.Reset();
            
        }
	}
}

[System.Serializable]
public struct AxisKeys
{
    public KeyCode positive;
    public KeyCode negative;
}