using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System;

public class DrawerHandMenuSlider : MonoBehaviour
{
    public enum colorEnum
    {
        red,green,blue,startWidth,endWidth
    }

    [Serializable]
    public class MRTKPinchSlider
    {
        public colorEnum colorOperationEnum;
        public PinchSlider slider;
        public ParameterValues parameterValues; 
    }

    [Serializable]
    public class ParameterValues
    {
        public float minValue;
        public float maxValue;
        public float actualValue;
    }

    public MRTKPinchSlider MRTKPinchSliderElement;

    public void Start()
    {
        var values = MRTKPinchSliderElement.parameterValues;
        var drawingColor = DrawerScript.instance;

        var colorOperationEnum = MRTKPinchSliderElement.colorOperationEnum;

        if (colorOperationEnum == colorEnum.red)
        {
            values.actualValue = drawingColor.drawingColor.r;
        }
        else if (colorOperationEnum == colorEnum.green)
        {
            values.actualValue = drawingColor.drawingColor.g;
        }
        else if (colorOperationEnum == colorEnum.blue)
        {
            values.actualValue = drawingColor.drawingColor.b;
        }
        else if (colorOperationEnum == colorEnum.startWidth)
        {
            values.actualValue = drawingColor.startWidth;
        }
        else if (colorOperationEnum == colorEnum.endWidth)
        {
            values.actualValue = drawingColor.endWidth;
        }

        MRTKPinchSliderElement.slider.SliderValue = (values.actualValue - values.minValue) / (values.maxValue - values.minValue);
    }
}
