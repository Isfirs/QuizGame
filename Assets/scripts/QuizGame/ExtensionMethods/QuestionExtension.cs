using UnityEngine;
using QuizGame;

namespace QuizGame.ExtensionMethods {

    public static class QuestionExtension {

        public static void Log(this QuestionSO question) {

            Debug.Log("Question: " + question.Question);

            //

            Debug.Log("Answer A: "+ question.AnswerA);
            Debug.Log("Answer B: " + question.AnswerB);
            Debug.Log("Answer C: " + question.AnswerC);
            Debug.Log("Answer D: " + question.AnswerD);

        }
        
    }

}
