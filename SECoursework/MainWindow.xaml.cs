using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.IO;
using Data;
using Business;
using Newtonsoft.Json;


namespace SECoursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string header;
        string messageType;
        string body;

        // SMS variables
        string phoneNumber;
        string smsBody;
        string smsBodyAtIndex;
        int indexOfSmsBody;
        string subSmsBody;
        string smsBodyResult;
        string[] smsBodyToArray;

        // EMAIL variables
        string emailAddress;
        string firstString;
        string standardSubject;
        string secondString;
        int indexOfSecondString;
        string sirEmailSubject;
        string sportCentreCode;
        string thirdString;
        int indexOfThirdString;
        string subCentreCode;
        string fourthString;
        int indexOfFourthString;
        string fifthString;
        int indexOfFifthString;
        string sirMessageText;
        string subSirText;
        string standardBodyString;
        int indexOfStandardBody;
        string subStandardBody;
        string standardBody;
        string replaceWith = "<URL Quarantined>";
        string linkPattern = @"\b(?:https?://|www\.)\S+\b";
        string filteredSirBody;
        string filteredStandardBody;
        string nature;

        // TWEET variables  
        string tweetBody;
        string tweetId;
        string mentionPattern = @"(?:(?<=\s)|^)@(\w*[A-Za-z_]+\w*)";
        string hashtagPattern = @"(?:(?<=\s)|^)#(\w*[A-Za-z_]+\w*)";
        string tweetBodyAtIndex;
        int indexOfTweetBody;
        string subTweetBody;
        string tweetBodyResult;
        string[] tweetBodyTextToArray;
        string mention;
        string hashtag;
        string[] tweetBodyToStringList;

        Serialize s = new Serialize();

        SaveTrendingList saveTrendingList = new SaveTrendingList();
        SaveMentionsList saveMentionsList = new SaveMentionsList();
        

        public void detectMessageType()
        {
            Match matchSms = Regex.Match(header, @"^S[0-9]{9}$");
            Match matchEmail = Regex.Match(header, @"^E[0-9]{9}$");
            Match matchTweet = Regex.Match(header, @"^T[0-9]{9}$");
            if (matchSms.Success)
            {
                filterSms();
            }
            else if(matchEmail.Success)
            {
                filterEmail();
            }
            else if(matchTweet.Success)
            {
                filterTweet();
            }
            else
            {
                MessageBox.Show("Invalid message Header");
                txtHeader.Text = "";
            }
            
        }
        
        public void filterSms()
        {
            try
            {
                // Filter body of sms

                smsBody = body; // Store the body from the main body text box

                // Match regex patter to first value of the smsBody stored in index 0
                phoneNumber = smsBody.Split()[0];
                Match number = Regex.Match(phoneNumber, @"^[+0-9]{13}$");
                /*  Validate the phone number
                    First character of phone number must be a + sign
                    and the length must be 14 characters long 
                    then display the phone nmumber in text box
                    and set the message type to Sms.
                    Make a substring to store the rest of the text 
                    and store it in a subSmsBody variable
                */
                if (number.Success)
                {                   
                    smsBodyAtIndex = smsBody.Split()[1];
                    indexOfSmsBody = smsBody.IndexOf(smsBodyAtIndex);
                    subSmsBody = smsBody.Substring(indexOfSmsBody);
                    smsBodyResult = subSmsBody;

                    if (smsBodyResult.Length > 140)
                    {
                        MessageBox.Show("Message is too large");
                    }
                    else
                    {
                        disSmsSender.Text = phoneNumber;
                        messageType = "Sms";
                        disSmsBody.Text = smsBodyResult;                      
                        txtHeader.Text = "";
                        txtBody.Text = "";
                        smsBodyToArray = smsBodyResult.Split(' ');
                        smsAbbreviations();
                        serialize();
                    }
                }
                else
                {
                    MessageBox.Show("Phone number not valid");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("SMS message cannot be procceseed correctly\n" +
                    "Please make sure the appropriate format of message is applied\n" +
                    "Press 'Help' button for further assistance");
            }
                      

        }

        public void smsAbbreviations()
        {

            var shortCut = new List<string>(); // This list contains shortcuts to words such as LOL
            var expandedMeaning = new List<string>(); // This list contins expanded meaning such as LOL Laugh Out Loud
            using (var file = new StreamReader(@"E:\Software engineering coursework\textwords.csv"))
            {
                while (!file.EndOfStream)
                {
                    var split = file.ReadLine().Split(',');
                    shortCut.Add(split[0]);
                    expandedMeaning.Add(split[1]);
                }
            }

            /*
             Each elemnt in shortCut list has an index
             and each element (x) in smsBodyToArray
             if one of the element of shortCut list 
             is found in smsBodyToArray then save the index of this 
             particular elemnt form the shortCut list
             */

            foreach (var element in shortCut)
            {
                foreach (string x in smsBodyToArray)
                {
                    if (x.Contains(element))
                    {
                        List<string> smsBodyList = new List<string>();

                        foreach(string v in smsBodyToArray)
                        {
                            smsBodyList.Add(v);
                        }

                        int indexOfElement = shortCut.IndexOf(element); // Getting the index of the shortcut from the list
                        string fullValue = expandedMeaning[indexOfElement]; // Getting the full meaning of the abreviation from the fullMeaning list
                        fullValue = "<" + fullValue + ">";
                        int indexOfElementInBody = smsBodyList.IndexOf(element); // Getting the index of the abbreviation in the message body
                        // Find the value in the message body and change it to fullValue
                        int indexPlusOne = indexOfElementInBody + 1;
                        smsBodyList.Insert(indexPlusOne, fullValue);
                        disSmsBody.Text = string.Join(" ", smsBodyList);

                    }
                }

            }
        }

        public void tweetAbbreviations()
        {
            var shortCut = new List<string>(); // This list contains shortcuts to words such as LOL
            var expandedMeaning = new List<string>(); // This list contins expanded meaning such as LOL Laugh Out Loud
            using (var file = new StreamReader(@"E:\Software engineering coursework\textwords.csv"))
            {
                while (!file.EndOfStream)
                {
                    var split = file.ReadLine().Split(',');
                    shortCut.Add(split[0]);
                    expandedMeaning.Add(split[1]);
                }
            }
            /*
             Each elemnt in shortCut list has an index
             and each element (x) in smsBodyToArray
             if one of the element of shortCut list 
             is found in smsBodyToArray then save the index of this 
             particular elemnt form the shortCut list
             */

            foreach (var element in shortCut)
            {
                foreach (string x in tweetBodyToStringList)
                {
                    if (x.Contains(element))
                    {
                        List<string> tweetBodyList = new List<string>();

                        foreach (string v in tweetBodyToStringList)
                        {
                            tweetBodyList.Add(v);
                        }

                        int indexOfElement = shortCut.IndexOf(element); // Getting the index of the shortcut from the list
                        string fullValue = expandedMeaning[indexOfElement]; // Getting the full meaning of the abreviation from the fullMeaning list
                        fullValue = "<" + fullValue + ">";
                        int indexOfElementInBody = tweetBodyList.IndexOf(element); // Getting the index of the abbreviation in the message body
                                                                                   // Find the value in the message body and change it to fullValue
                        int indexPlusOne = indexOfElementInBody + 1;
                        tweetBodyList.Insert(indexPlusOne, fullValue);
                        disTweetBody.Text = string.Join(" ", tweetBodyList);

                    }
                }
            }

        }

        public void filterEmail()
        {
            // Filter subject
            try
            {
                firstString = body.Split()[0];
                //Match matchEmail = Regex.Match(firstString, @"[^0-9a-zA-Z@\ ]+", "");
                if (firstString.Contains("@"))
                {
                    emailAddress = firstString;

                    secondString = body.Split()[1]; // Store the second value at the index 1 as a subject
                    indexOfSecondString = body.IndexOf(secondString); // Store the index of the second string 
                   
                    if (secondString == "SIR")
                    {
                        thirdString = body.Split()[2];
                        indexOfThirdString = body.IndexOf(thirdString);

                        fourthString = body.Split()[3];
                        indexOfFourthString = body.IndexOf(fourthString);

                        fifthString = body.Split()[4];
                        indexOfFifthString = body.IndexOf(fifthString);
                        subSirText = body.Substring(indexOfFifthString); // End index is not specified to store all of the text
                        sirMessageText = subSirText;

                        Match matchSirSubject = Regex.Match(thirdString, @"^\d{2}/\d{2}/\d{2}$");
                        Match matchCentreCode = Regex.Match(fourthString, @"^\d{2}-\d{3}-\d{2}$");

                        if(matchSirSubject.Success)
                        {
                            if (matchCentreCode.Success)
                            {
                                if (sirMessageText.Length > 1028)
                                {
                                    MessageBox.Show("The message text is too large");
                                }
                                else
                                {
                                    messageType = "SIR";
                                    sportCentreCode = fourthString;
                                    sirEmailSubject = secondString + " " + thirdString;
                                    disSirEmailSubject.Text = sirEmailSubject;
                                    disCentreCode.Text = sportCentreCode;
                                    disSirEmailSender.Text = emailAddress;
                                    disSirBody.Text = sirMessageText;
                                    filteredSirBody = Regex.Replace(sirMessageText, linkPattern, replaceWith); // Filter out links
                                    disSirBody.Text = filteredSirBody;
                                    // Display pop up window to find out the nature of the incident 
                                    IncidentNature incidentNature = new IncidentNature();
                                    incidentNature.Show();
                                    nature = disSirNature.Text.ToString();
                                    serialize();
                                    txtHeader.Text = "";
                                    txtBody.Text = "";
                                    //Save the nature to nature list

                                }

                            }
                            else
                            {
                                MessageBox.Show("Sport centre code must be in the following format:\n 11-111-11");
                            }
                        }

                    }
                    else if (!secondString.Contains("SIR"))
                    {
                        // If the second string doesn contain sir then the email is considered as standard
                        messageType = "Standard email";
                        //standardSubject = body.Substring(indexOfSecondString);
                        standardSubject = body.Split()[1];
                        if(standardSubject.Length > 20)
                        {
                            MessageBox.Show("Subject should be no longer than 20 characters long");
                        }
                        else
                        {
                            standardBodyString = body.Split()[2];
                            indexOfStandardBody = body.IndexOf(standardBodyString);
                            subStandardBody = body.Substring(indexOfStandardBody);
                            standardBody = subStandardBody;

                            if (standardBody.Length > 1028)
                            {
                                MessageBox.Show("The message text is too large");
                            }
                            else
                            {
                                filteredStandardBody = Regex.Replace(standardBody, linkPattern, replaceWith); // Filter out links
                                disStandardEmailSender.Text = emailAddress;
                                disSubject.Text = standardSubject;
                                disStandardEmailBody.Text = filteredStandardBody;
                                serialize();
                                txtHeader.Text = "";
                                txtBody.Text = "";

                            }
                        }

                       
                    }
                    else
                    {
                        MessageBox.Show("Subject for significant incident report should be in the following format:\n 'SIR dd/mm/yy'");
                    }
                }
                else
                {
                    MessageBox.Show("Email address not valid");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Email cannot be procceseed correctly\n" +
                    "Please make sure the appropriate format of message is applied\n" +
                    "Press 'Help' button for further assistance");
            }
            
           
        }

        public void filterTweet()
        { 
            try
            {
                if (header.Contains("T"))
                {
                    tweetBody = body;

                    //---Filter out sender id---

                    //Match tweet id regex pattern to fist string from the body
                    tweetId = Regex.Replace(tweetBody.Split()[0], @"[^@a-zA-Z0-9-_\ ]+", "");

                    //Validate the tweet id
                    if (tweetId[0] == '@' && tweetId.Length < 17)
                    {
                        //---Filter out the rest of the tweet body---
                        tweetBodyAtIndex = tweetBody.Split()[1];
                        indexOfTweetBody = tweetBody.IndexOf(tweetBodyAtIndex);
                        subTweetBody = tweetBody.Substring(indexOfTweetBody);
                        tweetBodyResult = subTweetBody;
                        

                        if (tweetBodyResult.Length > 140)
                        {
                            MessageBox.Show("Message is too large");
                        }
                        else
                        {
                            messageType = "Tweet";
                            disTweetSender.Text = tweetId;
                            disTweetBody.Text = tweetBodyResult;
                            tweetBodyToStringList = tweetBodyResult.Split(' '); 
                            tweetAbbreviations();


                            //---Filter out mentions---

                            //Split body text into array list
                            tweetBodyTextToArray = tweetBodyResult.Split();

                            foreach (string s in tweetBodyTextToArray)
                            {
                                Match match = Regex.Match(s, mentionPattern, RegexOptions.IgnoreCase);

                                if (match.Success) 
                                {
                                    mention = match.Value;
                                    saveMentionsList.SaveMention(mention);
                                }
                                
                            }

                            

                            //---Filter out hashtags---
                            foreach (string s in tweetBodyTextToArray)
                            {
                                Match match = Regex.Match(s, hashtagPattern, RegexOptions.IgnoreCase);

                                if (match.Success)
                                {
                                    hashtag = match.Value;
                                    saveTrendingList.SaveHashtag(hashtag);
                                }
                            }

                            serialize();
                            txtHeader.Text = "";
                            txtBody.Text = "";

                            TrendingList trendingListWindow = new TrendingList();
                            trendingListWindow.Show();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Twitter ID not valid");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tweet cannot be procceseed correctly\n" +
                    "Please make sure the appropriate format of message is applied\n" +
                    "Press 'Help' button for further assistance");
            }
            
        }

        public void serialize()
        {
            MessageTypeFactory messageFactory = new MessageTypeFactory();
            if (messageType == "Sms")
            {
                // Save sms message

                AbstractMessageProduct smsMessage = messageFactory.FactoryMethod(messageType,
                                                                             phoneNumber,
                                                                             smsBodyResult,
                                                                             standardSubject,
                                                                             sirEmailSubject,
                                                                             sportCentreCode,
                                                                             nature,
                                                                             tweetId,
                                                                             tweetBodyResult);

                smsMessage.Type = messageType;
                smsMessage.Sender = phoneNumber;
                smsMessage.Body = smsBodyResult;

                // Preparing the object to JSON serialisation
                // by gettin rid of null values 
                string messageObject = JsonConvert.SerializeObject(smsMessage, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                s.Save(messageObject);

            }
            else if(messageType == "Standard email")
            {
                // Save standard email 

                AbstractMessageProduct standardEmail = messageFactory.FactoryMethod(messageType,
                                                                             phoneNumber,
                                                                             smsBodyResult,
                                                                             standardSubject,
                                                                             sirEmailSubject,
                                                                             sportCentreCode,
                                                                             nature,
                                                                             tweetId,
                                                                             tweetBodyResult);

                standardEmail.Type = messageType;
                standardEmail.Sender = emailAddress;               
                standardEmail.StandardSubject = standardSubject;
                standardEmail.Body = filteredStandardBody;


                // Preparing the object to JSON serialisation
                // by gettin rid of null values 
                string messageObject = JsonConvert.SerializeObject(standardEmail, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                s.Save(messageObject);

            }
            else if(messageType == "SIR")
            {
                // Save sir email

                AbstractMessageProduct sirEmail = messageFactory.FactoryMethod(messageType,
                                                                             phoneNumber,
                                                                             smsBodyResult,
                                                                             standardSubject,
                                                                             sirEmailSubject,
                                                                             sportCentreCode,
                                                                             nature,
                                                                             tweetId,
                                                                             tweetBodyResult);

                sirEmail.Type = messageType;
                sirEmail.Sender = emailAddress;
                sirEmail.SirSubject = sirEmailSubject;
                sirEmail.CentreCode = sportCentreCode;
                sirEmail.IncidentNature = nature;
                sirEmail.Body = filteredSirBody;

                // Preparing the object to JSON serialisation
                // by gettin rid of null values 
                string messageObject = JsonConvert.SerializeObject(sirEmail, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                s.Save(messageObject);

            }
            else if(messageType == "Tweet")
            {
                // Save tweet

                AbstractMessageProduct tweet = messageFactory.FactoryMethod(messageType,
                                                                             phoneNumber,
                                                                             smsBodyResult,
                                                                             standardSubject,
                                                                             sirEmailSubject,
                                                                             sportCentreCode,
                                                                             nature,
                                                                             tweetId,
                                                                             tweetBodyResult);

                tweet.Type = messageType;
                tweet.Sender = tweetId;
                tweet.Body = tweetBodyResult;

                // Preparing the object to JSON serialisation
                // by gettin rid of null values 
                string messageObject = JsonConvert.SerializeObject(tweet, Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                s.Save(messageObject);

            }

            
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            header = txtHeader.Text;
            body = txtBody.Text;
            detectMessageType();
        }
        private void txtBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txtHeader_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSmsSender_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSmsBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disStandardEmailSender_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSubject_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disStandardEmailBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disCentreCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disTweetSender_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disTweetBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSirEmailSender_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSirBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSirEmailSubject_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void disSirNature_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.Show();
        }
    }
}
