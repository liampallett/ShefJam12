using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class pastShaderEffect : MonoBehaviour
{
    public bool isInPast;
    public Image screenOverlay;
    public Volume globalVolume;
    private ChromaticAberration _chromatic;
    private LensDistortion _lens;
    private Color presentColor = new Color(0.5f, 0.5f, 0.5f, 0f);
    private Color pastColor = new Color(0.22f, 0.65f, 0.77f, 0.25f);

    void Start()
    {
        globalVolume.profile.TryGet<ChromaticAberration>(out _chromatic);
        globalVolume.profile.TryGet<LensDistortion>(out _lens);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInPast)
        {
            float shimmer = Mathf.Sin(Time.time * 2f) * 0.075f;
            _lens.intensity.value = shimmer - 0.2f;
            screenOverlay.color = pastColor;
            _chromatic.intensity.value = 1.0f;
        }

        else
        {
            screenOverlay.color = presentColor;
            _chromatic.intensity.value = 0f;
        }
    }

}
