using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        public TextMeshProUGUI display_TextFPS;
        public TextMeshProUGUI display_TextMaxFPS;

        private int MaxFPS = 0;


        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                display_TextFPS.text = string.Format(display, m_CurrentFps);

                if (MaxFPS < m_CurrentFps)
                {
                    MaxFPS = m_CurrentFps;
                    display_TextMaxFPS.text = "MAX " + MaxFPS.ToString() + " FPS";
                }

            }
        }
    }
}
