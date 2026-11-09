#if IMPLEMENTED_EYETRACKING
using OmiLAXR;
using OmiLAXR.Composers;
using OmiLAXR.xAPI.Composers;

/// <summary>
/// Creates xAPI statements from <see cref="EyeTrackingBehaviour"/> events: the actor fixated, unfixated or focused
/// an eye tracking target, with the target's name. Only compiled with the scripting define <c>IMPLEMENTED_EYETRACKING</c>.
/// </summary>
public class EyeTrackingStatementComposer : xApiComposer<EyeTrackingBehaviour>
{
    public override Author GetAuthor()
        => new Author("Felix Meinhardt", "felix.meinhardt@rwth-aachen.de");

    protected override void Compose(EyeTrackingBehaviour tb)
    {
        //For EyeTrackingTarget
        
        tb.eyeTrackingTargetOnLookAtStart.AddHandler((_, target) =>
        {
            var targetName = target.gameObject.GetTrackingName();
                
            var stmt = actor.Does(xapi.eyeTracking.verbs.fixated)
                .WithExtension(xapi.virtualReality.extensions.activity
                    .vrObjectName(targetName))
                .Activity(xapi.eyeTracking.activities.eye);
            SendStatement(stmt);
        });
        
        tb.eyeTrackingTargetOnLookAway.AddHandler((_, target) =>
        {
            var targetName = target.gameObject.GetTrackingName();
                
            var stmt = actor.Does(xapi.eyeTracking.verbs.unfixated)
                .WithExtension(xapi.virtualReality.extensions.activity
                    .vrObjectName(targetName))
                .Activity(xapi.eyeTracking.activities.eye);
            SendStatement(stmt);
        });
        
        tb.eyeTrackingTargetOnDwell.AddHandler((_, target) =>
        {
            var targetName = target.gameObject.GetTrackingName();
                
            var stmt = actor.Does(xapi.eyeTracking.verbs.focused)
                .WithExtension(xapi.virtualReality.extensions.activity
                    .vrObjectName(targetName))
                .Activity(xapi.eyeTracking.activities.eye);
            SendStatement(stmt);
        });
        
        
        //For GazeDetection
        tb.gazeDetectionOnLookAtStart.AddHandler((_, _, target) =>
        {
            var targetName = target.GetTrackingName();
                
            var stmt = actor.Does(xapi.eyeTracking.verbs.fixated)
                .WithExtension(xapi.virtualReality.extensions.activity
                    .vrObjectName(targetName))
                .Activity(xapi.eyeTracking.activities.eye);
            SendStatement(stmt);
        });
        
        tb.gazeDetectionOnLookAtEnd.AddHandler((_, _, target) =>
        {
            var targetName = target.GetTrackingName();
                
            var stmt = actor.Does(xapi.eyeTracking.verbs.unfixated)
                .WithExtension(xapi.virtualReality.extensions.activity
                    .vrObjectName(targetName))
                .Activity(xapi.eyeTracking.activities.eye);
            SendStatement(stmt);
        });
        
        tb.gazeDetectionOnDwell.AddHandler((_, _, target) =>
        {
            var targetName = target.GetTrackingName();
                
            var stmt = actor.Does(xapi.eyeTracking.verbs.focused)
                .WithExtension(xapi.virtualReality.extensions.activity
                    .vrObjectName(targetName))
                .Activity(xapi.eyeTracking.activities.eye);
            SendStatement(stmt);
        });
    }
}
#endif