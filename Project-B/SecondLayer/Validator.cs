using System.Globalization;

public static class Validator
{

    //Email checker give a email and this will check if its valid
    public static bool IsValidEmail(string email)
    {
        // Split the email address into two parts
        string[] parts = email.Split('@');

        // Check if there are exactly two parts
        if (parts.Length != 2)
        {
            return false;
        }

        // Check if the part before the '@' contains at least one letter
        string localPart = parts[0];
        if (!localPart.Any(char.IsLetter))
        {
            return false;
        }

        // Check if the part after the '@' contains a period
        string domainPart = parts[1];
        if (!domainPart.Contains('.'))
        {
            return false;
        }

        // Email is valid
        return true;
    }

    //Checks if given string is not null
    public static bool IsNotNull(string WordToCheck)
    {
        if(WordToCheck == null || WordToCheck.Trim() == "")
        {
            return false;
        }
        return true;
    }


    //Checks if all letters in WordToCheck are digits
    public static bool IsAllDigits(string WordToCheck)
    {
    foreach (char letter in WordToCheck)
    {
        if (!char.IsDigit(letter))
        {
            return false;
        }
    }
    return true;
    }

    //Checks if all letters in WordToCheck are Letters
    public static bool IsAllLetters(string WordToCheck)
    {
        foreach (char c in WordToCheck)
        {
            if (!char.IsLetter(c) && c != ' ')
            {
                return false;
            }
        }
        return true;
    }

    //checks if given string is a date with format dd-MM-yyyy
    public static bool IsDate(string str)
    {
        DateTime date;
        if (DateTime.TryParseExact(str, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            return true;
        }
        return false;
    }


    //checks if given string is a date with format dd-MM-yyyy HH:mm:ss
    public static bool IsTime(string str)
    {
        DateTime date;
        if (DateTime.TryParseExact(str, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            return true;
        }
        return false;
    }
}