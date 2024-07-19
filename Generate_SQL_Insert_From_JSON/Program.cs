using Newtonsoft.Json;

namespace Generate_SQL_Insert_From_JSON
{
    internal class Program
    {
        // link to get JSON data: https://randomuser.me/api/?results=1000&nat=us        
        static void Main(string[] args)
        {
            string filePathRead = "MyJSON.txt";
            string filePathWrite = "InsertStatements.txt";
            string database = "Contacts";

            try
            {
                string fileContent = File.ReadAllText(filePathRead);

                var randomUsers = JsonConvert.DeserializeObject<dynamic>(fileContent);

                if (randomUsers != null)
                {
                    using (StreamWriter streamWriter = new StreamWriter(filePathWrite))
                    {

                        foreach (var user in randomUsers)
                        {
                            string firstName = user.name.first;
                            string lastName = user.name.last;
                            string phone = user.phone;
                            string state = user.location.state;
                            string stateAbbreviation = GetStateAbbreviation(state);
                            string address = user.location.street.number + " " + user.location.street.name + ", " + user.location.city + ", " + stateAbbreviation + " " + user.location.postcode;
                            // string address = user.location.street.number + " " + user.location.street.name + ", " + user.location.city + ", " + user.location.state + ", " + user.location.country + ", " + user.location.postcode;

                            string insertStatement = $"INSERT INTO {database} (FirstName, LastName, Phone, Address) VALUES ('{firstName}','{lastName}','{phone}','{address}');";

                            Console.WriteLine(insertStatement);

                            streamWriter.WriteLine(insertStatement);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no data in the file");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static string GetStateAbbreviation(string state)
        {
            state = state.Trim();
            switch (state)
            {
                case "Alabama": return "AL";
                case "Alaska": return "AK";
                case "Arkansas": return "AR";
                case "Arizona": return "AZ";
                case "California": return "CA";
                case "Colorado": return "CO";
                case "Connecticut": return "CT";
                case "Delaware": return "DE";
                case "Florida": return "FL";
                case "Georgia": return "GA";
                case "Hawaii": return "HI";
                case "Idaho": return "ID";
                case "Illinois": return "IL";
                case "Indiana": return "IN";
                case "Iowa": return "IA";
                case "Kansas": return "KS";
                case "Kentucky": return "KY";
                case "Louisiana": return "LA";
                case "Maine": return "ME";
                case "Maryland": return "MD";
                case "Massachusetts": return "MA";
                case "Michigan": return "MI";
                case "Minnesota": return "MN";
                case "Mississippi": return "MS";
                case "Missouri": return "MO";
                case "Montana": return "MT";
                case "Nebraska": return "NE";
                case "Nevada": return "NV";
                case "New Hampshire": return "NH";
                case "New Jersey": return "NJ";
                case "New Mexico": return "NM";
                case "New York": return "NY";
                case "North Carolina": return "NC";
                case "North Dakota": return "ND";
                case "Ohio": return "OH";
                case "Oklahoma": return "OK";
                case "Oregon": return "OR";
                case "Pennsylvania": return "PA";
                case "Rhode Island": return "RI";
                case "South Carolina": return "SC";
                case "South Dakota": return "SD";
                case "Tennessee": return "TN";
                case "Texas": return "TX";
                case "Utah": return "UT";
                case "Vermont": return "VT";
                case "Virginia": return "VA";
                case "Washington": return "WA";
                case "West Virginia": return "WV";
                case "Wisconsin": return "WI";
                case "Wyoming": return "WY";
                default: return "";
            }
        }
    }
}
