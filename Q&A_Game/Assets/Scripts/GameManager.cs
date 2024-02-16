using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using ActionManager;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

namespace QA_Game
{
    public class GameManager : MonoBehaviour
    {
        public StringCollection Students;
        public GameObject Cube;       
        public float RandomDuration;       
        public StringVariable FirstStudent;
        public StringVariable SecondStudent;
        public GameEvent PlayEvent;
        public GameEvent ResultEvent;

        int _firstIndex;
        int _secondIndex;


        private void Awake()
        {
            
        }


        public void GetRandomStudent()
        {
            PlayEvent.Raise();
            FirstStudent.Value = "";
            SecondStudent.Value = "";

            int randomIndex = Random.Range(0, Students.Count);
            _firstIndex = Mathf.CeilToInt(Random.Range(0, Students.Count));
            _secondIndex = Mathf.CeilToInt(Random.Range(0, Students.Count));                      
            Cube.transform.DOBlendableRotateBy(Random.onUnitSphere * 1000, RandomDuration, RotateMode.FastBeyond360);
            StartCoroutine(SetNames());
        }

        IEnumerator SetNames()
        {
            yield return new WaitForSeconds(RandomDuration);
            ResultEvent.Raise();
            int rand = Random.Range(1, 10);
            if (rand % 2 == 0)
            {
                FirstStudent.Value = Students[_firstIndex]; 
                SecondStudent.Value = Students[_secondIndex];
            }
            else
            {
                FirstStudent.Value = Students[_firstIndex];
                SecondStudent.Value = Students[_secondIndex];
            }                        
        }



    }

}

