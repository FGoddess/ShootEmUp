namespace SaveSystem.Encryption
{
public class XorEncryptionService : IEncryptionService
{
	private const string ENCRYPTION_KEY = "VerySecretKey";
	
	public byte[] Encrypt(byte[] data)
	{
		return ApplyXor(data);
	}

	public byte[] Decrypt(byte[] encryptedData)
	{
		return ApplyXor(encryptedData);
	}

	private byte[] ApplyXor(byte[] data)
	{
		var result = new byte[data.Length];
		for (var i = 0; i < data.Length; i++)
			result[i] = (byte)(data[i] ^ ENCRYPTION_KEY[i % ENCRYPTION_KEY.Length]);
		return result;
	}
}
}