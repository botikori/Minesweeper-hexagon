using System;
using System.Collections;
using DG.Tweening;
using Sweeper.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Sweeper.UI
{
    public class ScreenFade : Singleton<ScreenFade>
    {
        public static event Action FadedIn;
        public static event Action FadedOut;
        
        [SerializeField] private GameObject fadeObject;
        
        public void FadeIn(float duration)
        {
            fadeObject.GetComponent<Image>()?.DOColor(Color.black, duration);
            StartCoroutine("FadeInDelay", duration);
        }

        private IEnumerator FadeInDelay(float duration)
        {
            yield return new WaitForSeconds(duration);
            FadedIn?.Invoke();
        }

        public void FadeOut(float duration)
        {
            fadeObject.GetComponent<Image>()?.DOColor(Color.clear, duration);
            StartCoroutine("FadeOutDelay", duration);
        }
        
        private IEnumerator FadeOutDelay(float duration)
        {
            yield return new WaitForSeconds(duration);
            FadedOut?.Invoke();
        }
    }
}