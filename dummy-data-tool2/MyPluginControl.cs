using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace dummy_data_tool2
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;
        private readonly string[] firstNames;
        private readonly string[] lastNames;
        private readonly string[] areaCodes;
        private readonly Random rand = new Random();
        private const int TimerInterval = 7500;

        public MyPluginControl()
        {
            //initialize an array of 100 random first names
            firstNames = new[] 
            {
                "John", "Jane", "Alex", "Emily", "Michael", "Sarah", "David", "Emma",
                "Daniel", "Sophia", "Matthew", "Olivia", "Christopher", "Isabella",
                "Anthony", "Mia", "Andrew", "Ava", "Joseph", "Charlotte",
                "Ryan", "Amelia", "Joshua", "Harper", "James", "Evelyn",
                "Justin", "Abigail", "Robert", "Luna", "William", "Madison",
                "Jacob", "Elizabeth", "Ethan", "Sofia", "Jason", "Avery",
                "Nicholas", "Ella", "Benjamin", "Scarlett", "Samuel", "Grace",
                "Tyler", "Chloe", "Nathan", "Victoria", "Aaron", "Lily",
                "Lucas", "Zoe", "Adam", "Brooklyn", "Brian", "Natalie",
                "Kevin", "Hannah", "Kyle", "Layla", "Brandon", "Leah",
                "Charles", "Allison", "Eric", "Samantha", "Jack", "Vanessa",
                "Sean", "Kaitlyn", "Joe", "Savannah", "Elijah", "Audrey",
                "Owen", "Riley", "Carter", "Zoey", "Connor", "Julia",
                "Luke", "Sophie", "Hunter", "Aria", "Cameron", "Ruby",
                "Dylan", "Kaylee", "Riley", "Alexa", "Leo", "Peyton",
                "Julian", "Bella", "Aaron", "Gabriella", "Adrian", "Penelope"
            };

            //intialize an array of 100 random last names
            lastNames = new[] 
            {
                "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson",
                "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris",
                "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez",
                "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King",
                "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez",
                "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Phillips",
                "Campbell", "Parker", "Evans", "Edwards", "Collins", "Stewart", "Sanchez",
                "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey",
                "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres",
                "Peterson", "Gray", "Ramirez", "James", "Watson", "Brooks", "Kelly",
                "Sanders", "Price", "Bennett", "Wood", "Barnes", "Ross", "Henderson",
                "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes",
                "Flores", "Washington", "Butler", "Simmons", "Foster", "Gonzales", "Bryant",
                "Alexander", "Russell", "Griffin", "Diaz", "Hayes"
            };

            //initialize an array of 50 random area codes
            areaCodes = new[]
            {
                "202", "305", "310", "312", "404", "415", "512", "617", "646", "702",
                "212", "213", "214", "253", "301", "408", "503", "518", "614", "703",
                "215", "216", "281", "314", "323", "407", "509", "515", "615", "704",
                "217", "219", "303", "315", "330", "410", "510", "516", "618", "707",
                "218", "220", "304", "316", "331", "412", "520", "530", "619", "708"
            };

            InitializeComponent();

            //initialize the ListView columns
            InitializeListViewColumns();

            //set the initial state of the "Clear List" button
            btnClearList.Enabled = false;

            //set the initial state of the "Create Contact(s) in Dataverse" button
            btnAddNamesToCRM.Enabled = false;
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// This event occurs when the plugin is closed
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// This event occurs when the connection has been updated in XrmToolBox
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void InitializeListViewColumns()
        {
            lvGeneratedNames.Columns.Clear();
            //column names and column pixel widths
            lvGeneratedNames.Columns.Add("First Name", 65);
            lvGeneratedNames.Columns.Add("Last Name", 75);
            lvGeneratedNames.Columns.Add("Birthdate", 75);
            lvGeneratedNames.Columns.Add("Phone Number", 85);
        }
        
        private void UpdateStatus(string message, bool isError = false)
        {
            lblStatusMessage.ForeColor = isError ? Color.Red : Color.Lime;
            lblStatusMessage.Text = message;
            //reset and start the timer each time the status is updated
            ResetAndStartTimer();
        }

        private void ResetAndStartTimer()
        {
            timerStatus.Stop();
            timerStatus.Interval = TimerInterval;
            timerStatus.Start();
        }

        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            //reset the status message to blank
            lblStatusMessage.Text = "";
            //stop the timer after clearing the message
            timerStatus.Stop();
        }

        private string GenerateRandomName()
        {
            string firstName = firstNames[rand.Next(firstNames.Length)];
            string lastName = lastNames[rand.Next(lastNames.Length)];
            return $"{firstName} {lastName}";
        }

        private DateTime GenerateRandomBirthdate()
        {
            //define the range of years
            int startYear = 1950;
            int endYear = 2000;

            //generate a random year, month and day
            int year = rand.Next(startYear, endYear + 1);
            int month = rand.Next(1, 13); // 1 to 12
            int day = rand.Next(1, DateTime.DaysInMonth(year, month) + 1); // 1 to 28/29/30/31

            return new DateTime(year, month, day);
        }

        private string GenerateRandomPhoneNumber()
        {
            //randomly select an area code
            string areaCode = areaCodes[rand.Next(areaCodes.Length)];

            //generate the remaining 7 digits of the phone number
            //generates a number between 1000000 and 9999999
            int numberPart = rand.Next(1000000, 10000000);

            //combine area code and number
            return $"{areaCode}{numberPart}";
        }

        private void BtnGenerateRandomNames_Click(object sender, EventArgs e)
        {
            //retrieve the number of names to generate from the NumericUpDown control and populate the ListView
            int numberOfNamesToGenerate = (int)numNameCount.Value;
            PopulateListView(numberOfNamesToGenerate);
            //update the status message
            UpdateStatus("Ready.", false);
        }

        private void PopulateListView(int numberOfNames)
        {
            lvGeneratedNames.Items.Clear();

            for (int i = 0; i < numberOfNames; i++)
            {
                string fullName = GenerateRandomName();
                DateTime birthdate = GenerateRandomBirthdate();
                string phoneNumber = GenerateRandomPhoneNumber();

                //split the full name into first and last names
                string[] nameParts = fullName.Split(' ');

                //create a new ListViewItem with the first name
                ListViewItem item = new ListViewItem(nameParts[0]);

                //add the last name as a subitem while checking to see if the last name exists
                item.SubItems.Add(nameParts.Length > 1 ? nameParts[1] : string.Empty);

                //add the birth date and format the date as "01-01-2023"
                item.SubItems.Add(birthdate.ToString("MM-dd-yyyy"));

                //add the phone number
                item.SubItems.Add(phoneNumber);

                //add the item to the ListView
                lvGeneratedNames.Items.Add(item);
            }

            //update the state of the "Clear List" button
            btnClearList.Enabled = true;

            //update the state of the "Create Contact(s) in Dataverse" button
            btnAddNamesToCRM.Enabled = true;
        }

        private void BtnAddNamesToCrm_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvGeneratedNames.Items)
            {
                //first name from the ListViewItem
                string firstName = item.Text;
                //last name from the ListViewItem
                string lastName = item.SubItems[1].Text;
                //birthdate from the ListViewItem
                string birthdateString = item.SubItems[2].Text;
                //phone number from the ListViewItem
                string phoneNumberString = item.SubItems[3].Text; 

                //convert the birthdate string to DateTime
                DateTime birthdate = DateTime.ParseExact(birthdateString, "MM-dd-yyyy", CultureInfo.InvariantCulture);

                //call the method to create a contact in Dataverse
                CreateContactInCrm(firstName, lastName, birthdate, phoneNumberString);
            }
      
            //disable the "Create Contact(s) in Dataverse" button since the contacts have just been created in Dataverse
            btnAddNamesToCRM.Enabled = false;
        }

        private void CreateContactInCrm(string firstName, string lastName, DateTime birthdate, string phoneNumber)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Creating contact(s) in Dataverse...",
                Work = (worker, args) =>
                {
                    //this code is executed in another thread
                    Entity newContact = new Entity("contact");
                    newContact["firstname"] = firstName;
                    newContact["lastname"] = lastName;
                    newContact["birthdate"] = birthdate;
                    newContact["address1_telephone1"] = phoneNumber;

                    //use the Dataverse service client to create the contact in Dataverse
                    Guid contactId = Service.Create(newContact);
                    args.Result = contactId;
                },

                /*
                ProgressChanged = e =>
                {
                    //update UI to indicate progress, if needed
                    SetWorkingMessage(e.UserState.ToString()); 
                }
                */

                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        //handle any errors that occurred during the operation
                        MessageBox.Show($"An error occurred: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //this code is executed in the main thread after the background work is completed
                        //Guid contactId = (Guid)e.Result;
                        //UpdateStatus($"Contact created with ID: {contactId}");
                        if (numNameCount.Value == 1)
                        {
                            UpdateStatus($"Success! Created {numNameCount.Value} contact in Dataverse.", false);
                        }
                        else
                        {
                            UpdateStatus($"Success! Created {numNameCount.Value} contacts in Dataverse.", false);
                        }
                    }
                }
            });
        }

        private void BtnClearList_Click(object sender, EventArgs e)
        {
            //clear the ListView
            lvGeneratedNames.Items.Clear();

            //update the status message to inform the user that the list has been cleared
            UpdateStatus("List cleared.", false);

            //update the state of the "Clear List" button
            btnClearList.Enabled = false;

            //update the state of the "Create Contact(s) in Dataverse" button
            btnAddNamesToCRM.Enabled = false;
        }
    }
}