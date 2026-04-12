using GAD210.P2.Iteration1.Player;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1.Microgame
{
    public class JawsOfLifeManager : MicrogameManager
    {
        #region Variables

        [Header("Microgame UI")]

        [Space(5)]
        
        [SerializeField] private Slider _jawsOfLifeSlider;

        [SerializeField] private Button _jawsOfLifeButton;

        [SerializeField] private float _sliderStartingValue;

        [SerializeField] private float _sliderIncreaseAmount;

        [SerializeField] private float _sliderDecreaseSpeed;

        #endregion

        #region Methods

        public void IncreaseSliderValue()
        {
            _jawsOfLifeSlider.value += _sliderIncreaseAmount;
        }

        private void DecreaseSliderValue()
        {
            if (_jawsOfLifeSlider.value > 0)
            {
                _jawsOfLifeSlider.value = Mathf.Lerp(_jawsOfLifeSlider.value, 0, _sliderDecreaseSpeed);
            }
        }

        private void InitializeMicrogame()
        {
            PlayerFreezer.instance.CantMove = true;

            PlayerFreezer.instance.CantInteract = true;

            _jawsOfLifeSlider.value = _sliderStartingValue;

            _jawsOfLifeButton.Select();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeMicrogame();
        }

        protected override void Update()
        {
            DecreaseSliderValue();
        }

        #endregion
    }
}