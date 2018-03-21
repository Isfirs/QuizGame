using UnityEngine;
using UnityEditor;
using QuizGame.ExtensionMethods;

namespace QuizGame.Editor {

    /// <summary>
    /// This class will be used by the Unity Editor to create an instance of the scriptable object.
    /// </summary>
    public class MakeScriptableObject {

        [MenuItem("Assets/Create/QuizGame/Question")]
        public static void CreateMyAsset() {
            QuestionSO asset = ScriptableObject.CreateInstance<QuestionSO>();

            AssetDatabase.CreateAsset(asset, "Assets/QuestionSO.asset");
            AssetDatabase.SetLabels(asset, new string[] { "question" });

            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }

    }

}
