
namespace EmailValidationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValidEmail_IsValid_ReturnsTrue()
        {
            var email = "test@email.com";
            var result = Program.IsValidEmail(email);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValidEmail_Invalid_ReturnsFalse()
        {
            var email = "invalidEmail@false";
            var result = Program.IsValidEmail(email);
            Assert.IsFalse(result);
        }

    
    }
}
