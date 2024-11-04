using UnityEngine;

namespace _ProjectFiles.Core.UI
{
    public class GuideHolder : MonoBehaviour
    {
        [SerializeField] private GameObject[] guideSteps;
        private int _currentIndex;
        private void Start()
        {
            

            _currentIndex = 0;
            foreach (var step in guideSteps)
            {
                step.SetActive(false);
            }
            guideSteps[_currentIndex].SetActive(true);
        }

        public void ShowNextStep()
        {
            guideSteps[_currentIndex].SetActive(false);
            _currentIndex++;
            if (_currentIndex == guideSteps.Length)
            {
                gameObject.SetActive(false);
                return;
            }
        
            guideSteps[_currentIndex].SetActive(true);
        }
    }
}
