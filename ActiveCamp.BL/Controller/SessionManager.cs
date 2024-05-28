using ActiveCamp.BL.Model;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Serialization;

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
                        throw new InvalidOperationException("File is empty.");
                    }

                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Session));
                        return (Session)serializer.Deserialize(stream);
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new InvalidOperationException("Error during XML deserialization.", ex);
                    }
                    catch (XmlException ex)
                    {
                        throw new InvalidOperationException("Invalid XML format: " + ex.Message, ex);
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
