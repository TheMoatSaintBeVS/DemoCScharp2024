using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Memes.Core.Serialization
{


    public class TheSerializer
    {
        
        public static int ToXML<T>(T c, string unNomDeFichier)
        {
            int resultat = 0;
            XmlSerializer xS = new XmlSerializer(typeof(T));
            FileStream f = null;
            try
            {
                f = new FileStream(unNomDeFichier, FileMode.Create);
                xS.Serialize(f, c);
                f.Flush();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (f != null)
                {
                    f.Close();
                }
            }
            return resultat;
        }
        public static T FromXML<T>(string unNomDeFichier)
        {
            T resultat;
            XmlSerializer xS = new XmlSerializer(typeof(T));
            FileStream f = null;
            try
            {
                f = new FileStream(unNomDeFichier, FileMode.Open);
                resultat = (T)xS.Deserialize(f);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (f != null)
                {
                    f.Close();
                }
            }

            return resultat;
        }

        public static int ToJson<T>(T t, string fileName)
        {
            int resultat = 0;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore

            };
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(t, settings));
                resultat = 1;
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultat;
        }
        public static int ToJsonCopy<T>(T t, string fileName)
        {
            int resultat = 0;

            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(t));
                resultat = 1;
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultat;
        }
        public static T FromJson<T>(string fileName)
        {
            T t = default(T);
            try
            {
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
            }
            catch (Exception e)
            {
                throw e;
            }
            return t;
        }

    }
}
