using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatureGenerator : MonoBehaviour
{
    #region Variables

    [Header("Package Data")]

    [SerializeField] private string _authorName;

    //[SerializeField] private string _packageCategory;

    [SerializeField] private int _datePublished;

    [SerializeField] private string _packageDisplayName;

    [Header("Package Data Text Fields")]

    [SerializeField] private TextMeshProUGUI _packageNameTextField;

    [SerializeField] private TextMeshProUGUI _authorNameTextField;

    [SerializeField] private TextMeshProUGUI _publishedDateTextField;

    //[SerializeField] private TextMeshProUGUI _categoryTextField;\

    [Header("Creature Info")]

    [SerializeField] private string _creatureName;

    [SerializeField] private Image _creatureDisplayImage;

    [SerializeField] private GameObject _creatureImageSpace;

    [SerializeField] private Color32 _creatureColor;

    [SerializeField] private List<string> _powerDecriptions = new List<string>();

    [Header("Creature Data Text Fields")]

    [SerializeField] private TextMeshProUGUI _creatureNameTextField;

    [SerializeField] private TextMeshProUGUI _creaturePowerNameTextField;

    [SerializeField] private TextMeshProUGUI _creaturePowerDescTextField;

    [Header("Sprites")]

    [SerializeField] private Sprite _creatureSprite2D;

    [SerializeField] private Sprite _creatureSprite3D;

    #endregion

    #region Methods

    public void CollectPackageData(string authorName, string packageName, int datePublished)
    {
        _authorName = authorName;

        _packageDisplayName = packageName;

        _datePublished = datePublished;

        //_packageCategory = category;

        Debug.Log("Author name = " + _authorName);
        //Debug.Log("Category = " + _packageCategory);
        Debug.Log("Date = " + _datePublished);
        Debug.Log("Name = " + _packageDisplayName);

        DisplayCreatureInfo();
        DisplayPackageData();
    }

    private void DisplayCreatureInfo()
    {
        _creatureColor = GetTintColor();
        SetCreatureAge();

        SetCreatureImage();

        _creatureNameTextField.text = _creatureNameTextField.text + GenerateCreatureName();

        _creaturePowerNameTextField.text = _creaturePowerNameTextField.text + GenerateCreaturePower();
    }

    private void SetCreatureImage()
    {
        // Choose a image to display
        if (_packageDisplayName.Contains("2D") == true)
        {
            _creatureDisplayImage.sprite = _creatureSprite2D;
        }
        else
        {
            _creatureDisplayImage.sprite = _creatureSprite3D;
        }

        _creatureDisplayImage.color = _creatureColor;
    }

    private Color32 GetTintColor()
    {
        // Choose colour to tint image
        int r = 0;
        int g = 0;
        int b = 0;

        List<int> unicodeCharacters = new List<int>();

        foreach (char ch in _packageDisplayName)
        {
            unicodeCharacters.Add((int)ch);
        }

        int evenlySplitValue = unicodeCharacters.Count / 3;
        Debug.Log("amountToDivide = " + evenlySplitValue);

        int amountOfUnicodeValuesToAddTogether = 0;
        Debug.Log("amountOfUnicodeValuesToAddTogether is currently: " + amountOfUnicodeValuesToAddTogether);

        int sumOfAddedUnicodes = 0;
        Debug.Log("sumOfAddedUnicodes is currently: " + sumOfAddedUnicodes);

        foreach (int unicode in unicodeCharacters)
        {
            if (amountOfUnicodeValuesToAddTogether < evenlySplitValue)
            {
                sumOfAddedUnicodes += unicode;
                Debug.Log("sumOfAddedUnicodes is now: " + sumOfAddedUnicodes);

                amountOfUnicodeValuesToAddTogether++;
                Debug.Log("amountOfUnicodeValuesToAddTogether is now: " + amountOfUnicodeValuesToAddTogether);
            }
            else
            {
                if (r == 0)
                {
                    Debug.Log("We've moved to setting the value of R");

                    if (sumOfAddedUnicodes > 255)
                    {
                        sumOfAddedUnicodes = (sumOfAddedUnicodes / evenlySplitValue);
                        Debug.Log("sumOfAddedUnicodes is over 255. We've now divided it and it is now: " + sumOfAddedUnicodes);
                    }

                    r = sumOfAddedUnicodes;
                    Debug.Log("Set the R value. R is now set to value of: " + r);

                    sumOfAddedUnicodes = 0;
                    Debug.Log("sumOfAddedUnicodes has been reset. It is now: " + sumOfAddedUnicodes);

                    amountOfUnicodeValuesToAddTogether = 0;
                    Debug.Log("amountOfUnicodeValuesToAddTogether has been reset. It is now: " + amountOfUnicodeValuesToAddTogether);
                }
                else if (g == 0)
                {
                    Debug.Log("We've moved to setting the value of G");

                    if (sumOfAddedUnicodes > 255)
                    {
                        sumOfAddedUnicodes = (sumOfAddedUnicodes / evenlySplitValue);
                        Debug.Log("sumOfAddedUnicodes is over 255. We've now divided it and it is now: " + sumOfAddedUnicodes);
                    }

                    g = sumOfAddedUnicodes;
                    Debug.Log("Set the G value. G is now set to value of: " + g);

                    sumOfAddedUnicodes = 0;
                    Debug.Log("sumOfAddedUnicodes has been reset. It is now: " + sumOfAddedUnicodes);

                    amountOfUnicodeValuesToAddTogether = 0;
                    Debug.Log("amountOfUnicodeValuesToAddTogether has been reset. It is now: " + amountOfUnicodeValuesToAddTogether);
                }
                else if (b == 0)
                {
                    Debug.Log("We've moved to setting the value of B");

                    if (sumOfAddedUnicodes > 255)
                    {
                        sumOfAddedUnicodes = (sumOfAddedUnicodes / evenlySplitValue);
                        Debug.Log("sumOfAddedUnicodes is over 255. We've now divided it and it is now: " + sumOfAddedUnicodes);
                    }

                    b = sumOfAddedUnicodes;
                    Debug.Log("Set the B value. B is now set to value of: " + b);

                    sumOfAddedUnicodes = 0;
                    Debug.Log("sumOfAddedUnicodes has been reset. It is now: " + sumOfAddedUnicodes);

                    amountOfUnicodeValuesToAddTogether = 0;
                    Debug.Log("amountOfUnicodeValuesToAddTogether has been reset. It is now: " + amountOfUnicodeValuesToAddTogether);
                }
            }
        }

        if (b == 0) // Fail safe for it foreach loop ends before B gets chance to be set
        {
            Debug.Log("Foreach loop eneded. We've activated the failsafe and moved to setting the value of B");

            if (sumOfAddedUnicodes > 255)
            {
                sumOfAddedUnicodes = (sumOfAddedUnicodes / evenlySplitValue);
                Debug.Log("sumOfAddedUnicodes is over 255. We've now divided it and it is now: " + sumOfAddedUnicodes);
            }

            b = sumOfAddedUnicodes;
            Debug.Log("Set the B value. B is now set to value of: " + b);

            sumOfAddedUnicodes = 0;
            Debug.Log("sumOfAddedUnicodes has been reset. It is now: " + sumOfAddedUnicodes);

            amountOfUnicodeValuesToAddTogether = 0;
            Debug.Log("amountOfUnicodeValuesToAddTogether has been reset. It is now: " + amountOfUnicodeValuesToAddTogether);
        }

        return new Color32((byte)r, (byte)g, (byte)b, 255);
    }

    private void SetCreatureAge()
    {
        float amountToScale = 1;

        switch (_datePublished)
        {
            case 2026:

                break;
        }

        for (int i = 2021; i < _datePublished; i++)
        {
            amountToScale -= 0.1f;
        }

        _creatureImageSpace.transform.localScale = new Vector2(amountToScale, amountToScale);
    }

    private string GenerateCreatureName()
    {
        // More code treason

        if (_packageDisplayName.IndexOf("An", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Anundere"; 
        }
        else if (_packageDisplayName.IndexOf("Ba", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Balcolhee";
        }
        else if (_packageDisplayName.IndexOf("Ca", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Catlavee";
        }
        else if (_packageDisplayName.IndexOf("Di", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Di Ze";
        }
        else if (_packageDisplayName.IndexOf("Ed", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Edward";
        }
        else if (_packageDisplayName.IndexOf("Fr", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Frank";
        }
        else if (_packageDisplayName.IndexOf("Gr", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Gronoyip";
        }
        else if (_packageDisplayName.IndexOf("He", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Hecatia";
        }
        else if (_packageDisplayName.IndexOf("Ir", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Irwin";
        }
        else if (_packageDisplayName.IndexOf("Jo", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Jormuizotl";
        }
        else if (_packageDisplayName.IndexOf("Ka", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Karootz";
        }
        else if (_packageDisplayName.IndexOf("Le", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Leshee";
        }
        else if (_packageDisplayName.IndexOf("Mi", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Mihulu";
        }
        else if (_packageDisplayName.IndexOf("Na", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Nandratl";
        }
        else if (_packageDisplayName.IndexOf("On", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Oniffinx";
        }
        else if (_packageDisplayName.IndexOf("Pe", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Peter Griffin";
        }
        else if (_packageDisplayName.IndexOf("Qi", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Qilpie";
        }
        else if (_packageDisplayName.IndexOf("Ra", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Raquetze";
        }
        else if (_packageDisplayName.IndexOf("Sp", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Sphimayune";
        }
        else if (_packageDisplayName.IndexOf("Ti", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Tikielpi";
        }
        else if (_packageDisplayName.IndexOf("Ur", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Uranus";
        }
        else if (_packageDisplayName.IndexOf("Vi", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Vivian";
        }
        else if (_packageDisplayName.IndexOf("Wa", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Watara";
        }
        else if (_packageDisplayName.IndexOf("Xa", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Xavier";
        }
        else if (_packageDisplayName.IndexOf("Yg", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Yggdahiang";
        }
        else if (_packageDisplayName.IndexOf("Zl", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return "Zlanithee";
        }
        else
        {
            return "Nullasaurus Voidthera";
        }
    }

    private string GenerateCreaturePower()
    {
        // Dont like writing it like this but can't be fussed atm

        if (_packageDisplayName.IndexOf("2D", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[0];
            return "2nd-Dimensional Physiology";
        }
        else if (_packageDisplayName.IndexOf("Ani", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[1];
            return "Projection Sorcery";
        }
        else if (_packageDisplayName.IndexOf("Apple", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[2];
            return "Upgraded Form";
        }
        else if (_packageDisplayName.IndexOf("Ad", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[3];
            return "Persuasion";
        }
        else if (_packageDisplayName.IndexOf("Cloud", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[4];
            return "Temporal Reload";
        }
        else if (_packageDisplayName.IndexOf("Microsoft", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[5];
            return "Technology Manipulation";
        }
        else if (_packageDisplayName.IndexOf("Multiplayer", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[6];
            return "Replication";
        }
        else if (_packageDisplayName.IndexOf("XR", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[7];
            return "Meta Teleportation";
        }
        else if (_packageDisplayName.IndexOf("Sysroot", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[8];
            return "Prehensility";
        }
        else if (_packageDisplayName.IndexOf("Toolchain", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[9];
            return "Prehensility Manipultation";
        }
        else if (_packageDisplayName.IndexOf("Unity", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            _creaturePowerDescTextField.text = _powerDecriptions[10];
            return "Creation";
        }
        else
        {
            _creaturePowerDescTextField.text = _powerDecriptions[11];
            return "Supernatural Strength";
        }
    }

    private void DisplayPackageData()
    {
        _packageNameTextField.text = _packageNameTextField.text + _packageDisplayName;

        _authorNameTextField.text = _authorNameTextField.text + _authorName;

        _publishedDateTextField.text = _publishedDateTextField.text + _datePublished.ToString();

        //_categoryTextField.text = _categoryTextField.text + _packageCategory;
    }

    public void ResetVariables()
    {
        _creatureNameTextField.text = "<b>Name: </b>";
        _creaturePowerNameTextField.text = "<b>Power: </b>";

        _packageNameTextField.text = "<b>Name: </b>";
        _authorNameTextField.text = "<b>Author: </b>";
        _publishedDateTextField.text = "<b>Published: </b>";
    }

    #endregion

    #region Unity Methods

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ResetVariables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
