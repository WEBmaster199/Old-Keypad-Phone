#include <stdio.h>
#include <string.h>

// Putting an array that maps each number key (0-9) to its corresponding letters
char keypadMapping[10][5] = {
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

// Using a function to get the appropriate character based on the number of presses for a key
char mapkeyPressToChar(char key, int pressCount) {
    int index = key - '0';  // Convert the character (e.g., '2') to an integer (e.g., 2)
    int numLetters = strlen(keypadMapping[index]);

    // If the key has corresponding letters, calculate which letter to return based on the press count
    if (numLetters > 0) {
        return keypadMapping[index][(pressCount - 1) % numLetters];
    }

    return '\0';  // If the key doesn't map to any letter, return the null character
}

// Running a function that processes the input string to decode it according to the old phone keypad system
void keyinput(const char* input) {
    char decodedText[100];  // Array to store the decoded result
    int currentIndex = 0;   // Position in the decodedText array for adding characters
    char previouskey = '\0';  // Keeps track of the last key pressed
    int consecutivekeyCount = 0;  // Keeps track of how many times the same key is pressed

    for (int i = 0; input[i] != '\0'; i++) {
        char currentkey = input[i];

        // Finalize the last key's character if the '#' (send) key is pressed
        if (currentkey == '#') {
            if (previouskey != '\0') {
                decodedText[currentIndex++] = mapkeyPressToChar(previouskey, consecutivekeyCount);
            }
            break;  // Stop processing the input since '#' indicates the end
        }

        // If '*' (backspace) is pressed, remove the last character from the result
        if (currentkey == '*') {
            if (currentIndex > 0) {
                currentIndex--;  // Delete the last added character
            }
            continue;  // Move on to the next key in the input string
        }

        // Check if the key pressed is a valid digit (between '0' and '9')
        if (currentkey >= '0' && currentkey <= '9') {
            // If the current key is the same as the previous one, increment the press count
            if (currentkey == previouskey) {
                consecutivekeyCount++;
            } else {
                // Add the previous key's character to the result before handling the new key
                if (previouskey != '\0') {
                    decodedText[currentIndex++] = mapkeyPressToChar(previouskey, consecutivekeyCount);
                }
                // Update the tracking variables for the new key
                previouskey = currentkey;
                consecutivekeyCount = 1;
            }
        }
    }

    decodedText[currentIndex] = '\0';  // Null-terminate the decoded text
    printf("Output: %s\n", decodedText);  // Displaying the final decoded result
}

int main() {
    // Let's run some few test cases
    keyinput("33#");               // It should print: E
    keyinput("227*#");             // It should print: B
    keyinput("4433555 555666#");  // It should print: HELLO
    keyinput("8 88777444666*664#");          // It should print: ?????

    return 0;
}
