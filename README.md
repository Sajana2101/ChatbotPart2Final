Cybersecurity Chatbot

This project was created by Sajana Motheram 

### Installation Instructions

1. Clone or download this repository to your local machine.
2. Open the solution (`.sln`) file using **Visual Studio**.
3. Ensure that your system has access to the required `.wav` audio file (e.g., `welcome.wav`) in the correct directory.
4. Build and run the program using Visual Studio.

**Note**: This application is developed using .NET Framework.

### Audio Notes

- Maven plays a welcome audio message using a `.wav` file.
- Make sure the audio file exists in the correct path relative to the executable.
- Only `.wav` format is supported due to the `SoundPlayer` class limitations.

### What the project does:
-This is a console-based cybersecurity chatbot named Maven, written in C# compiled on Visual Studio. 
-The purpose of this chatbot is to teach users about cybersecurity issues and make them aware of the dangers online. 
-This chatbot aims to teach users how to stay safe in the digital world. 

### How the code executes:
-When the user starts the program, the user is greeted with a recorded voice message from Maven and an ASCII art lock logo with the slogan "be aware, defend your device against cyberthreats". 
-A method used to play and integrate the voice message is called to play the message at the beginning. 
-The method takes the parameter filepath which is the name of the audio.
-The file path is combined with the current directory to find and play the audio if the file exists the audio is played. 
-The method uses the SoundPlayer object and PlaySync() method to halt the execution of the rest of the code until the audio has finished playing. 
-If the file does not exist then the method will throw an error message. 
-A try catch is also used to handle other unexpected errors such as file formatting errors. 


Once the audio has finished playing, the user is asked to enter their name. A method called TypeResponse() has been used to create a typewriter effect when the output is displayed. This is done to create a conversational feel. The output line Console.Writeline has been replaces with the method TypeResponse() so that the output is displayed using a type writer effect. Once the user has entered their name, the application welcomes the user with a personalised greeting and welcome message. 

The user is then shown a list of queries the Maven can answer and the user can ask. A while loop is used to allow the user to ask questions as many times as they wish. An if statement is used to check the user input. If the user enters "exit", Maven displays a goodbye message and asks the user to rate their experience before they leave. Once the user enters their rating, Maven displays a final goodbye message and the program ends. If the user chooses to enter a supported query, the username and userinput are passed to a function called HandleUserQuery which addresses their input. 

Inside the HandleUserQuery method, the username and userinput are passed as parameters to the function and are used to determine Mavens' response as well as personalise the response. Inside the method, a switch statement is used to determine Maven's response. There is a case for each type of query, each case has a method which displays an output according to what query was entered. For example, if the user chose "Phishing", the method uses the switch statement to call the function ExplainPhishing() and display information about phishing. Each supported query is handled the same way. However, if the user enters a blank statement or an unsupported query, the method uses the default case to display the message "Sorry {username}, I didn't quit catch that!" and the user is prompted to enter their query again until a supported query is entered. 

Namespaces used: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;


