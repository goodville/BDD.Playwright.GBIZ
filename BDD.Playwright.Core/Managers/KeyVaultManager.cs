namespace BDD.Playwright.Core.Helpers
{
    using System;
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using BDD.Playwright.Core.Configuration;

    public class KeyVaultManager
    {
        // public static string KeyVaultName => "kv-ihkeyvault-qa";
        // public static string KeyVaultURL => "https://kv-ihkeyvault-qa.vault.azure.net/";
        public static string GetSecret(string secretName)
        {
            var kvUri = "https://" + GlobalConfig.Settings.KeyVaultName + ".vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var secret = client.GetSecret(secretName);
            return secret.Value.Value;
        }

        public static KeyVaultSecret SetSecret(string secretName, string secretValue)
        {
            var kvUri = "https://" + GlobalConfig.Settings.KeyVaultName + ".vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var secret = client.SetSecret(secretName, secretValue);
            return secret.Value;
        }
    }
}
