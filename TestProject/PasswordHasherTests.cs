//Bu birim test, PasswordHasher sınıfının HashPassword yöntemini test eder. İlk test, HashPassword yönteminin boş olmayan bir dize döndürdüğünü doğrular. 
//İkinci test, HashPassword yönteminin şifreyi doğru bir şekilde hash'lediğini doğrular, yani dönen hash değerinin beklenen uzunlukta olduğunu kontrol eder.
 
using Xunit;

namespace StajyerTakipSistemi.Web.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void HashPassword_ReturnsNonEmptyString()
        {
            string password = "testPassword";

            string hashedPassword = PasswordHasher.HashPassword(password);

            Assert.False(string.IsNullOrEmpty(hashedPassword));
        }

        [Fact]
        public void HashPassword_HashesPasswordCorrectly()
        {
            string password = "testPassword";

            string hashedPassword = PasswordHasher.HashPassword(password);

            Assert.Equal(44, hashedPassword.Length); 
        } 

    }
}
