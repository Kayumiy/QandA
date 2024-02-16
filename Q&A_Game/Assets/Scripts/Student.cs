using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;
using DG.Tweening;


namespace QA_Game
{
    public class Student : MonoBehaviour
    {
        public StringVariable StudentVariable;

        private void Awake()
        {
            StudentVariable.Value = "";
        }

        private void Update()
        {
            transform.GetChild(0).GetComponent<TMP_Text>().text = StudentVariable.Value;
        }

        public void ScaleAnimation()
        {
            StartCoroutine(SomeCoroutine());
            
        }

        IEnumerator SomeCoroutine()
        {
            Tween myTween = transform.DOScale(1.2f, 0.25f);
            yield return myTween.WaitForCompletion();
            // This log will happen after the tween has completed
            transform.DOScale(1, 0.25f);
        }
    }

}


