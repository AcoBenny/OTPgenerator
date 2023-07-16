using System;

public class OTPGenerator
{
    public static string GenerateOTP(string userId, out DateTime expirationTime)
    {
        Random random = new Random();

        // Generate a random 6-digit numeric OTP
        string otp = random.Next(100000, 999999).ToString();

        // Set the expiration time to 30 seconds from the current time
        expirationTime = DateTime.Now.AddSeconds(30);

        // Concatenate the User ID, OTP, and DateTime
        string otpWithUserIdAndDateTime = $"{userId}-{otp}-{expirationTime:yyyyMMddHHmmss}";

        return otpWithUserIdAndDateTime;
    }

    public static bool ValidateOTP(string expectedOTP, string userOTP)
    {
        // Trim any leading or trailing whitespace from the user input OTP
        string trimmedUserOTP = userOTP.Trim();

        // Compare the expected OTP with the trimmed user input OTP
        return expectedOTP == trimmedUserOTP;
    }

    public static bool IsOTPExpired(DateTime expirationTime)
    {
        return DateTime.Now > expirationTime;
    }
}