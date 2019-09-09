using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class GarageInterface
    {
        private readonly GarageLogic.Garage r_Garage;
        private bool m_GarageIsActive;

        public GarageInterface()
        {
            this.r_Garage = new GarageLogic.Garage();
            m_GarageIsActive = true;
        }

        public void StartService()
        {
            Console.WriteLine("Welcome to the number one garage service in the world!\n");
            while (m_GarageIsActive)
            {
                Console.WriteLine("Please choose the number of your desired service:\n");
                foreach (KeyValuePair<int, string> service in r_Garage.GarageServices)
                {
                    Console.WriteLine("{0}. {1}", service.Key, service.Value);
                }

                string chosenService = Console.ReadLine();
                chosenService = UIValidation.ValidateChoiceNumberInRange(1, r_Garage.GarageServices.Count, chosenService);
                PerformService(int.Parse(chosenService));
                Console.WriteLine();
                Console.Clear();
            }
        }

        public void PerformService(int i_ChosenService)
        {
            switch (i_ChosenService)
            {
                case 1:
                    insertNewVehicleToTheGarage();
                    break;
                case 2:
                    displayLicneseNumberListOfAllCarsInGarage();
                    break;
                case 3:
                    changingVeichleStatus();
                    break;
                case 4:
                    inflateWheelsToMaxAirPressureInVehicle();
                    break;
                case 5:
                    refeul();
                    break;
                case 6:
                    chargeElectricCar();
                    break;
                case 7:
                    displayAllReleventDataOfGivenVehicle();
                    break;
                case 8:
                    m_GarageIsActive = false;
                    Console.WriteLine("Thank you, bye bye");
                    Environment.Exit(0);
                    break;
            }
        }

        private void insertNewVehicleToTheGarage()
        {
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("Please Enter your full Name:");
                string customerFullName = UIValidation.ReadAndValidateNameFormat(Console.ReadLine());
                Console.WriteLine("Please Enter your phone Number:");
                string customerPhoneNumber = UIValidation.ReadValidateNumberSequence(Console.ReadLine(), 10);
                Console.WriteLine("What is the type of your vehicle?");
                Console.WriteLine(@"1.Fuel motorcycle
2.Electric motorcycle
3.Fuel car
4.Electric car
5.Truck");

                int optionNumber = 0;
                isValidInput = true;
                try
                {
                    int numOfVehiclesTypesGarageHandles = Enum.GetNames(typeof(GarageLogic.VehicleGenerator.eVehicleType)).Length;
                    optionNumber = int.Parse(UIValidation.ValidateChoiceNumberInRange(1, numOfVehiclesTypesGarageHandles, Console.ReadLine()));
                    GarageLogic.VehicleGenerator.eVehicleType vehicleType = (GarageLogic.VehicleGenerator.eVehicleType)optionNumber;
                    GarageLogic.VehicleGenerator vehicleGenerator = new GarageLogic.VehicleGenerator();
                    Dictionary<string, string> vehicleDictionary = vehicleGenerator.CreateSuitableVehicleDictionary(vehicleType);
                    updateDictionary(vehicleDictionary);
                    GarageLogic.Vehicle costumerVehicle = vehicleGenerator.CreateNewVehicle(vehicleType, vehicleDictionary);
                    bool isAlreadyInGarage = r_Garage.AddANewVehicle(costumerVehicle, customerFullName, customerPhoneNumber);
                    if (!isAlreadyInGarage)
                    {
                        Console.WriteLine(@"Your vehicle has been added to the garage!");
                    }
                    else
                    {
                        Console.WriteLine(@"Your vehicle already exists in our system.");
                    }
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                    isValidInput = false;
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                    isValidInput = false;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    isValidInput = false;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private void displayLicneseNumberListOfAllCarsInGarage()
        {
            Console.WriteLine("Would you like to see specific status of cars? choose from options below:");
            Console.WriteLine(@"1. In repair
2. Fixed and unpaid
3. Fixed and paid
4. All");
                try
                {
                    string answer = UIValidation.ValidateChoiceNumberInRange(1, 4, Console.ReadLine());
                    string licenseNumbertoDisplay = r_Garage.FilterLicneseNumberByGarageStatus(answer);
                    if (licenseNumbertoDisplay.Equals(string.Empty) && answer.Equals("4"))
                    {
                        Console.WriteLine("No Cars in the garage at the moment!");
                    }
                    else if (licenseNumbertoDisplay.Equals(string.Empty))
                    {
                        Console.WriteLine("No Cars with this status in the garage at the moment!");
                    }
                    else
                    {
                        Console.WriteLine(licenseNumbertoDisplay);
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

            Console.ReadLine();
        }

        private void changingVeichleStatus()
        {
            string customerLicenceNumber = getCustomerLicence();
            Console.WriteLine("Enter your desired status to update. choose from options below:");
            Console.WriteLine(@"1. In repair
2. Fixed and unpaid
3. Fixed and paid");
                try
                {
                    string answer = UIValidation.ValidateChoiceNumberInRange(1, 3, Console.ReadLine());
                    r_Garage.UpdateVehicleStatus(customerLicenceNumber, answer);
                    Console.WriteLine(@"Status updated as your request!");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

            Console.ReadLine();
        }


        private void inflateWheelsToMaxAirPressureInVehicle()
        {
            string customerLicenceNumber = getCustomerLicence();
            try
            {
                r_Garage.InflateWheelsToMaxAirPressure(customerLicenceNumber);
                Console.WriteLine("All wheels inflated to max pressure!");
            }

            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void refeul()
        {
            string customerLicenceNumber = getCustomerLicence();
            Console.WriteLine("Which type of fuel you want refuel? choose from options below:");
            Console.WriteLine(@"1. Soler
2. Octan95
3. Octan96
4. Octan98");
            try
            {
                string answer = Console.ReadLine();
                answer = UIValidation.ValidateChoiceNumberInRange(1, 4, answer);
                Console.WriteLine("How much fuel do you want to fill?");
                string amountOfFuel = Console.ReadLine();
                r_Garage.Refuel(customerLicenceNumber, answer, amountOfFuel);
                Console.WriteLine("Refuled successfully!");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void chargeElectricCar()
        {
            string customerLicenceNumber = getCustomerLicence();
            Console.WriteLine("Please enter number of minutes you'd like to charge:");
            string minutesToCharge = Console.ReadLine();
            try
            {
                r_Garage.Recharge(customerLicenceNumber, minutesToCharge);
                Console.WriteLine("Recharged successfully!");
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private void displayAllReleventDataOfGivenVehicle()
        {
            string customerLicenceNumber = getCustomerLicence();
            try
            {
                Console.WriteLine(r_Garage.DisplayVeichelData(customerLicenceNumber));
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private static void updateDictionary(Dictionary<string, string> io_VehicleDictionary)
        {
            Dictionary<string, string> VehicleDictionary = new Dictionary<string, string>();
            foreach (string key in io_VehicleDictionary.Keys)
            {
                VehicleDictionary.Add(key, null);
            }

            foreach (string key in VehicleDictionary.Keys)
            {
                Console.WriteLine("Please enter " + key);
                io_VehicleDictionary[key] = Console.ReadLine();
            }
        }

        private static string getCustomerLicence()
        {
            Console.WriteLine("Please enter your licence number, 8 digits:");

            return UIValidation.ReadValidateNumberSequence(Console.ReadLine(), 8);
        }
    }
}
