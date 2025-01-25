using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class FileManager
{
    private const string keyword = "AAECAwQFBgcICQoLDA0ODw==";
    public static bool WriteToFile(string fileName, string fileContents, bool Encrypted = false)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            using FileStream stream = File.Create(fullPath);
            if (Encrypted)
            {
                // WriteEncrypted(fileContents, stream);
                stream.Close();
                string encryptedFileContent = EncryptDecrpyt(fileContents);
                fileContents = encryptedFileContent;
                File.WriteAllText(fullPath, fileContents);
            }
            else
            {
                stream.Close();
                File.WriteAllText(fullPath, fileContents);
            }

            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    private static string EncryptDecrpyt(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyword[i % keyword.Length]);
        }
        return result;
    }

    public static bool LoadFromFile(string fileName, out string result, bool Encrypted = false)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(fullPath))
        {
            File.WriteAllText(fullPath, "");
        }

        try
        {
            if (Encrypted)
            {
                result = EncryptDecrpyt(File.ReadAllText(fullPath));
            }
            else
            {
                result = File.ReadAllText(fullPath);
            }
            return true;
        }
        catch (System.Exception e)
        {
            result = "";
            Debug.LogError($"Failed to load from {fullPath} with exception {e}");
            return false;
        }
    }
}