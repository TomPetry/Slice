using System.Collections;
using System.Collections.Generic;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AllButtonsStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Button start,loginWindowButton,registerWindowButton;

    public Button loginButton,registerButton;
    public Button backLogin,backRegister;

    public GameObject loginWindow, registerWindow;

    private WebrequestsStart _webStart;
    
    public TMP_InputField loginName;
    public TMP_InputField loginPass;
    
    public TMP_InputField registerName;
    public TMP_InputField registerPass;

    private void Start()
    {
        start.onClick.AddListener(ChangeScene.ChangeSceneToGame);
        
        loginWindowButton.onClick.AddListener(ActivateWindowLogin);
        registerWindowButton.onClick.AddListener(ActivateWindowRegister);
        
        backLogin.onClick.AddListener(DisableWindowLogin);
        backRegister.onClick.AddListener(DisableWindowRegister);
        
        loginButton.onClick.AddListener(Login);
        registerButton.onClick.AddListener(Register);

        _webStart = GetComponent<WebrequestsStart>();
    }

    private void Login()
    {
        StartCoroutine(_webStart.login(loginName.text,loginPass.text));
    }

    private void Register()
    {
        StartCoroutine(_webStart.register(registerName.text,registerPass.text));
    }

    private void ActivateWindowLogin()
    {
        loginWindow.SetActive(true);
        backLogin.gameObject.SetActive(true);
    }
    
    private void ActivateWindowRegister()
    {
        registerWindow.SetActive(true);
        backRegister.gameObject.SetActive(true);
    }

    private void DisableWindowLogin()
    {
        loginWindow.SetActive(false);        
        backLogin.gameObject.SetActive(false);       
    }

    private void DisableWindowRegister()
    {
        registerWindow.SetActive(false);
        backRegister.gameObject.SetActive(false);
    }
}
