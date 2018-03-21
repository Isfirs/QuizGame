using UnityEngine;

namespace QuizGame.ExtensionMethods {

    public static class QuestionExtension {

        public static void Log(this Question question) {

            Debug.Log("Question: " + question.QuestionText);

            //

        }
        
    }

}
