#if IMPLEMENTED_EYETRACKING
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmilLAXR.Listeners
{
    /// <summary>
    /// Finds every MRTK2 <c>EyeTrackingTarget</c> in the scene and hands them to the pipeline.
    /// Only compiled with the scripting define <c>IMPLEMENTED_EYETRACKING</c>.
    /// </summary>
    [AddComponentMenu("OmiLAXR / 1) Listeners / <EyeTrackingTarget> Eye Tracking Target Listener")]
    public class EyeTrackingTargetListener : Listener
    {
        [Tooltip("Also find EyeTrackingTarget components on inactive game objects.")]
        public bool includeInactive = true;
    
        public override void StartListening()
        {
            var selectables = FindObjectsOfType<EyeTrackingTarget>(includeInactive);
            Found(selectables);
        
        }
    }
}
#endif