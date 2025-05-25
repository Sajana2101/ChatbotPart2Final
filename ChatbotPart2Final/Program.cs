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
        static void Main(string[] args)
        {


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











            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                //User's entered name 
                Console.WriteLine($"{userName}: ");
                //Takes user input, converts it to lower case, and trims it to ensure that the response is understood by the program.
                string userInput = Console.ReadLine()?.ToLower().Trim();
                //if the user enters "exit" the program asks the user the chatbot asks the user to rate it and then the program displays a goodbye message and ends.
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeResponse($"Maven: Thank you for your time {userName}!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypeResponse($"Maven: Before you go , please rate your experience from 1 to 5 stars:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string rating = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypeResponse($"Maven: Thank you for rating me {rating} star(s)! Stay safe out there! Goodbye {userName}!");
                    break;
                }
                //if the user enters anything other than exit, input and the username is passed to the this method to provide the appropriate response
                HandleUserQuery(input: userInput, userName: userName);
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
        static void HandleUserQuery(string input, string userName)
        {
            //Switch statement to handle the user input 
            //each input has a case which has a method to respond to the repsonse
            //username is taken to create a more personal response 
            //user input is passed to the switch statement so that the appropriate repsonse can be given.
            switch (input)
            {

                case "hello":
                case "hi":
                    GreetUser(username: userName);
                    break;
                case "how are you":
                    CheckBotMood(username: userName);
                    break;
                case "what is your purpose":
                case "purpose":
                    ExplainPurpose(username: userName);
                    break;
                case "what can you do":
                    DescribeCapabilities();
                    break;
                case "tell me about cybersecurity basics":
                case "what are cybersecurity basics":
                case "cybersecurity basics":
                    ExplainCyberBasics(username: userName);
                    break;
                case "explain phishing":
                case "what is phishing":
                case "tell me about phishing":
                case "phishing":
                    ExplainPhishing(username: userName);
                    break;
                case "explain malware":
                case "what is malware":
                case "tell me about malware":
                case "malware":
                    ExplainMalware(username: userName);
                    break;
                case "explain password safety":
                case "what is password safety":
                case "tell me about password safety":
                case "password safety":
                    ExplainPasswordSafety(username: userName);
                    break;
                case "explain online browsing":
                case "what is online browsing":
                case "tell me about online browsing":
                case "safe online browsing":
                    ExplainSafeBrowsing(username: userName);
                    break;
                case "help":
                    Help(username: userName);
                    break;
                //default statement to handle unsupported queries 
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeResponse($"Chatbot: Sorry {userName}, I didn't quite catch that!");
                    break;
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


        static void GreetUser(String username)
        {
            //set colour
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~GREETING~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            //method to create the conversation effect
            //takes user namr to make response more personal
            TypeResponse($"Maven: Hello there {username}! How can I help you today?");
        }
        //method to respond to user asking how the chat bot is 
        static void CheckBotMood(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~GREETING~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: I'm secure and running smoothly! Thanks for asking {username}.");
        }
        //method to respond to user asking what is the chatbots purpose
        static void ExplainPurpose(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~MY PURPOSE~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: Good question {username}! My purpose is to educate and guide you through " +
                $"\ncybersecurity topics to help you stay safe online!");
        }
        // //method to respond to capabilities query
        static void DescribeCapabilities()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~WHAT I CAN DO~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse("Maven: I can help you learn about key cybersecurity topics such as phishing," +
                "\n malware, password safety, and safe online browsing." + "Here are some things you can ask me:");
            Console.WriteLine(
               "\n- Basic conversations (Hi, Hello, How are you)" +
               "\n- Ask me what I can do" +
               "\n- Ask my what my purpose is" +
               "\n- Cybersecurity Basics " +
               "\n- Phishing " +
               "\n- Malware." +
               "\n- Password Saftey " +
               "\n- Safe online browsing " +
               "\n- Help" +
               "\n- Exit");

        }
        //method to respond to user asking about cybersecurity basics 
        static void ExplainCyberBasics(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~CYBERSECURITY BASICS~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: Good question {username}, always best to start with the basics" +
                "\nCybersecurity is the process of protecting systems, networks, and programs from malicious attacks. " +
                "\nIt's essential in our digital world." +
                "\nAlways ensure you uphold the three principals of cybersecurity: " +
                "\n-Confidentiality: Keep access to your sensitive information restricted" +
                "\n-Integrity: Ensure restricted access to altering your documents and data" +
                "\n-Availability: Your systems, functions, and data must be available when you need it.");
        }
        //Method that tells user about phishing 
        static void ExplainPhishing(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~PHISHING~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: Good question {username}! Phishing is a cyber attack where attackers try to steal personal info by pretending" +
                "\nto be a trusted source, usually via fake emails or messages. Always examine senders and the contents of emails, messages, etc." +
                "\n that you recieve. Do not open any links or attachments from suspicious senders or senders you do not know until you have " +
                "\nverified the senders legitimacy.");
        }
        //Method tells user about Malware
        static void ExplainMalware(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~MALWARE~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: Great question {username} Malware is short for malicious software, malware is designed to damage, disrupt and harm " +
                $"devices that it infects." +
                "\nTypes of malware include viruses, worms, ransomware, spyware, and trojans." +
                "\nMalware can infect a computer through many ways such as phishing attacks, downloading corrupted files, and " +
                "\nvisiting insecure websites to name a few. " +
                "\nBe cautious when downloading files from the internet, and opening links and attachments in emails, messages etc.");
        }
        //Method tells user about password safety
        static void ExplainPasswordSafety(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~PASSWORD SAFETY~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: Good question {username}! Passwords are essential in ensuring that only authorised individuals can access " +
                $"your information" +
                $"Always use strong and unique passwords. Avoid personal information such names and birthdays." +
                "\nMake passwords long and a mixture of uppercase, lowercase letters, numbers and characters." +
                "\n Use a secure password manager to store your passwords" +
                "\n You can also enable two-factor authentication for extra security." +
                "\nAVOID SHARING PASSWORDS!!!");
        }
        //Method explains safe browsing to the user
        static void ExplainSafeBrowsing(String username)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~SAFE BROWSING~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeResponse($"Maven: Great question {username}! Safe online browsing means avoiding dangerous websites, not clicking" +
                $" on suspicious ads." +
                "\nFailing to do so may result in your device being compromised and infected with malware." +
                "\nMake sure any sites you visit have HTTPS in the header." +
                "\nYou may want to consider using a VPN to further protect you");
        }
        static void Help(String username)
        {

            Console.WriteLine("\nMaven: Here are some things you can ask me about:" +
               "\n- Basic conversations (Hi, Hello, How are you)" +
               "\n- Ask me what I can do" +
               "\n- Ake me what my purpose is" +
               "\n- Cybersecurity Basics " +
               "\n- Phishing " +
               "\n- Malware." +
               "\n- Password Saftey " +
               "\n- Safe online browsing " +
               "\n- Exit");
        }


    }
}
