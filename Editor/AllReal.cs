using UnityEditor;
using UnityEngine;

namespace AllReal
{
    [InitializeOnLoad]
    public static class ChangeSettings
    {
        static ChangeSettings()
        {
            EditorApplication.update += OnEditorUpdate;
        }

        private static void OnEditorUpdate()
        {
            // Ensure this runs only once
            EditorApplication.update -= OnEditorUpdate;

            // Set the default company name
            SetCompanyName("AllReal");

            // Set the default build platform
            //SetBuildPlatform(BuildTarget.StandaloneWindows64);
        }

        private static void SetCompanyName(string companyName)
        {
            if (PlayerSettings.companyName != companyName)
            {
                PlayerSettings.companyName = companyName;
                Debug.Log("Company name set to: " + companyName);
            }
        }

        private static void SetBuildPlatform(BuildTarget target)
        {
            if (EditorUserBuildSettings.activeBuildTarget != target)
            {
                EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, target);
                Debug.Log("Build platform set to: " + target.ToString());
            }
        }
    }
}
