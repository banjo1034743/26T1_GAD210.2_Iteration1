using UnityEngine;
using TMPro;

public class PackageDataGrabber : MonoBehaviour
{
    #region Variables

    //private SearchRequest wantedPackage; // The pacakge we;re searching for after the player adds in the name

    //private PackageInfo currentPackage;

    //private bool _searchForPackage;

    private bool _hasGrabbedPackageData = false;

    [Header("Components")]

    [SerializeField] private TMP_InputField inputField;

    [Header("Scripts")]

    [SerializeField] private CreatureGenerator creatureGenerator;

    #endregion

    #region Methods

    //public void GetPackageURL(string packageURL)
    //{
    //    if (string.IsNullOrEmpty(packageURL) == false)
    //    {
    //        wantedPackage = Client.Search(packageURL);
    //        Debug.Log("String is not empty");

    //        _searchForPackage = true;
    //    }
    //}

    public void GetPackage(string packageName)
    {
        switch (packageName)
        {
            case "com.unity.2d.animation":
                creatureGenerator.CollectPackageData("Unity Technologies", "2D Animation", 2025);
                _hasGrabbedPackageData = true;
                break;
            case "2D Animation":
                _hasGrabbedPackageData = true;
                break;
            case "com.unity.services.analytics":
                creatureGenerator.CollectPackageData("Unity Technologies", "Analytics", 2026);
                _hasGrabbedPackageData = true;
                break;
            case "Analytics":
                break;
            case "com.unity.inputsystem":
                creatureGenerator.CollectPackageData("Unity Technologies", "Input System", 2025);
                _hasGrabbedPackageData = true;
                break;
            case "Input System":
                _hasGrabbedPackageData = true;
                break;
            default:
                Debug.Log("This package is not recognised by the prototype. Ensure it has been spelt correctly and are under the 'Released packages' section in the documentation");
                inputField.text = "This package is not recognised by the prototype. Ensure it has been spelt correctly and are under the 'Released packages' section in the documentation";
                break;
        }

        if (_hasGrabbedPackageData == true)
        {
            GameManager.instance.IsOnPackageNameScreen = false; // Tells GameManager to switch screens
            _hasGrabbedPackageData = false;
        }
    }

    //private void SearchForPackage()
    //{
    //    if (_searchForPackage == true)
    //    {
    //        if (wantedPackage.IsCompleted)
    //        {
    //            PackageInfo[] retrievedPackages;
    //            retrievedPackages = wantedPackage.Result;
    //            currentPackage = retrievedPackages[0];
    //            creatureGenerator.CollectPackageData(currentPackage);

    //            GameManager.instance.IsOnPackageNameScreen = false; // Tells GameManager to switch screens
    //            _searchForPackage = false;
    //        }
    //    }
    //}

    //private void InitialisrVariables()
    //{
    //    wantedPackage = null;
    //    currentPackage = null;
    //}

    #endregion

    #region Unity Methods

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InitialisrVariables();
    }

    // //Update is called once per frame
    void Update()
    {
        //SearchForPackage(); // Only called after the player presses enter in input field
    }

    #endregion
}
