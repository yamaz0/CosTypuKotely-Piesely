// Copyright (c) 2022 Jonathan Lang (CC BY-NC-SA 4.0)
using System;
using System.Text;
using UnityEngine;

namespace Baracuda.Monitoring.Example.Scripts.Persistent
{
    public class FPSMonitor : MonitoredSingleton<FPSMonitor>
    {
        /*
         *  Fields   
         */
        
        public const float MEASURE_PERIOD = 0.25f;
        private const string COLOR_MIN_MARKUP = "<color=#07fc03>";
        private const string COLOR_MID_MARKUP = "<color=#fcba03>";
        private const string C_MAX = "<color=#07fc03>";
        private const int THRESHOLD_ONE = 30;
        private const int THRESHOLD_TWO = 60;
        
        private static float timer = 0;
        private static int lastFPS;
        private static float lastMeasuredFps = 0;
        private static int frameCount = 0;

        private static readonly StringBuilder stringBuilder = new StringBuilder();

        /*
         *  FPS Monitor   
         */
        
        [MonitorValue(UpdateEvent = nameof(FPSUpdated))]
        [ValueProcessor(nameof(FPSProcessor))]
        [Format(FontSize = 32, Position = UIPosition.TopRight, GroupElement = false)]
        private static float fps;

        [MonitorValue(Update = UpdateOptions.TickUpdate)]
        private static long totalFrameCount = 0;
        
        [MonitorValue(Update = UpdateOptions.TickUpdate)]
        private static long fixedUpdateCount = 0;

        /*
         *  Events   
         */

        public static event Action<float> FPSUpdated;
        
        //--------------------------------------------------------------------------------------------------------------
        
        public static string FPSProcessor(float value)
        {
            stringBuilder.Clear();
            stringBuilder.Append('[');
            stringBuilder.Append(value >= THRESHOLD_TWO ? C_MAX : value >= THRESHOLD_ONE ? COLOR_MID_MARKUP : COLOR_MIN_MARKUP);
            stringBuilder.Append(value.ToString("00.00"));
            stringBuilder.Append("</color>]");
            return stringBuilder.ToString();
        }

        private void Start()
        {
            gameObject.hideFlags |= HideFlags.HideInHierarchy;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void InitializeOnLoad()
        {
            Promise();
        }
        
        private void Update()
        {
            frameCount++;
            totalFrameCount++;
            timer += Time.deltaTime / Time.timeScale;

            if (timer < MEASURE_PERIOD)
            {
                return;
            }

            lastMeasuredFps = (frameCount / timer);

            if (Math.Abs(lastMeasuredFps - lastFPS) > .1f)
            {
                fps = lastMeasuredFps;
                FPSUpdated?.Invoke(fps);
            }
                

            lastFPS = frameCount;
            frameCount = 0;

            var rest = MEASURE_PERIOD - timer;
            timer = rest;
        }

        private void FixedUpdate()
        {
            fixedUpdateCount++;
        }

        /*
         *  Setup   
         */
    }
}