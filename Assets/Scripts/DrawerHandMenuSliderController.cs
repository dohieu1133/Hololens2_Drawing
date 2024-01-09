using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerHandMenuSliderController : MonoBehaviour
{
    public void ApplySliderChange(DrawerHandMenuSlider slider)
    {
        var drawing = DrawerScript.instance;
        var drawingColor = drawing.drawingColor;
        var maxValueChange = slider.MRTKPinchSliderElement.parameterValues.maxValue - slider.MRTKPinchSliderElement.parameterValues.minValue;
        
        var colorOperationEnum = slider.MRTKPinchSliderElement.colorOperationEnum;
        if (colorOperationEnum == DrawerHandMenuSlider.colorEnum.red)
        {
            drawing.drawingColor = new Color(ApplyNewValues(slider) / maxValueChange, drawingColor.g / maxValueChange, drawingColor.b / maxValueChange);
        }
        else if (colorOperationEnum == DrawerHandMenuSlider.colorEnum.green)
        {
            drawing.drawingColor = new Color(drawingColor.r / maxValueChange, ApplyNewValues(slider) / maxValueChange, drawingColor.b / maxValueChange);
        }
        else if (colorOperationEnum == DrawerHandMenuSlider.colorEnum.blue)
        {
            drawing.drawingColor = new Color(drawingColor.r / maxValueChange, drawingColor.g / maxValueChange, ApplyNewValues(slider) / maxValueChange);
        }
        else if (colorOperationEnum == DrawerHandMenuSlider.colorEnum.startWidth)
        {
            drawing.startWidth = ApplyNewValues(slider);
        }
        else if (colorOperationEnum == DrawerHandMenuSlider.colorEnum.endWidth)
        {
            drawing.endWidth = ApplyNewValues(slider);
        }

        DrawerScript.instance.resultColorMesh.material.color = DrawerScript.instance.drawingColor;
    }

    public float ApplyNewValues(DrawerHandMenuSlider slider)
    {
        var parameter = slider.MRTKPinchSliderElement.parameterValues;
        parameter.actualValue = parameter.minValue + (slider.MRTKPinchSliderElement.slider.SliderValue * (parameter.maxValue - parameter.minValue));

        var actualValue = parameter.actualValue;
        return actualValue;
    }
}
