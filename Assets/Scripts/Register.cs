﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


public class Register : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confPassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string form;
    private bool EmailValid = false;
    private string[] Characters= {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                                "1","2","3","4","5","6","7","8","9","0","_","-"}; 

    void Start(){
        
    }

    public void RegisterButton(){
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if(Username != ""){
            if(!System.IO.File.Exists(@"D:/UnityTestFolder/" + Username +".txt")){
                UN = true;
            } else {
                Debug.LogWarning("Username Taken");
            } 
        } else {
            Debug.LogWarning("Username field Empty");
        }
        // check email
        if(Email != ""){
            EmailValidation();
            if (EmailValid){
                if(Email.Contains("@")){
                    if(Email.Contains(".")){
                        EM = true;
                    } else{
                        Debug.LogWarning("Email is Incorrect");
                    }
                } else{
                    Debug.LogWarning("Email is Incorrect");
                }
            } else{
                Debug.LogWarning("Email is Incorrect");
            } 
        } else{
            Debug.LogWarning("Email Field Empty");
        }

        // check password
        if(Password != ""){
            if(Password.Length > 5){
                PW = true;
            } else{
                Debug.LogWarning("Password must be at least 6 characters long");
            }
        } else{
            Debug.LogWarning("Password field is empty");
        }

        //check confirm password
        if(ConfPassword != ""){
            if(ConfPassword == Password){
                CPW = true;
            } else{
                Debug.LogWarning("Passwords don't match");
            }
        } else{
            Debug.LogWarning("Confirm password field empty");
        }

        if(UN == true && EM == true && PW == true && CPW == true){
            bool Clear = true;
            int i = 1;
            foreach (char c in Password){
                if(Clear){
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            }
            form = (Username + Environment.NewLine + Email + Environment.NewLine + Password);
            System.IO.File.WriteAllText(@"D:/UnityTestFolder/" + Username +".txt", form);
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confPassword.GetComponent<InputField>().text = "";
            print("Registration Complete");
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            if(username.GetComponent<InputField>().isFocused){
                email.GetComponent<InputField>().Select();
            }
            if(email.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
            if(password.GetComponent<InputField>().isFocused){
                confPassword.GetComponent<InputField>().Select();
            }
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            if (Password != "" && Email != "" && Password != "" && ConfPassword != ""){
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confPassword.GetComponent<InputField>().text;

    }

    void EmailValidation(){
        bool SW = false;
        bool EW = false;

        for(int i = 0; i < Characters.Length; i++){
            if(Email.StartsWith(Characters[i])){
                SW = true;
            }
        }
        for(int i = 0; i < Characters.Length; i++){
            if(Email.EndsWith(Characters[i])){
                EW = true;
            }
        }
        if(EW == true && SW == true){
            EmailValid = true;
        }
    }

}
