using UnityEngine;
using UnityEngine.SceneManagement;

namespace GAD210.P2.Iteration1.SceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        #region Variables

        private float _elapsedTime = 0;

        [SerializeField] private TimeBeforeStarting _timeBeforeStarting; 

        #endregion

        #region Methods

        public void LoadScene(int indexOfScene)
        {
            SceneManager.LoadScene(indexOfScene);
        }

        public void SetTimeBeforeStarting()
        {
            _timeBeforeStarting.ElapsedTime = _elapsedTime;
        }

        private void UpdateTimeBeforeStartingCount()
        {
            _elapsedTime += Time.deltaTime;
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            UpdateTimeBeforeStartingCount();
        }

        #endregion
    }
}