using System;
using System.Collections.Generic;

namespace ApplicationFramework.Telemetry
{
    /// <summary>
    /// Defines the contract for tracking telemetry
    /// </summary>
    public interface ITelemetry
    {
        void TrackDependency(string dependencyName, TimeSpan duration, string resultCode, bool success, IDictionary<string, string> properties = null);

        void TrackException(Exception exception, IDictionary<string, string> properties = null);

        void TrackMetric(string name, double value, IDictionary<string, string> properties = null);

        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        void TrackAvailability(string name, DateTimeOffset timeStamp, TimeSpan duration, string runLocation, bool success, string message = null, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);
    }
}
