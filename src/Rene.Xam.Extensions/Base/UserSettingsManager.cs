using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Base
{
    public class UserSettingsManager
    {
        protected T GetSetting<T>([CallerMemberName] string memberName = "") where T : class
        {

            var strValue = GetSettingValue(memberName) as string;

            if (string.IsNullOrEmpty(strValue)) return null;

            if (typeof(T) == typeof(string)) //las cadenas son un caso que no serializaremos
            {
                return strValue as T;
            }

            return JsonConvert.DeserializeObject<T>(strValue);


        }

        protected void SetObjSetting<T>(T value, [CallerMemberName] string memberName = "") where T : class
        {
            var strValue = JsonConvert.SerializeObject(value);
            SetSettingValue(memberName, strValue);
        }

        protected object GetSetting([CallerMemberName] string memberName = "")
        {
            return GetSettingValue(key: memberName);
        }

        protected void SetSetting<T>(T value, [CallerMemberName] string memberName = "") where T : struct
        {
            SetSettingValue(memberName, value);
        }

        protected void SetSetting(string value, [CallerMemberName] string memberName = "")
        {
            SetSettingValue(memberName, value);
        }



        public void SetDefaultValue(string key, object value)
        {
            if (GetSettingValue(key) == null)
            {
                SetSettingValue(key, value);
            }
        }

        #region Metodos Privados

        private object GetSettingValue(string key)
        {
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    Application.Current.Properties.Count.ToString().Log("Cantidad de settings");

            //    Application.Current.Properties.LogDicctionary("Settings");
            //}

            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key];
            }
            return null;
        }

        private void SetSettingValue(string key, object value)
        {
            Application.Current.Properties[key] = value;
            //cada vez que establezcamos un valor lo hacemos persistir por si acaso
            Task.Run(() => Application.Current.SavePropertiesAsync());
        }

        #endregion

    }
}
