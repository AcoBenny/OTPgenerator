public class Program
{
    public static void Main()
    {
        // Prompt the user for user ID
        Console.Write("Enter User ID: ");
        string userId = Console.ReadLine()!;

        // Generate the OTP using the provided user ID
        string otp = OTPGenerator.GenerateOTP(userId, out DateTime expirationTime);
        Console.WriteLine($"Generated OTP: {otp}");

        Console.WriteLine("Waiting for OTP verification...");
        Console.WriteLine("Enter the OTP to verify:");

        // Read the OTP from the user for verification
        string userOTP = Console.ReadLine()!.Trim(); // Add .Trim() to remove leading/trailing whitespace

        // Validate the OTP
        bool isExpired = OTPGenerator.IsOTPExpired(expirationTime);
        bool isValid = !isExpired && OTPGenerator.ValidateOTP(otp, userOTP);

        if (isValid)
        {
            Console.WriteLine("OTP is valid.");
        }
        else if (isExpired)
        {
            Console.WriteLine("OTP has expired.");
        }
        else
        {
            Console.WriteLine("OTP is invalid.");
        }

        Console.ReadLine();
    }
}