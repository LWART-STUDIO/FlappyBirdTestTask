using System.Collections.Generic;
using AppsFlyerSDK;
using UnityEngine;

namespace Game.Scripts.SDK
{
    public class AppsFlyerInit : MonoBehaviour,IAppsFlyerConversionData
    {
        public static AppsFlyerInit instanse;

        private string _logs="";
        public string Logs => _logs;
        private void Awake()
        {
            if (instanse != null && instanse != this)
                Destroy(this);
            else
            {
                instanse = this;
                DontDestroyOnLoad(this);
            }
                
            
        }
        void Start()
        {
            AppsFlyer.setIsDebug(true);
            AppsFlyer.initSDK("ZLigGqGzDdxGMT7QBPjsMG", "",this);
            AppsFlyer.startSDK();
        }

        public void onConversionDataSuccess(string conversionData)
        {
            AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
            Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
            _logs += $" {conversionData}";
            // add deferred deeplink logic here
        }

        public void onConversionDataFail(string error)
        {
            AppsFlyer.AFLog("onConversionDataFail", error);
            _logs += $" {error}";
        }

        public void onAppOpenAttribution(string attributionData)
        {
            AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
            Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
            // add direct deeplink logic here
        }

        public void onAppOpenAttributionFailure(string error)
        {
            AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
        }

    }
}
