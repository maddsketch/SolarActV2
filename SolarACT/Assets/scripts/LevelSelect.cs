using UnityEngine;

namespace FireGrid
{
    public class LevelSelect : MonoBehaviour
    {
        [System.Serializable]
        public struct ButtonPlayerPrefs
        {
            public GameObject gameObject;
            public string playerPrefKey;
        };

        public ButtonPlayerPrefs[] buttons;

        private void Start()
        {            //This shows the amount of stars saved in PlayerPrefs before level begins

            //for (int i = 0; i < buttons.Length; i++)
            //{
            //    int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);

            //    for (int starIndex = 1; starIndex <= 3; starIndex++)
            //    {
            //        Transform star = buttons[i].gameObject.transform.Find($"star{starIndex}");
            //        star.gameObject.SetActive(starIndex <= score);                
            //    }
            //}
        }

        public void OnButtonPress(string levelName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        }
    }
}
