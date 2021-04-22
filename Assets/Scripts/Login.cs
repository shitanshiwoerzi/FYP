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
            }
        }else{
            Debug.LogWarning("Username field empty");
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
            }
        } else{
                Debug.LogWarning("Password is invalid");
        }
    } else{
            Debug.LogWarning("Password field empty");
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
        print("Login Successful");
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
}