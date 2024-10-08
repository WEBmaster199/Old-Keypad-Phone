using System;

class oldkeypad
{
    // Putting an array that maps each number key (0-9) to its corresponding letters
    static string[] keypadMapping = {
        "0",       // Key 0 doesn't map to letters
        "&",       // Key 1 doesn't map to letters
        "ABC",     // Key 2 maps to "ABC"
        "DEF",     // Key 3 maps to "DEF"
        "GHI",     // Key 4 maps to "GHI"
        "JKL",     // Key 5 maps to "JKL"
        "MNO",     // Key 6 maps to "MNO"
        "PQRS",    // Key 7 maps to "PQRS"
        "TUV",     // Key 8 maps to "TUV"
        "WXYZ"     // Key 9 maps to "WXYZ"
    };

    // using a function to get the appropriate character based on the number of presses for a key
    static char MapKeyPressToChar(char key, int pressCount)
    {
        int index = key - '0';  // Convert the character (e.g., '2') to an integer (e.g., 2)
        int numLetters = keypadMapping[index].Length;

        // If the key has corresponding letters, calculate which letter to return based on the press count
        if (numLetters > 0)
        {
            return keypadMapping[index][(pressCount - 1) % numLetters];
        }

        return '\0';  // If the key doesn't map to any letter, return the null character
    }

    // using  a function that processes the input string to decode it according to the old phone keypad system
    static void KeyInput(string input)
    {
        char[] decodedText = new char[100];  // an array to store the decoded result
        int currentIndex = 0;   // the position in the decodedText array for adding characters
        char previousKey = '\0';  // keeps track of the last key pressed
        int consecutiveKeyCount = 0;  // keeps track of how many times the same key is pressed

        for (int i = 0; i < input.Length; i++)
        {
            char currentKey = input[i];

            // finalizing the last key's character if the '#' (send) key is pressed
            if (currentKey == '#')
            {
                if (previousKey != '\0')
                {
                    decodedText[currentIndex++] = MapKeyPressToChar(previousKey, consecutiveKeyCount);
                }
                break;  // terminate processing the input since '#' indicates the end
            }

            // If '*' (backspace) is pressed, remove the last character from the result
            if (currentKey == '*')
            {
                if (currentIndex > 0)
                {
                    currentIndex--;  // delete the last added character
                }
                continue;  // move on to the next key in the input string
            }

            // checking if the key pressed is a valid digit (between '0' and '9')
            if (currentKey >= '0' && currentKey <= '9')
            {
                // If the current key is the same as the previous one, increment the press count
                if (currentKey == previousKey)
                {
                    consecutiveKeyCount++;
                }
                else
                {
                    // add the previous key's character to the result before handling the new key
                    if (previousKey != '\0')
                    {
                        decodedText[currentIndex++] = MapKeyPressToChar(previousKey, consecutiveKeyCount);
                    }
                    // update the tracking variables for the new key
                    previousKey = currentKey;
                    consecutiveKeyCount = 1;
                }
            }
        }

        // null-terminate the decoded text
        Array.Resize(ref decodedText, currentIndex);
        Console.WriteLine("Output: " + new string(decodedText));  // displaying the final decoded result
    }

    static void Main()
    {
        // Let's run some few test cases
        KeyInput("33#");                         // It should print: E
        KeyInput("227*#");                       // It should print: B
        KeyInput("4433555 555666#");             // It should print: HELLO
        KeyInput("8 88777444666*664#");          // It should print an output (depended on input): 
    }
}

