#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseMineSettings))]
public class BaseMineSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BaseMineSettings mineSettings = (BaseMineSettings)target;
        //int _tunnelCount = EditorGUILayout.IntSlider("_Max Tunnel Level", mineSettings._tunnelCount, 1, 20);
        if (GUI.changed)
        {
            if(mineSettings._tunnelCount > 200)
                mineSettings._tunnelCount = 200;

            if (mineSettings.tunnels.Count < mineSettings._tunnelCount)
            {
                int addCount = mineSettings._tunnelCount - mineSettings.tunnels.Count;
                for (int i = 0; i < addCount; i++)
                {
                    mineSettings.tunnels.Add(new TunnelSetting());
                }
            }
            else if(mineSettings.tunnels.Count > mineSettings._tunnelCount)
            {
                int subCount = mineSettings.tunnels.Count - mineSettings._tunnelCount;
                for (int i = 0; i < subCount; i++)
                {
                    mineSettings.tunnels.Remove(mineSettings.tunnels[mineSettings.tunnels.Count - 1]);
                }
            }

            for (int i = 0; i < mineSettings.tunnels.Count; i++)
            {
                if (mineSettings.tunnels[i].levelSettings.Count < mineSettings.tunnels[i]._maxTunnelLevel)
                {
                    int addCount = mineSettings.tunnels[i]._maxTunnelLevel - mineSettings.tunnels[i].levelSettings.Count;
                    for (int j = 0; j < addCount; j++)
                    {
                        mineSettings.tunnels[i].levelSettings.Add(new TunnelLevelSettings());
                    }
                }
                else if (mineSettings.tunnels[i].levelSettings.Count > mineSettings.tunnels[i]._maxTunnelLevel)
                {
                    int subCount = mineSettings.tunnels[i].levelSettings.Count - mineSettings.tunnels[i]._maxTunnelLevel;
                    for (int j = 0; j < subCount; j++)
                    {
                        mineSettings.tunnels[i].levelSettings.Remove(mineSettings.tunnels[i].levelSettings[mineSettings.tunnels[i].levelSettings.Count - 1]);
                    }
                }
            }
            EditorUtility.SetDirty(mineSettings);
        }
    }
}
#endif