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

        [MenuItem("Example/FindAssets Example")]
        static void Test() {
            Debug.Log("Testing");

            string[] guids = AssetDatabase.FindAssets("l:question");

            foreach (string guid in guids) {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                Debug.Log(path);

                //

                Debug.Log("Creating instance");

                QuestionSO q = (QuestionSO) AssetDatabase.LoadAssetAtPath(path, typeof(QuestionSO));

                Debug.Log("Logging instance");

                q.Log();

            }
        }

    }

}
