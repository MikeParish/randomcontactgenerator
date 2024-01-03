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

        public MyPluginControl()
        {
            //an array of 100 random first names
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

            //an array of 100 random last names
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

            //an array of 50 random area codes
            areaCodes = new[]
            {
                "202", "305", "310", "312", "404", "415", "512", "617", "646", "702",
                "212", "213", "214", "253", "301", "408", "503", "518", "614", "703",
                "215", "216", "281", "314", "323", "407", "509", "515", "615", "704",
                "217", "219", "303", "315", "330", "410", "510", "516", "618", "707",
                "218", "220", "304", "316", "331", "412", "520", "530", "619", "708"
            };

            InitializeComponent();

            //initialize the listview columns
            InitializeListViewColumns();

            //update the initial state of the clear list button
            UpdateClearButtonState();

            //update the initial state of the add contact(s) to dataverse button
            UpdateAddContactsButtonState();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

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
            //names and widths of the columns
            lvGeneratedNames.Columns.Add("First Name", 65);
            lvGeneratedNames.Columns.Add("Last Name", 75);
            lvGeneratedNames.Columns.Add("Birth Date", 75);
            lvGeneratedNames.Columns.Add("Phone Number", 85);
        }
        
        //status message logic
        private void UpdateStatus(string message, bool isError = false)
        {
            lblStatusMessage.ForeColor = isError ? Color.Red : Color.DarkSeaGreen;
            lblStatusMessage.Text = message;
        }
        
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // capture user input from text boxes
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;

                // validation: check if both fields are empty
                if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                {
                    UpdateStatus("Please enter at least a First Name or a Last Name.", true);
                    return;
                }

                // data submission logic
                if (Service != null)
                {
                    // create a new entity object for a contact
                    Entity contact = new Entity("contact");

                    // add attributes for first name and last name
                    if (!string.IsNullOrEmpty(firstName))
                    {
                        contact["firstname"] = firstName;
                    }

                    if (!string.IsNullOrEmpty(lastName))
                    {
                        contact["lastname"] = lastName;
                    }

                    try
                    {
                        // create the new contact record in CRM
                        Guid contactId = Service.Create(contact);

                        // Optional: Perform additional actions with the contactId if needed

                        UpdateStatus("Contact created successfully with ID: " + contactId.ToString());
                    }
                    catch (Exception ex)
                    {
                        UpdateStatus($"Error creating contact: {ex.Message}", true);
                    }
                }
                else
                {
                    UpdateStatus("CRM connection is not established.", true);
                }

                UpdateStatus("Data created successfully!");
                timerStatus.Start(); // start the timer to clear the message later
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error: {ex.Message}", true);
            }
        }
        

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            lblStatusMessage.Text = ""; // reset the status message to blank
            timerStatus.Stop(); // stop the timer after clearing the message
        }

        private string GenerateRandomName()
        {
            string firstName = firstNames[rand.Next(firstNames.Length)];
            string lastName = lastNames[rand.Next(lastNames.Length)];
            return $"{firstName} {lastName}";
        }

        private DateTime GenerateRandomBirthdate()
        {
            // Define the range of years
            int startYear = 1950;
            int endYear = 2000;

            // Generate a random year, month, and day
            int year = rand.Next(startYear, endYear + 1);
            int month = rand.Next(1, 13); // 1 to 12
            int day = rand.Next(1, DateTime.DaysInMonth(year, month) + 1); // 1 to 28/29/30/31

            return new DateTime(year, month, day);
        }

        private string GenerateRandomPhoneNumber()
        {
            // Randomly select an area code
            string areaCode = areaCodes[rand.Next(areaCodes.Length)];

            // Generate the remaining 7 digits of the phone number
            int numberPart = rand.Next(1000000, 10000000); // Generates a number between 1000000 and 9999999

            // Combine area code and number
            return $"{areaCode}{numberPart}";
        }

        private void btnGenerateRandomNames_Click(object sender, EventArgs e)
        {
            // Retrieve the number of names to generate from the NumericUpDown control
            int numberOfNamesToGenerate = (int)numNameCount.Value;
            PopulateListView(numberOfNamesToGenerate);
            UpdateStatus("Ready", false);
        }

        private void PopulateListView(int numberOfNames)
        {
            lvGeneratedNames.Items.Clear();

            for (int i = 0; i < numberOfNames; i++)
            {
                string fullName = GenerateRandomName();
                DateTime birthdate = GenerateRandomBirthdate();
                string phoneNumber = GenerateRandomPhoneNumber();

                // Split the full name into first and last names
                string[] nameParts = fullName.Split(' ');

                // Create a new ListViewItem with the first name
                ListViewItem item = new ListViewItem(nameParts[0]);

                // Add the last name as a subitem while checking to see if the last name exists
                item.SubItems.Add(nameParts.Length > 1 ? nameParts[1] : string.Empty);

                // Add the birth date and format the date as "01-01-2023"
                item.SubItems.Add(birthdate.ToString("MM-dd-yyyy"));

                //add the phone number
                item.SubItems.Add(phoneNumber);

                // Add the item to the ListView
                lvGeneratedNames.Items.Add(item);
            }
                
        // Update the state of the Clear List button
        UpdateClearButtonState();

        // Update the state of the Add Contacts to Dataverse button
        UpdateAddContactsButtonState();
        }

        private void btnAddNamesToCrm_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvGeneratedNames.Items)
            {
                string firstName = item.Text; // First name from the ListViewItem
                string lastName = item.SubItems[1].Text; // Last name from the ListViewItem
                string birthdateString = item.SubItems[2].Text; // Birthdate from the ListViewItem
                string phoneNumberString = item.SubItems[3].Text; //phone number from the listviewitem

                // Optional: Convert the birthdate string to DateTime
                DateTime birthdate = DateTime.ParseExact(birthdateString, "MM-dd-yyyy", CultureInfo.InvariantCulture);

                // Call the method to create a contact in CRM
                CreateContactInCrm(firstName, lastName, birthdate, phoneNumberString);
            }

            // Optional: Update the UI to indicate completion or clear the ListView
            if (numNameCount.Value == 1)
            {
                UpdateStatus($"Success! {numNameCount.Value} contact added to CRM", false);
            }
            else
            {
                UpdateStatus($"Success! {numNameCount.Value} contacts added to CRM", false);
            }
            
            btnAddNamesToCRM.Enabled = false;
            //start status message countdown back to blank
            timerStatus.Start();
        }

        private void CreateContactInCrm(string firstName, string lastName, DateTime birthdate, string phoneNumber)
        {
            // Create a new CRM contact entity
            Entity newContact = new Entity("contact");
            newContact["firstname"] = firstName;
            newContact["lastname"] = lastName;
            newContact["birthdate"] = birthdate;
            newContact["address1_telephone1"] = phoneNumber;

            // Use your CRM service client to create the contact in CRM
            Guid contactId = Service.Create(newContact);
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lvGeneratedNames.Items.Clear();

            // Optionally, update the status to inform the user that the list has been cleared
            UpdateStatus("List cleared", false);
            //start status message countdown back to blank
            timerStatus.Start();

            // Update the state of the Clear List button
            UpdateClearButtonState();

            // Update the state of the Add Contacts to CRM button
            UpdateAddContactsButtonState();
        }

        private void UpdateClearButtonState()
        {
            btnClearList.Enabled = lvGeneratedNames.Items.Count > 0;
        }

        private void UpdateAddContactsButtonState()
        {
            btnAddNamesToCRM.Enabled = lvGeneratedNames.Items.Count > 0;
        }
    }
}