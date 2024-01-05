using Microsoft.Xrm.Sdk;
using System;
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
        private readonly Random rand = new Random();

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

            InitializeComponent();

            //initialize the ListView columns
            InitializeListViewColumns();

            //disable the "Clear List" button
            btnClearList.Enabled = false;

            //disable the "Create Contact(s) in Dataverse" button
            btnCreateContactsInDataverse.Enabled = false;
        }

        private void CreateContactsInDataverse(string firstName, string lastName, DateTime birthdate, string phoneNumber)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Creating Contact(s) in Dataverse...",
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

                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        //handle any errors that occurred during the operation
                        MessageBox.Show($"An error occurred: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }

        private void InitializeListViewColumns()
        {
            lvGeneratedContacts.Columns.Clear();
            //column names and column pixel widths
            lvGeneratedContacts.Columns.Add("First Name", 65);
            lvGeneratedContacts.Columns.Add("Last Name", 75);
            lvGeneratedContacts.Columns.Add("Birthdate", 75);
            lvGeneratedContacts.Columns.Add("Phone Number", 85);
        }

        private string GenerateRandomFirstName()
        {
            return firstNames[rand.Next(firstNames.Length)];
        }

        private string GenerateRandomLastName()
        {
            return lastNames[rand.Next(lastNames.Length)];
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
            //generate the remaining 7 digits of the phone number
            //generates a number between 1000000 and 9999999
            int numberPart = rand.Next(1000000, 10000000);
            //combine fake area code and number
            return $"555{numberPart}";
        }

        private void PopulateListView(int numberOfContacts)
        {
            lvGeneratedContacts.Items.Clear();

            for (int i = 0; i < numberOfContacts; i++)
            {
                string firstName = GenerateRandomFirstName();
                string lastName = GenerateRandomLastName();
                DateTime birthdate = GenerateRandomBirthdate();
                string phoneNumber = GenerateRandomPhoneNumber();

                ListViewItem item = new ListViewItem(firstName);
                item.SubItems.Add(lastName);
                item.SubItems.Add(birthdate.ToString("MM-dd-yyyy")); //format the date as "01-01-2023"
                item.SubItems.Add(phoneNumber);
                //add the item to the ListView
                lvGeneratedContacts.Items.Add(item);
            }

            //enable the "Clear List" button
            btnClearList.Enabled = true;
            //enable the "Create Contact(s) in Dataverse" button
            btnCreateContactsInDataverse.Enabled = true;
        }
        
        //event handlers      
        private void BtnClearList_Click(object sender, EventArgs e)
        {
            //clear the ListView
            lvGeneratedContacts.Items.Clear();

            //disable the "Clear List" button
            btnClearList.Enabled = false;

            //disable the "Create Contact(s) in Dataverse" button
            btnCreateContactsInDataverse.Enabled = false;
        }

        private void BtnCreateContactsInDataverse_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvGeneratedContacts.Items)
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
                CreateContactsInDataverse(firstName, lastName, birthdate, phoneNumberString);
            }

            //disable the "Create Contact(s) in Dataverse" button since the contacts have just been created in Dataverse
            btnCreateContactsInDataverse.Enabled = false;
        }

        private void BtnGenerateRandomContacts_Click(object sender, EventArgs e)
        {
            //retrieve the number of names to generate from the NumericUpDown control and populate the ListView
            int numberOfContactsToGenerate = (int)numNameCount.Value;
            PopulateListView(numberOfContactsToGenerate);
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

        private void TsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
    }
}