using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SetBrightness : MonoBehaviour
{
    public Slider brightnessSlider;
    public TMP_Text brightnessSliderText;

    public Volume gammaProcessingVolume;

    public void OnBrightnessSliderValueChanged(float brightnessValue)
    {
        brightnessValue = brightnessSlider.value / 10;
        float brightnessValueClamped = Math.Clamp(brightnessValue, -9, 10);
        double brightnessValueRounded = Math.Round(brightnessValueClamped, 1);
        brightnessSliderText.text = (brightnessValueRounded * 10).ToString();

        LiftGammaGain temp;
        gammaProcessingVolume.profile.TryGet<LiftGammaGain>(out temp);
        temp.gamma.value = new Vector4(0,0,0, brightnessValueClamped);
    }
}
