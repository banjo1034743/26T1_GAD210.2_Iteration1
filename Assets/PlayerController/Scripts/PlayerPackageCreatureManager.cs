using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAD210.P2.Iteration1
{
    public class PlayerPackageCreatureManager : MonoBehaviour
    {
        #region Variables

        [Header("UI")]

        [Space(5)]

        [SerializeField] private Image _packageCreatureIcon;

        [Header("Package Creatures")]

        [Space(5)]

        private PackageCreature _currentPackageCreature;

        //[SerializeField] private List<PackageCreature> _packageCreatureList = new List<PackageCreature>();

        #endregion

        #region Methods

        public void SetPackageCreatureAsPlayers(PackageCreature packageCreature)
        {
            _packageCreatureIcon.sprite = packageCreature.PackageCreatureDisplayImage;
            _currentPackageCreature = packageCreature;
        }

        private void InitialiseVariables()
        {
            _packageCreatureIcon.sprite = null;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitialiseVariables();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion
    }
}