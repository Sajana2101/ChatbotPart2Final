using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Collections.Generic;

class ChatbotPart2Final
{
    // Random number generator instance for selecting random responses or other random choices
    static Random rnd = new Random();
    // List to store cybersecurity-related keywords or topics that the user mentions during the chat
    static List<string> rememberedTopics = new List<string>();
    // Stores a specific topic the user has expressed interest in (e.g., "malware" or "phishing")
    static string userInterestTopic = "";
    static int userPromptCounter = 0;
    static bool userExpressedInterest = false;
    static void Main(string[] args)
    {
        // Keeps track of which follow-up reply to use next in the conversation
        int followUpIndex = 0;
        // Indicates whether the chatbot is currently engaged in an ongoing conversation
        bool inConversation = false;
        // Sets the title of the console window to "Maven Cybersecurity ChatBot"
        Console.Title = "Maven Cybersecurity ChatBot";
        // Sets the text color of the console output to dark red for better visual style
        Console.ForegroundColor = ConsoleColor.DarkRed;
        // ASCII Art
        Console.WriteLine(@"
                                              Be Aware                                          
                                   .:-=*#%####%####%%######+--:.                                    
                                  :##%#=:................::=####:.                                  
                                  :##..                    ...*#..                                  
                                  .*#:       .:*###*:.       .##..                                  
                                  .*#-.     .+#*:.:+#*..     .#%..                                  
                                  .*#=.    ..#*.. ..-+..     :#*.                                   
                                  .-#+.   ..-#+::::::::..   .+#-                                    
                                  ..%#:   .+###########%.  ..##:                                  
                                    =#=.  .+####=.:####%.  .+#+.                                    
                                    .##.  .+####*.+####%.  :*#:.                                    
                                    .=#*...+####+.*####%...+#+.                                     
                                    ..*#=..+############..=#*.                                      
                                      .*#+. .............=#*..                                      
                                      ..+#*.           .=##..                                       
                                       ..=##:        .:##+...                                       
                                         .:*#*.   ...*%#:.                                          
                                          ..-##*-.:*##-..                                           
                                             ..#####:.                                              
                                               ..-...                                               
                               Defend your device against cyberthreats
");
        // Play a greeting audio file and display a welcome message
        PlayGreetingAudio("MavenAudio.wav");
        TypeResponse("Welcome to Maven Cybersecurity ChatBot!");
        // Array of cybersecurity tips
        string[] tips = {
    "Tip of the Day: Use a password manager to create and store strong, unique passwords.",
    "Tip of the Day: Enable two-factor authentication (2FA) wherever possible.",
    "Tip of the Day: Keep your software and operating system up to date.",
    "Tip of the Day: Never click on suspicious links in emails or messages.",
    "Tip of the Day: Back up important data regularly to an external drive or cloud service.",
    "Tip of the Day: Use antivirus software and keep it updated.",
    "Tip of the Day: Be cautious when using public Wi-Fi—use a VPN if possible.",
    "Tip of the Day: Lock your devices when not in use.",
    "Tip of the Day: Don't overshare personal information on social media.",
    "Tip of the Day: Verify the identity of anyone requesting sensitive information."
};
        // Array of greeting phrases
        string[] greetings = new string[]
{
    "Hello there! I'm Maven, your cybersecurity companion. ",
    "Hey! Maven here, secure and ready to assist!",
    "Hi! I’m Maven. Let’s explore some digital safety tips.",
    "Greetings, friend! I am ready to assist you today!",
    "Yo! Maven here — your personal cyber safety sidekick."
};

        // Randomly select and display a cybersecurity tip
        Random random = new Random();
        int tipIndex = random.Next(tips.Length);
        string selectedTip = tips[tipIndex];

        // Randomly select and display a greeting
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        TypeResponse(tips[tipIndex]);
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Random rnd = new Random();
        string randomGreeting = greetings[rnd.Next(greetings.Length)];
        TypeResponse(randomGreeting);
        TypeResponse("What is your name:");
        string username = Console.ReadLine();
        // Personalized greeting
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("********************************");
        Console.WriteLine($"* Welcome {username}                    *");
        Console.WriteLine("********************************");

        TypeResponse($"Hello {username}, Nice to meet you!\n");
        // Introduce the chatbot's purpose
        TypeResponse("Let's delve into the world of cybersecurity where you can learn how to beat those pesky cybercriminals!");
        //Displays menu of queries that the chatbot can answer
        Console.WriteLine("Here are some things you can ask me about:" +
            
            "\n- Cybersecurity" +
            "\n  Virus"+
            "\n- Phishing " +
            "\n- Malware." +
            "\n- Password Saftey " +
            "\n- Safe online browsing " +
            "\n- Ransomware " +
            "\n- Social Engineering " +
            "\n- Security Updates " +
            "\n- Wifi " +
            "\n- VPN " +
            "\n- Firewalls " +
          
            "\n- Encryption " +
            "\n- Windows Defender " +

            "\n- Exit");

        // Dictionary mapping topics to arrays of random responses for variety
        Dictionary<string, string[]> responses = new Dictionary<string, string[]>
        { 
            { "phishing", new string[]
                {
                    "Phishing is when attackers trick you into giving personal info, often through fake emails.",
                    "Phishing attacks often mimic trusted sources. Always verify links before clicking.",
                    "Avoid phishing by checking sender details and not clicking unknown links.",
                    "Phishing can steal passwords and credit card info. Be skeptical of urgent messages.",
                    "Always hover over links to check authenticity before clicking in suspicious emails."
                }
            },
            { "malware", new string[]
                {
                    "Malware is software designed to harm or exploit devices and networks.",
                    "Antivirus programs help detect and remove malware threats.",
                    "Malware includes viruses, worms, Trojans, ransomware, and spyware.",
                    "Keep your OS and apps updated to prevent malware infections.",
                    "Avoid downloading unknown attachments to reduce malware risk."
                }
            },
            { "password", new string[]
                {
                    "Use long, complex passwords and avoid reusing them.",
                    "Consider using a password manager to store secure passwords.",
                    "Never share your passwords with anyone.",
                    "Two-factor authentication adds an extra layer of password security.",
                    "Avoid using personal info like birthdays in passwords."
                }
            },
            { "cybersecurity", new string[]
                {
                    "Cybersecurity is about protecting systems, networks, and data from digital attacks.",
                    "Strong cybersecurity practices include firewalls, encryption, and user awareness.",
                    "Good cybersecurity habits can protect your identity and data online.",
                    "Cybersecurity is a shared responsibility – always think before you click.",
                    "Education is key to staying safe in today’s digital world."
                }
            },
            { "virus", new string[]
                {
                    "Computer viruses replicate and spread, often causing data loss or corruption.",
                    "Viruses can come through infected files, USBs, or websites.",
                    "Install antivirus software to help prevent and remove computer viruses.",
                    "Email attachments are a common way viruses are spread.",
                    "Avoid pirated software – it can contain hidden viruses."
                }
            },
            { "browsing", new string[]
                {
                    "Use HTTPS websites for safer browsing.",
                    "Private/incognito mode doesn’t make you invisible, but avoids storing history.",
                    "Be cautious of pop-ups and fake download buttons.",
                    "Avoid entering sensitive info on public Wi-Fi without a VPN.",
                    "Browser extensions can be risky — only install from trusted sources."
                }
            },


             { "ransomware", new string[]
                {
                  "Ransomware locks or encrypts your files and demands payment for access.",
                  "Never pay a ransom — it doesn’t guarantee file recovery and encourages more attacks.",
                  "Keep backups of important data to recover from ransomware attacks.",
                  "Ransomware often spreads through phishing emails and malicious downloads.",
                  "Use up-to-date antivirus software to detect and block ransomware."
                }
            },
            { "social engineering", new string[]
               {
                  "Social engineering manipulates people into giving up confidential info.",
                  "Attackers often pretend to be trusted individuals or authorities.",
                  "Be cautious of unexpected calls or requests for sensitive data.",
                  "Always verify someone's identity before sharing personal info.",
                  "Security awareness can help prevent social engineering attacks."
                }
            },
            
            { "updates", new string[]
                {
                  "Regular updates patch security flaws that attackers exploit.",
                  "Enable automatic updates for your operating system and apps.",
                  "Outdated software is a common gateway for cyberattacks.",
                  "Check for updates frequently — especially for browsers and plugins.",
                  "Security updates are critical for staying protected online."
                }
            },

           { "wifi", new string[]
                {
                 "Public Wi-Fi can be insecure — avoid entering sensitive info on it.",
                 "Use a VPN to protect your data on public wireless networks.",
                 "Always change default router passwords at home.",
                 "Secure your home Wi-Fi with WPA3 encryption if possible.",
                 "Limit the number of devices allowed to connect to your network."
                }
            },

           { "vpn", new string[]
                {
                 "A VPN encrypts your internet traffic and hides your IP address for privacy.",
                 "Use a VPN on public Wi-Fi to protect your personal data.",
                 "VPNs can help bypass geographic restrictions safely and securely.",
                 "Not all VPNs are equal — choose a reputable, no-log provider.",
                 "A VPN adds a layer of security, especially on unsecured networks."
                }
            },

            { "firewall", new string[]
               {
                 "Firewalls monitor and control incoming/outgoing network traffic.",
                 "Use both hardware and software firewalls for better protection.",
                 "A firewall helps block unauthorized access to your system.",
                 "Make sure your firewall is enabled and properly configured.",
                 "Firewalls act as a gatekeeper between your device and the internet."
                }
            },

            { "defender", new string[]
                {
                 "Microsoft Defender is a built-in antivirus for Windows.",
                 "Defender provides real-time protection and threat detection.",
                 "Keep Defender updated to ensure it catches the latest threats.",
                 "Use Defender alongside a firewall for stronger security.",
                 "Windows Defender SmartScreen can help block malicious websites."
                }
            },

            { "encryption", new string[]
                {
                   "Encryption scrambles data so only authorized users can read it.",
                   "Always use encrypted messaging apps for private conversations.",
                   "End-to-end encryption ensures only the sender and receiver can see the message.",
                   "Encrypted websites use HTTPS — avoid HTTP for sensitive transactions.",
                   "Encryption protects your files and communications from prying eyes."
                }
            },
        };


        // Dictionary for follow-up questions based on topic
        Dictionary<string, string[]> followUps = new Dictionary<string, string[]>
        {
            { "phishing", new[] {
                "Have you ever received a suspicious email or message?",
                "Would you like tips on how to identify fake emails?",
                "Would you like another tip?",
                "Would you like to learn more?",
                "Would you like me to expand on this topic?"
            }},
            { "malware", new[] {
                "Are you currently using antivirus software?",
                "Would you like to learn how malware spreads?",
                "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
            }},
            { "password", new[] {
                "Do you know if your passwords have ever been leaked?",
                "Would you like a tip on creating strong passwords?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
            }},
            { "cybersecurity", new[] {
                "Are you using a firewall or antivirus at home?",
                "Want to hear more about keeping your network secure?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
            }},
            { "virus", new[] {
                "Have you ever had a virus on your computer?",
                "Would you like to know how to remove one safely?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
            }},
            { "browsing", new[] {
                "Do you use a VPN when browsing on public Wi-Fi?",
                "Would you like to hear tips for safe online shopping?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
            }},



            { "ransomware", new[] {
                "Do you know how to back up your files securely?",
                "Want to hear how ransomware spreads and how to avoid it?",
                "Would you like another tip?",
                "Would you like to learn more?",
                "Would you like me to expand on this topic?"
                }
            },

            { "social engineering", new[] {
                "Have you ever been tricked into giving personal info?",
                "Would you like tips on spotting manipulation techniques?",
                "Would you like another tip?",
                "Would you like to learn more?",
                "Would you like me to expand on this topic?"
                }
            },
            { "updates", new[] {
                "Do you keep your software and OS up to date?",
                "Would you like to know why updates are so important?",
                "Would you like another tip?",
                "Would you like to learn more?",
                "Would you like me to expand on this topic?"
                }
            },

            { "wifi", new[] {
                "Do you know if your home Wi-Fi is secured properly?",
                "Would you like tips on staying safe on public Wi-Fi?",
                "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
                }
            },

            {   "vpn", new[] {
                 "Are you currently using a VPN for your devices?",
                 "Would you like to know which VPNs are most secure?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
                }
            },

            { "firewall", new[] {
                "Do you know if your firewall is turned on and configured properly?",
                "Would you like tips on setting up a personal firewall?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
                }
            },

             { "defender", new[] {
                  "Do you use Windows Defender for real-time protection?",
                  "Would you like to know how to run a quick scan with Defender?" ,
                  "Would you like another tip?",
                  "Would you like to learn more?",
                 "Would you like me to expand on this topic?"

                }
            },
            { "encryption", new[] {
                 "Do you use encrypted apps like Signal or WhatsApp?",
                 "Would you like to learn how to encrypt your files or emails?",
                 "Would you like another tip?",
                "Would you like to learn more?",
                 "Would you like me to expand on this topic?"
                }
            },



        };



        //dictionary with different responses for sentiments 

        Dictionary<string, string> sentiments = new Dictionary<string, string>()
{
    { "worried", "It's completely understandable to feel that way. Would you like me to provide you with some tips on that topic?" },
    { "curious", "Curiosity is great! I can help you learn more about this topic." },
    { "excited", "I'm glad you're excited! Let's dive into some interesting info." },
    { "sad", "I'm sorry to hear you're feeling sad about this. Let's work through this together" },
    { "angry", "Feeling angry is natural with these threats. Let's find ways to tackle them." },
    { "frustrated", "I understand feeling frustrated. I'm here to help with any questions you have." },
    { "scared", "It's okay to feel scared. Knowledge is your best defense against cyber threats." },
    { "concerned", "Your concern is valid. I can share tips to help you stay safe." },
    { "anxious", "Feeling anxious is normal. Let's work through your worries together." },
    {"overwhelmed","Feeling this way is comepletely normal, let me share some a tip to help you feel better" },
     {"Stressed","I understand your frustration, let me help you through this with a helpful tip" }
};
        // Initialize chatbot state tracking variables
        string currentTopic = null;
        string lastFollowUpTopic = null;
        bool awaitingFollowUpResponse = false;
         Dictionary<string, string> descriptions = new Dictionary<string, string>
{
    { "malware", "Malware is software specifically designed to disrupt, damage, or gain unauthorized access to a computer system." },
    { "phishing", "Phishing is a type of online scam where attackers trick users into revealing personal information by pretending to be trustworthy entities." },
    { "ransomware", "Ransomware is a type of malware that locks or encrypts a victim's data and demands payment to restore access." },
    { "viruses", "A computer virus is a type of malware that, when executed, replicates by inserting copies of itself into other programs." },
    { "cybersecurity", "Cybersecurity refers to the practice of protecting systems, networks, and programs from digital attacks." },
    { "encryption", "Encryption is the process of converting data into a coded form to prevent unauthorized access." },
    { "defender", "Microsoft Defender is a built-in security program in Windows that provides real-time protection against viruses and other threats." },
    { "firewall", "A firewall is a security system that monitors and controls incoming and outgoing network traffic based on predetermined rules." },
    { "vpn", "A VPN (Virtual Private Network) encrypts your internet connection to secure data and protect your online identity." },
    { "updates", "Updates include patches and improvements that fix security vulnerabilities and keep your system protected." },
    { "social engineering", "Social engineering is a manipulation technique that exploits human error to gain private information or access." },
    { "safe browsing", "Safe browsing involves practices like using HTTPS websites, avoiding suspicious links, and not sharing personal information online." },
    { "password", "A password is a secret string of characters used to authenticate a user and protect access to systems or data." }
};


        while (true)
        {
            // Ask the user what they want help with if not in a follow-up or ongoing conversation

            if (!awaitingFollowUpResponse && !inConversation)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{username}, what can I assist you with? ");
            }
            // Read user input and convert to lowercase for easy matching
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine().ToLower();
            if (input.StartsWith("what is ")|| input.Contains("definition"))
            {
                string possibleTopic = input.Replace("what is ", "").Trim();

                if (descriptions.ContainsKey(possibleTopic))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    TypeResponse($"\nMaven: {descriptions[possibleTopic]}");

                    // 🔁 Random follow-up if available
                    if (followUps.ContainsKey(possibleTopic))
                    {
                        string followUp = followUps[possibleTopic][rnd.Next(followUps[possibleTopic].Length)];
                        TypeResponse(followUp);
                        awaitingFollowUpResponse = true;
                        lastFollowUpTopic = possibleTopic;
                    }
                    else
                    {
                        TypeResponse("Let me know if you'd like to explore anything else.");
                        awaitingFollowUpResponse = false;
                        lastFollowUpTopic = null;
                    }

                    userPromptCounter++;
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeResponse("Hmm, I'm sorry I dont seem to understand :/. Please check your spelling or asking another cybersecurity related question!");
                    userPromptCounter++;
                    continue;
                }
            }

            // Log input and check for keywords (user-defined methods)
            LogUserInput(input);
            CheckForKeywords(input);
            // Display response header

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("                         RESPONSE                              ");

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            userPromptCounter++;
            // After 3 prompts, reference user's previously expressed interest
            if (userPromptCounter >= 3 && userExpressedInterest && !string.IsNullOrEmpty(userInterestTopic))
            {
                string randomTopic = rememberedTopics[rnd.Next(rememberedTopics.Count)];
                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeResponse($"As someone who is curious about {randomTopic}, this is particularly important.");
                userPromptCounter = 0; //Exit loop
            }

               // Check if the user wants to exit
            if (input.Contains("exit"))
            {
                TypeResponse($"Goodbye {username}! Stay safe online.");
                break;
            }
            //variables to hold matched sentiment and topic

            bool found = false;

            string detectedSentiment = null;
            string detectedTopic = null;
            // Detect topic based on input
            foreach (var sentiment in sentiments.Keys)
            {
                if (input.Contains(sentiment))
                {
                    detectedSentiment = sentiment;
                    break;
                }
            }
            // Detect topic based on input
            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    detectedTopic = keyword;
                    break;
                }
            }
            // Respond if both a sentiment and a topic were detected
            if (detectedSentiment != null && detectedTopic != null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeResponse($"\n{sentiments[detectedSentiment]}");

                // Respond with a random reply for the topic
                currentTopic = detectedTopic;
                string randomReply = responses[detectedTopic][rnd.Next(responses[detectedTopic].Length)];
                Console.ForegroundColor = ConsoleColor.White;
                // If follow-ups exist for the topic, ask one
                if (followUps.ContainsKey(detectedTopic))
                {
                    string followUp = followUps[detectedTopic][rnd.Next(followUps[detectedTopic].Length)];
                    TypeResponse(followUp);
                    awaitingFollowUpResponse = true;
                    lastFollowUpTopic = detectedTopic;
                }


                else
                {
                    TypeResponse($"Let me know if there is anything else I can assist you with {username}?");
                    awaitingFollowUpResponse = false;
                    lastFollowUpTopic = null;
                }

                continue; //move to the next loop iteration
            }

            // Handle follow-up explanations if user asks for more info
            if (currentTopic != null && (
                input.Contains("explain") || input.Contains("more") || input.Contains("i don't understand") || input.Contains("what do you mean")))
            {
                string[] extraResponses = responses[currentTopic];
                string deeperResponse = extraResponses[rnd.Next(extraResponses.Length)];
                Console.ForegroundColor = ConsoleColor.White;
                TypeResponse($"\nSure, here's more on {currentTopic}:");
                TypeResponse(deeperResponse);
                continue;
            }
            // Handle response to previous follow-up
            if (awaitingFollowUpResponse)
            {
                if (input.Contains("yes") || input.Contains("confused") || input.Contains("explain more") || input.Contains("i don't understand"))

                {
                    // Give additional information about the follow-up topic
                    Console.ForegroundColor = ConsoleColor.White;
                    string[] extraTips = responses[lastFollowUpTopic];
                    TypeResponse(extraTips[rnd.Next(extraTips.Length)]);

                    string[] followUpQs = followUps[lastFollowUpTopic];
                    followUpIndex++;

                    if (followUpIndex < followUpQs.Length)
                    {
                        TypeResponse(followUpQs[followUpIndex]);
                        inConversation = true;
                    }
                    else
                    {
                        TypeResponse("What other topic would you like to explore?");
                       

                    }

                    // Continue awaiting follow-up if more remain

                    awaitingFollowUpResponse = followUpIndex < followUpQs.Length;
                    continue;
                }
                //extra words that indicate the user does not want to continue with the rest of the topics
                else if (input.Contains("nothing")|| input.Contains("no topic")|| input.Contains("no thanks"))
                {
                    // User does not want to continue on the topic
                    TypeResponse("No problem! Let me know if you'd like to learn about something else.");
                    awaitingFollowUpResponse = false;
                    inConversation = false;
                    followUpIndex = 0;
                    continue;
                }
            }

            // Try matching a topic again if no sentiment was detected earlier
            foreach (var keyword in responses.Keys)
            {
                // Check if the user's input contains the current keyword
                if (input.Contains(keyword))
                {
                    currentTopic = keyword;
                    // Select a random response from the list of responses for that keyword
                    string randomReply = responses[keyword][rnd.Next(responses[keyword].Length)];
                    Console.ForegroundColor = ConsoleColor.White;
                    TypeResponse($"\n{randomReply}");
                    // Check if follow-up questions are available for this topic
                    if (followUps.ContainsKey(keyword))
                    {
                        // Select and display a random follow-up question
                        string followUp = followUps[keyword][rnd.Next(followUps[keyword].Length)];
                        TypeResponse(followUp);

                        awaitingFollowUpResponse = true;
                        // Store the topic to track which topic the follow-up is for
                        lastFollowUpTopic = keyword;
                    }
                    else
                    {
                         // If no follow-up is available, ask if the user wants to explore another topic
                        TypeResponse("Would you like to explore another topic?");
                        awaitingFollowUpResponse = false;
                        lastFollowUpTopic = null;
                    }

                    found = true;
                    break;
                }

            }

            // If no topic was understood at all
            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeResponse("I'm sorry, I don't understand that topic. Try asking about phishing, malware, password, virus, browsing, or cybersecurity.");
            }


        }

    }
    // Method to simulate a typewriter effect by printing one character at a time
    static void TypeResponse(string message)
    {
        foreach (char c in message)
        {
            // Print each character
            Console.Write(c);
            // Pause briefly to simulate typing
            Thread.Sleep(25);
        }
        Console.WriteLine();
    }
    // Method to play a greeting audio file synchronously
    static void PlayGreetingAudio(string filePath)
    {
        try
        {
            // Construct full path to the audio file
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            // Check if the file exists
            if (File.Exists(fullPath))
            {
                SoundPlayer player = new SoundPlayer(fullPath);
                // Play the audio and wait for it to finish
                player.PlaySync();
            }
            else
            {

                // Display error if file not found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: the file '{filePath}' was not found.");
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during audio playback
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error playing audio: {ex.Message}");
        }


    }
    // Method to check if the user's input shows interest in any cybersecurity topic, takes user input as parameter
    static void CheckForKeywords(string input)
    {// List of words that indicate interest
        string[] interestKeywords = { "interested", "curious", "keen", "fascinated", "interesting", "favourite", "fascinating", "Like"};

        // List of relevant cybersecurity topics
        string[] cybersecurityTopics = { "cybersecurity", "malware", "viruses","virus","spam", "scams", "phishing", "ransomware","vpn","firewall","firewalls",
        "social engineering","encryption","defender","wifi","updates"};

        string loweredInput = input.ToLower();

        bool foundInterest = false;
        bool foundTopic = false;
        string matchedTopic = "";
        // Check if the user expressed interest
        foreach (string interest in interestKeywords)
        {
            if (loweredInput.Contains(interest))
            {
                foundInterest = true;
                break;
            }
        }
        // Check if the user mentioned a cybersecurity topic
        foreach (string topic in cybersecurityTopics)
        {
            if (loweredInput.Contains(topic))
            {
                matchedTopic = topic;
                foundTopic = true;
                // Remember the topic if it hasn't already been stored
                if (!rememberedTopics.Contains(topic)) rememberedTopics.Add(topic);
            }
        }

        // If both interest and topic are detected
        if (foundInterest && foundTopic)
        {
            userInterestTopic = matchedTopic;
            userExpressedInterest = true;
            // Reset counter for personalized response logic

            userPromptCounter = 0; 
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            // Respond to the user with a memory acknowledgment
            TypeResponse($"Maven: That's great you're interested in {matchedTopic}, I'll remember that! It's a crucial part " +
                $"staying safe online!");

        }
    }
    // Counter to keep track of number of user inputs
    static int inputCounter = 0;
    // File path for saving chat history
    static string chatHistoryPath = "chathistory.txt";
    // Method to log user input to a text file
    static void LogUserInput(string input)
    {
        // Append the user's input to the chat history file
        inputCounter++;
        File.AppendAllText(chatHistoryPath, $"User: {input}\n");
        // Every 3rd input, notify the user that the history was saved
        if (inputCounter % 3 == 0)
        {
            TypeResponse("Chat history saved to chathistory.txt\n");
        }
    }


}
