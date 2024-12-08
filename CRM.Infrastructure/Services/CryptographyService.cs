using CRM.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Services
{
    public class CryptographyService : ICryptographyService
    {
        // Μέθοδος για την κρυπτογράφηση κωδικού πρόσβασης
        public string HashPassword(string password)
        {
            // Δημιουργία τυχαίου salt 16 bytes
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // Δημιουργία hash χρησιμοποιώντας τον αλγόριθμο PBKDF2 με SHA256
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Συνδυασμός του salt και του hash σε έναν πίνακα bytes
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            // Επιστροφή του αποτελέσματος σε μορφή Base64
            return Convert.ToBase64String(hashBytes);
        }

        // Μέθοδος για την επαλήθευση κωδικού πρόσβασης
        public bool VerifyPassword(string password, string storedHash)
        {
            // Μετατροπή του αποθηκευμένου hash από Base64 σε bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Ανάκτηση του salt από τα πρώτα 16 bytes
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Δημιουργία hash από τον κωδικό που δόθηκε χρησιμοποιώντας το salt
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Σύγκριση του παραγόμενου hash με το αποθηκευμένο hash
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false; // Επιστρέφει false αν τα hash δεν ταιριάζουν
            }

            return true; // Επιστρέφει true αν τα hash ταιριάζουν
        }
    }
}
