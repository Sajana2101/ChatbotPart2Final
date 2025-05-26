### Maven Cybersecurity Chatbot
Maven is a C# console-based chatbot designed to help users learn about cybersecurity topics interactively. It features natural language keyword detection, personalised memory recall, follow-up questioning, and a typewriter-style response effect for an engaging user experience.


### Features
-Topic & Sentiment Detection: Recognises cybersecurity topics (e.g., phishing, malware, ransomware) and user sentiment from input to provide relevant responses.
-Memory Recall: Detects when a user expresses interest in a topic and remembers it, then references that interest every few inputs to personalise the conversation.
-Follow-up Questions: Asks follow-up questions on topics, handles user confirmations, and provides deeper explanations if requested.
-Typewriter Effect: Simulates a typing effect by printing responses character-by-character.
-Greeting Audio: Plays a greeting sound at startup (if audio file available).
-Chat History Logging: Logs user inputs to a text file (chathistory.txt) and notifies the user every three inputs that history was saved.
-Exit Command: Users can type “exit” anytime to end the chat session gracefully.


### Running the application:
-Clone or download the project source code.
-Open the project in your preferred C# IDE (e.g., Visual Studio).
-Ensure the greeting audio file (e.g., greeting.wav) is in the correct directory or update the 
 path accordingly.
-Build and run the project.
-Interact with Maven by typing cybersecurity-related queries or expressing interest.
-Type exit to close the chatbot.

### Usage:
-Simply type any cybersecurity topic or question (e.g., “Tell me about phishing”, “I am interested in ransomware”).
-Maven will detect topics and sentiments and respond with relevant information.
-Follow the prompts for follow-up questions or ask for explanations.
-Maven remembers your interests and refers back to them during the conversation.
-Inputs are saved to chathistory.txt every 3 entries.

### Methods and main logic 
-Main loop: Handles input reading, keyword detection, response generation, follow-up logic, and exit condition.
-CheckForKeywords(string input): Detects user interest and cybersecurity topics, updates memory.
-LogUserInput(string input): Saves user input to chathistory.txt with notifications.
-TypeResponse(string message): Prints output with typewriter effect.
-PlayGreetingAudio(string filePath): Plays a startup audio greeting if available.

### Dependencies
-.NET runtime compatible with System.Media.SoundPlayer for audio playback.

### Customisation
- add your name when chatbot requests it to receive personalised responses

### License
-This project is for educational and personal use. No warranty is provided or needed.
