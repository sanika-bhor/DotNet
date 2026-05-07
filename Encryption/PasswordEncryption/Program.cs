using backend.Helpers;
class Program
{
    static void Main()
    {
        string plainText = "Hello World";

        // 32-byte key for AES-256
        string key = "12345678901234567890123456789012";

        string encrypted = EncryptionHelper.EncryptString(plainText, key);
        Console.WriteLine("Encrypted: " + encrypted);

        string decrypted = EncryptionHelper.DecryptString(encrypted, key);
        Console.WriteLine("Decrypted: " + decrypted);
    }

}