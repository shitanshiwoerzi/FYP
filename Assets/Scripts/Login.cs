using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public string Username;
    private string Password;
    private String[] Lines;
    private string DecryptedPassword;
    public Text unInvalid; // Username Invalid
    public Text unEmpty; // Username field empty
    public Text pwdInvalid; // Password is invalid
    public Text pwdEmpty; // Password field empty

    public void LoginButton(){
        bool UN = false;
        bool PW = false;

        // check username
        if(Username != ""){
            if(System.IO.File.Exists(@"D:/UnityTestFolder/" + Username +".txt")){
                UN = true;
                Lines = System.IO.File.ReadAllLines(@"D:/UnityTestFolder/" + Username +".txt");
            } else {
                Debug.LogWarning("Username Invalid");
                unInvalid.gameObject.SetActive(true);
                StartCoroutine(Disappear());
            }
        }else{
            Debug.LogWarning("Username field empty");
            unEmpty.gameObject.SetActive(true);
            StartCoroutine(Disappear());
        }

        //check password
        if(Password != ""){
            if(System.IO.File.Exists(@"D:/UnityTestFolder/" + Username +".txt")){
            int i = 1;
            foreach (char c in Lines[2]){
                i++;
                char Decrypted = (char)(c / i);
                DecryptedPassword += Decrypted.ToString();
            }
            if(Password == DecryptedPassword){
                PW = true;
            } else{
                    Debug.LogWarning("Password is invalid");
                    pwdInvalid.gameObject.SetActive(true);
                    StartCoroutine(Disappear());
            }
        } else{
                Debug.LogWarning("Password is invalid");
                pwdInvalid.gameObject.SetActive(true);
                StartCoroutine(Disappear());
        }
    } else{
            Debug.LogWarning("Password field empty");
            pwdEmpty.gameObject.SetActive(true);
            StartCoroutine(Disappear());
    }


    if(UN == true && PW == true){
        string un = "";
        un += Username;
        int score = 0;
        Highscores.AddNewHighscore(un,score);
        PlayerPrefs.SetString("username",Username);
        Debug.Log(un);
        username.GetComponent<InputField>().text = "";
        password.GetComponent<InputField>().text = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            if(username.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
        }
         if(Input.GetKeyDown(KeyCode.Return)){
            if (Password != "" && Password != ""){
                LoginButton();
            }
        }

        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

        IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2);// Maintain 2 seconds
        unInvalid.gameObject.SetActive(false);// tip disappears
        unEmpty.gameObject.SetActive(false); // tip disappears
        pwdInvalid.gameObject.SetActive(false);// tip disappears
        pwdEmpty.gameObject.SetActive(false);// tip disappears
    }
}