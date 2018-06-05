using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;

namespace ApplicationFramework.Telemetry
{
    public class ApplicationInsightsClient : ITelemetry
    {
        private readonly TelemetryClient client;

        public ApplicationInsightsClient()
        {
            client = new TelemetryClient()
            {
                InstrumentationKey = Config.ApplicationInsightsInstrumentionKey
            };
        }

        public void TrackDependency(string dependencyName, TimeSpan duration, string resultCode, bool success, IDictionary<string, string> properties = null)
        {
            var dependencyTelemetry = new DependencyTelemetry()
            {
                Name = dependencyName,
                Duration = duration,
                ResultCode = resultCode,
                Success = success,
            };

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    dependencyTelemetry.Context.Properties.Add(property.Key, property.Value);
                }
            }

            client.TrackDependency(dependencyTelemetry);
        }

        public void TrackException(Exception exception, IDictionary<string, string> properties = null)
        {
            client.TrackException(exception, properties);
        }

        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            client.TrackMetric(name, value, properties);
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            client.TrackEvent(eventName, properties, metrics);
        }

        public void TrackAvailability(string name, DateTimeOffset timeStamp, TimeSpan duration, string runLocation, bool success, string message = null, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            client.TrackAvailability(name, timeStamp, duration, runLocation, success, message, properties);
        }
    }
}
