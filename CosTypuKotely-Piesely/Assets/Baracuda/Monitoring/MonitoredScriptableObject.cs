// Copyright (c) 2022 Jonathan Lang (CC BY-NC-SA 4.0)
using Baracuda.Monitoring.API;
using UnityEngine;

namespace Baracuda.Monitoring
{
    public class MonitoredScriptableObject : ScriptableObject
    {
        protected virtual void OnEnable()
        {
            MonitoringManager.RegisterTarget(this);
        }

        protected virtual void OnDisable()
        {
            MonitoringManager.UnregisterTarget(this);
        }
    }
}
