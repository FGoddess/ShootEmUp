namespace SaveSystem.Encryption
{
public interface IEncryptionService
{
	byte[] Encrypt(byte[] data);
	byte[] Decrypt(byte[] encryptedData);
}
}