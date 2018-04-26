using Firebase.Auth;
using Firebase.Database;
using System;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IDataClient
    {
        FirebaseClient Db { get; }
    }

    internal sealed class FirebaseDataClient : IDataClient, IDisposable
    {
        private const string DatabaseName = @"https://smart-anki.firebaseio.com/";
        
        private readonly FirebaseConfig _config;
        private FirebaseClient _client;
        private readonly string _email;
        private readonly string _password;

        public FirebaseDataClient(string apiKey, string email, string password)
        {
            _config = new FirebaseConfig(apiKey);
            _email = email;
            _password = password;

            Open().Wait();
        }

        public FirebaseClient Db => _client;

        private async Task Open()
        {
            var authProvider = new FirebaseAuthProvider(_config);
            var auth = await authProvider.SignInWithEmailAndPasswordAsync(_email, _password);
            var options = new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken)
            };

            _client = new FirebaseClient(DatabaseName, options);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
