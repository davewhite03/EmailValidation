
using System.Text.RegularExpressions;


class Program{
        static void Main(string[] args ){
      // Infinite loop to keep the program running
            while(true){
//Ask user for the CSV file name found in Data Folder
  Console.WriteLine("Enter the CSV file name (or type 'exit' to quit):");
            string fileName = Console.ReadLine();
        
 // Check if the user wants to exit the program
            if (fileName.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break; 
            }
            //Recieve
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
            string filePath = Path.Combine(projectDirectory, "Data", $"{fileName}.csv");


            // Check if file exists
            if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File does not exist.");
             continue;
        }
// List used for storing valid and invalid email addresses 
        List<string> validEmails = new List<string>();
        List<string> invalidEmails = new List<string>();


 //  process each line of the file
        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                //validate email

                if (values.Length >= 3 && IsValidEmail(values[2]))
                {
                    validEmails.Add(values[2]);
                }
                else
                {
                    invalidEmails.Add(values[2]);
                }
            }
        }
//listing of all valid and invalid emails
        Console.WriteLine("Valid Emails:");
        validEmails.ForEach(Console.WriteLine);

        Console.WriteLine("\nInvalid Emails:");
        invalidEmails.ForEach(Console.WriteLine);
    }
        }
//Email validation method
  static bool IsValidEmail(string email)
{
    if (string.IsNullOrWhiteSpace(email))
        return false;

    try
    {
       
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
    catch
    {
        return false;
    }
}



        }

