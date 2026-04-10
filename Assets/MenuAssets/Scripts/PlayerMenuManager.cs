using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuManager : MonoBehaviour
{
    #region Variables

    [Header("Input System")]

    [Space(5)]

    [SerializeField] private InputActionAsset _inputActions;

    private InputAction _exitAction;

    [Header("Menu")]

    [Space(5)]

    [SerializeField] private GameObject _menuScreen;

    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private Button _backButton;

    [SerializeField] private Button _generatePackageCreatureButton;

    [Header("Creature Generator Screen")]

    [Space(5)]

    [SerializeField] private TMP_InputField _packageNameInputField;

    [Header("Package Creature Screen")]

    [Space(5)]

    [SerializeField] private Button _confirmButton;

    #endregion

    #region Methods

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SelectMenuScreen()
    {
        _backButton.Select();
    }

    public void ActivatePackageInputField()
    {
        _packageNameInputField.ActivateInputField();
    }

    public void SelectPackageCreatureScreen()
    {
        _confirmButton.Select();
    }

    public void DisableCreatureGeneratorButton()
    {
        _generatePackageCreatureButton.gameObject.SetActive(false);
    }

    private void PromptExit()
    {
        if (_exitAction.IsPressed() == true)
        {
            Debug.Log("registered input");
            _menuScreen.SetActive(true);
            _eventSystem.firstSelectedGameObject = _backButton.gameObject;
        }
    }

    private void InitialiseVariables()
    {
        _exitAction = _inputActions.FindAction("Keyboard/Escape");
        
        if (_exitAction != null)
        {
            Debug.Log("ExitAction is not null");
        }

        _menuScreen.SetActive(false);
    }

    #endregion

    #region Unity Methods

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialiseVariables();
    }

    private void Update()
    {
        PromptExit();
    }

    void OnEnable()
    {
        _inputActions.Enable();
    }

    void OnDisable()
    {
        _inputActions.Disable();
    }

    #endregion
}
