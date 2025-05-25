using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;


namespace ChatbotPart2Final
{
    class Program

    {

        static Random rnd = new Random();
        static List<string> rememberedTopics = new List<string>();
        static string userInterestTopic = "";
        static int userPromptCounter = 0;
        static bool userExpressedInterest = false;

        static void Main(string[] args)
        {
            int followUpIndex = 0;
            bool inConversation = false;

            Console.Title = "Cybersecurity Chatbot";
            //Set colour 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //ASCII Art
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
            //Calls the method that plays the greeting audio
            PlayGreetingAudio("MavenAudio.wav");
            //Asks the user to enter their name
            //TypeResponse() is a method used instead of conosle.writeline to "type" out the chatbot's response to create a more conversational feel
            TypeResponse("What is your name?");
            //set colour
            Console.ForegroundColor = ConsoleColor.White;
            //Takes user name as input 
            string userName = Console.ReadLine();
            //set colour to red 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //display user name with coloured boarder
            Console.WriteLine("********************************");
            Console.WriteLine($"* Welcome {userName}                    *");
            Console.WriteLine("********************************");
            //set colour to greem
            Console.ForegroundColor = ConsoleColor.Green;
            //Display a short messaage before displaying menu of queries 
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
            }
        };

          
            Dictionary<string, string[]> followUps = new Dictionary<string, string[]>
        {
            { "phishing", new[] {
                "Have you ever received a suspicious email or message?",
                "Would you like tips on how to identify fake emails?"
            }},
            { "malware", new[] {
                "Are you currently using antivirus software?",
                "Would you like to learn how malware spreads?"
            }},
            { "password", new[] {
                "Do you know if your passwords have ever been leaked?",
                "Would you like a tip on creating strong passwords?"
            }},
            { "cybersecurity", new[] {
                "Are you using a firewall or antivirus at home?",
                "Want to hear more about keeping your network secure?"
            }},
            { "virus", new[] {
                "Have you ever had a virus on your computer?",
                "Would you like to know how to remove one safely?"
            }},
            { "browsing", new[] {
                "Do you use a VPN when browsing on public Wi-Fi?",
                "Would you like to hear tips for safe online shopping?"
            }}
        };



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
    {"overwhelmed","Feeling this way is comepletely normal, let me share some a tip to help you feel better" }
};


           
            string currentTopic = null;
            string lastFollowUpTopic = null;
            bool awaitingFollowUpResponse = false;



            while (true)
            {

                if (!awaitingFollowUpResponse && !inConversation)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n{userName}, what can I assist you with? ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                //User's entered name 
                Console.WriteLine($"{userName}: ");
                //Takes user input, converts it to lower case, and trims it to ensure that the response is understood by the program.
                string userInput = Console.ReadLine()?.ToLower().Trim();
                CheckForKeywords(userInput);

                userPromptCounter++;

                if (userPromptCounter >= 3 && userExpressedInterest && !string.IsNullOrEmpty(userInterestTopic))
                {
                    string randomTopic = rememberedTopics[rnd.Next(rememberedTopics.Count)];
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    TypeResponse($"As someone who is curious about {randomTopic}, this is particularly important.");
                    userPromptCounter = 0;

                }
                //if the user enters "exit" the program asks the user the chatbot asks the user to rate it and then the program displays a goodbye message and ends.
                if (userInput.Contains("exit"))
                {
                    TypeResponse($"Goodbye {userName}! Stay safe online.");
                    break;
                }

                bool found = false;
                string detectedTopic = null;
                string detectedSentiment = null;
               

                foreach (var sentiment in sentiments.Keys)
                {
                    if (userInput.Contains(sentiment))
                    {
                        detectedSentiment = sentiment;
                        break;
                    }
                }

                foreach (var keyword in responses.Keys)
                {
                    if (userInput.Contains(keyword))
                    {
                        detectedTopic = keyword;
                        break;
                    }
                }


                if (detectedSentiment != null && detectedTopic != null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    TypeResponse($"\n{sentiments[detectedSentiment]}");

                    // Then respond with a cybersecurity fact + follow-up question
                    currentTopic = detectedTopic;
                    string randomReply = responses[detectedTopic][rnd.Next(responses[detectedTopic].Length)];
                    Console.ForegroundColor = ConsoleColor.White;
                    // TypeResponse($"\n{randomReply}");

                    if (followUps.ContainsKey(detectedTopic))
                    {
                        string followUp = followUps[detectedTopic][rnd.Next(followUps[detectedTopic].Length)];
                        TypeResponse(followUp);
                        awaitingFollowUpResponse = true;
                        lastFollowUpTopic = detectedTopic;
                    }


                    else
                    {
                        TypeResponse($"Let me know if there is anything else I can assist you with {userName}?");
                        awaitingFollowUpResponse = false;
                        lastFollowUpTopic = null;
                    }

                    continue; // Skip rest of loop and wait for next input
                }

                if (currentTopic != null && (
                userInput.Contains("explain") || userInput.Contains("more") || userInput.Contains("i don't understand") || userInput.Contains("what do you mean")))
                {
                    string[] extraResponses = responses[currentTopic];
                    string deeperResponse = extraResponses[rnd.Next(extraResponses.Length)];
                    Console.ForegroundColor = ConsoleColor.White;
                    TypeResponse($"\nSure, here's more on {currentTopic}:");
                    TypeResponse(deeperResponse);
                    continue;
                }
                if (awaitingFollowUpResponse)
                {
                    if (userInput.Contains("yes") || userInput.Contains("confused") || userInput.Contains("explain more") || userInput.Contains("i don't understand"))

                    {
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
                            TypeResponse("Would you like to explore another topic?");
                           

                        }

                      
                        awaitingFollowUpResponse = followUpIndex < followUpQs.Length;
                        continue;
                    }
                    else if (userInput.Contains("no"))
                    {
                        TypeResponse("No problem! Let me know if you'd like to learn about something else.");
                        awaitingFollowUpResponse = false;
                        inConversation = false;
                        followUpIndex = 0;
                        continue;
                    }
                }



                foreach (var keyword in responses.Keys)
                {
                    if (userInput.Contains(keyword))

                    {
                        currentTopic = keyword;
                        string randomReply = responses[keyword][rnd.Next(responses[keyword].Length)];
                        Console.ForegroundColor = ConsoleColor.White;
                        TypeResponse($"\n{randomReply}");

                        if (followUps.ContainsKey(keyword))
                        {
                            string followUp = followUps[keyword][rnd.Next(followUps[keyword].Length)];
                            TypeResponse(followUp);
                            awaitingFollowUpResponse = true;
                            lastFollowUpTopic = keyword;
                        }
                        else
                        {
                            TypeResponse("Would you like to explore another topic?");
                            awaitingFollowUpResponse = false;
                            lastFollowUpTopic = null;
                        }

                        found = true;
                        break;
                    }

                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeResponse("I'm sorry, I don't understand that topic. Try asking about phishing, malware, password, virus, browsing, or cybersecurity.");
                }
            }
        }




        //Method to play greeting audio 
        //Takes filePath as a parameter, this will be the name of the audio
        static void PlayGreetingAudio(string filePath)
        {
            //try catch to handle unexpected errors such as file formatting issues 
            try
            {
                //creates a full absolute path to a file by combining the current directory(where the app is running) with a file or relative path(filePath)
                //(i.e the audio file)
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                //Checks if the file exists
                if (File.Exists(fullPath))
                {
                    //Plays audio 
                    SoundPlayer player = new SoundPlayer(fullPath);
                    //halts the execution of the rest of the code until the audio is finished playing
                    player.PlaySync();
                }
                //if the audio does not exist then the program will throw and error
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: the file'{filePath}'was not found.");

                }
            }
            //catch to handle exceptions 
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //message that will be thrown in the event of an unexpected error
                Console.WriteLine($"Error playing audio: {ex.Message}");

            }

        }


        //method to create a typewriter effect
        // takes a string as a parameter, this will the chatbots output 
        static void TypeResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Loop through each character in the input message
            foreach (char c in message)
            {
                // Write the character to the console without moving to the next line
                Console.Write(c);
                // Pause for 30 ms to create a typing effect
                System.Threading.Thread.Sleep(30);
            }
            // Move to the next line after the message is displayed fully
            Console.WriteLine();
        }


        static void CheckForKeywords(string input)
        {
            string[] interestKeywords = { "interested", "curious", "keen", "fascinated", "interesting", "worried", "scared", "favourite" };
            string[] cybersecurityTopics = { "cybersecurity", "malware", "viruses", "spam", "scams", "phishing", "ransomware", "trojan", "worm", "spyware" };

            string loweredInput = input.ToLower();

            bool foundInterest = false;
            bool foundTopic = false;
            string matchedTopic = "";

            foreach (string interest in interestKeywords)
            {
                if (loweredInput.Contains(interest))
                {
                    foundInterest = true;
                    break;
                }
            }

            foreach (string topic in cybersecurityTopics)
            {
                if (loweredInput.Contains(topic))
                {
                    matchedTopic = topic;
                    foundTopic = true;
                    if (!rememberedTopics.Contains(topic)) rememberedTopics.Add(topic);
                }
            }

            // If both found (not necessarily in same line)
            if (foundInterest && foundTopic)
            {
                userInterestTopic = matchedTopic;
                userExpressedInterest = true;
                userPromptCounter = 0; // Reset counter when interest is expressed
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Maven: That's great you're interested in {matchedTopic}, I'll remember that! It's a crucial part " +
                    $"staying safe online!");
                Console.WriteLine($"[DEBUG] userInterestTopic: {userInterestTopic}, userExpressedInterest: {userExpressedInterest}");
            }


        }

        static int inputCounter = 0;
        static string chatHistoryPath = "chathistory.txt";

        static void LogUserInput(string input)
        {
            inputCounter++;
            File.AppendAllText(chatHistoryPath, $"User: {input}\n");

            if (inputCounter % 3 == 0)
            {
                TypeResponse("Chat history saved to chathistory.txt\n");
            }
        }

    }
}
