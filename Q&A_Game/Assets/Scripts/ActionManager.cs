﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ActionManager
{
    public class Actions : MonoBehaviour
    {
        //This Class is used for some methods which are not included in UNITY3D
        /*
         * Moving object by time
         * Moving object by speed
         * Returning all children of GameObject
         */

        public static float AnimationTime(Animator animator, string animationName)
        {
            float time = 0;
            RuntimeAnimatorController ac = animator.runtimeAnimatorController;    //Get Animator controller
            for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
            {
                if (ac.animationClips[i].name == animationName)        //If it has the same name as your clip
                {
                    time = ac.animationClips[i].length;
                }
            }

            Debug.Log("time of the aniamtion: " + time);
            return time;
        }

        public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds)
            {
                if (!objectToMove) yield break;

                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
        }

        public static IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed = 20f)
        {
            // speed should be 1 unit per second
            while (objectToMove.transform.position != end)
            {
                if (!objectToMove) yield break;
                objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

        public static List<GameObject> ChildrenOfGameobject(GameObject obj)
        {
            List<GameObject> children = new List<GameObject>();
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                children.Add(obj.transform.GetChild(i).gameObject);
            }
            return children;
        }

        public static IEnumerator ScaleOverSeconds(GameObject objectToScale, Vector3 scaleTo, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingScale = objectToScale.transform.localScale;
            while (elapsedTime < seconds)
            {
                if (!objectToScale) yield break;
                objectToScale.transform.localScale = Vector3.Lerp(startingScale, scaleTo, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToScale.transform.localScale = scaleTo;
        }

        public static IEnumerator RotateOverSeconds(GameObject objectToRotate, float z, float seconds)
        {
            float elapsedTime = 0;
            Quaternion startingScale = objectToRotate.transform.localRotation;
            while (elapsedTime < seconds)
            {
                if (!objectToRotate) yield break;
                objectToRotate.transform.localRotation = Quaternion.Lerp(startingScale, Quaternion.Euler(0, 0, z), (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToRotate.transform.localRotation = Quaternion.Euler(0, 0, z);
        }

        public static IEnumerator RotateOverSeconds(GameObject objectToRotate, Quaternion rotateTo, float seconds)
        {
            float elapsedTime = 0;
            Quaternion startingScale = objectToRotate.transform.localRotation;
            while (elapsedTime < seconds)
            {
                if (!objectToRotate) yield break;
                objectToRotate.transform.localRotation = Quaternion.Lerp(startingScale, rotateTo, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToRotate.transform.localRotation = rotateTo;
        }

        public static IEnumerator ChangeColorOverTime(Image image, Color end, float duration)
        {
            Color start = image.GetComponent<Image>().color;
            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                if (!image) yield break;
                float normalizedTime = t / duration;
                //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
                image.GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
            image.GetComponent<Image>().color = end; //without this, the value will end at something like 0.9992367
        }

        public static IEnumerator FadeOverTime(GameObject image, float opacity, float duration)
        {
            Color start = image.GetComponent<SpriteRenderer>().color;
            Color end = new Color(1f, 1f, 1f, opacity);
            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                if (!image) yield break;
                float normalizedTime = t / duration;
                //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
                image.GetComponent<SpriteRenderer>().color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
            image.GetComponent<SpriteRenderer>().color = end; //without this, the value will end at something like 0.9992367
        }

        public static IEnumerator FadeOverTime(Image image, float opacity, float duration)
        {
            Color start = image.color;
            Color end = new Color(1f, 1f, 1f, opacity);
            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                if (!image) yield break;
                float normalizedTime = t / duration;
                //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
                image.color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
            image.color = end; //without this, the value will end at something like 0.9992367
        }

        public static IEnumerator FadeOverTime(SpriteRenderer sprite, float opacity, float duration)
        {
            Color start = sprite.color;
            Color end = new Color(1f, 1f, 1f, opacity);
            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                if (!sprite) yield break;
                float normalizedTime = t / duration;
                //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
                sprite.color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
            sprite.color = end; //without this, the value will end at something like 0.9992367
        }

        public static IEnumerator ChangeColorOverTime(GameObject gameObject, Color end, float duration)
        {
            Color start = gameObject.GetComponent<SpriteRenderer>().color;
            for (float t = 0f; t < duration; t += Time.deltaTime)
            {
                if (!gameObject) yield break;
                float normalizedTime = t / duration;
                //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(start, end, normalizedTime);
                yield return null;
            }
            gameObject.GetComponent<SpriteRenderer>().color = end; //without this, the value will end at something like 0.9992367
        }

        public static void LoadScene(string nameOfScene)
        {
            SceneManager.LoadScene(nameOfScene);
        }

        public static Vector2 getScreenSizeInPoints(float percentage = 1.0f)
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * percentage, Screen.height * percentage, 0));
        }

        public static Vector2 ConvertV3ToV2(Vector3 position)
        {
            return new Vector3(position.x, position.y, 0);
        }

        public static bool IsObjectInCollider(GameObject obj, GameObject colliderObject)
        {
            return colliderObject.GetComponent<Collider2D>() == Physics2D.OverlapPoint(new Vector3(obj.transform.position.x, obj.transform.position.y, 0));
        }

        public static IEnumerator ActionWrong(MonoBehaviour monoBehaviour, GameObject obj)
        {
            if (!obj) yield return null;

            monoBehaviour.StartCoroutine(RotateOverSeconds(obj, 15, 0.1f));
            yield return new WaitForSeconds(0.1f);
            monoBehaviour.StartCoroutine(RotateOverSeconds(obj, -15, 0.2f));
            yield return new WaitForSeconds(0.2f);
            monoBehaviour.StartCoroutine(RotateOverSeconds(obj, 15, 0.2f));
            yield return new WaitForSeconds(0.2f);
            monoBehaviour.StartCoroutine(RotateOverSeconds(obj, 0, 0.1f));
            yield return new WaitForSeconds(0.1f);
        }

    }
}