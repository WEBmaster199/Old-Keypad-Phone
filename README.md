# Old-Keypad-Phone
The C# Code shows a user to imitate text input using an old phone's numeric keypad setup, managing various key presses and special characters.

![Screenshot (1118)](https://github.com/user-attachments/assets/61514b12-a806-4ec0-89b1-7600e1c95f77)


Explanation of the Code

The C # program emulates text input using a traditional mobile phone keypad, where each number (except 0 and 1) corresponds to multiple letters, and you cycle through the letters by pressing the number repeatedly.

1. Keypad Mapping:
The array establishes the letters associated with each key. For instance, the key '2' corresponds to "ABC", and the key '7' corresponds to "PQRS".

2. MapKeyPressToChar Function: The function translates a sequence of key presses into the corresponding character. It accepts a key (e.g., '2') and the number of times it was pressed (e.g., 1, 2, 3). It determines which letter to return based on the number of presses using modulo arithmetic.

3. KeyInput Function: The function KeyInput processes a string of key presses and decodes it based on the rules of an old phone keypad. It keeps track of:
   
    a. The key currently being pressed
   
    b. The consecutive number of times the key was pressed
   
    c. If the * (backspace) key is pressed, it deletes the last character.
   
    d. The # key indicates the end of the input.


5. Main method: The main method includes test cases that provide different sequences of key presses as input to the KeyInput function.
