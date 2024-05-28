using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace ActiveCamp.BL.Model
{
    public class SessionManager
    {
        private static readonly string FileName = "session.dat";

        public static void SaveSession(Session session)
        {
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Create, isolatedStorage))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Session));
                    serializer.Serialize(stream, session);
                }
            }
        }

        public static Session LoadSession()
        {
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(FileName))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Open, isolatedStorage))
                    {
                        if (stream.Length == 0)
                        {
                            throw new InvalidOperationException("Файл пустой.");
                        }

                        try
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Session));
                            return (Session)serializer.Deserialize(stream);
                        }
                        catch (InvalidOperationException ex)
                        {
                            throw new InvalidOperationException("Ошибка при десериализации XML-документа.", ex);
                        }
                        catch (XmlException ex)
                        {
                            throw new InvalidOperationException("Некорректный формат XML: " + ex.Message, ex);
                        }
                    }
                }
            }
            return null;
        }


        public static void ClearSession()
        {
            using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isolatedStorage.FileExists(FileName))
                {
                    isolatedStorage.DeleteFile(FileName);
                }
            }
        }
    }

}
