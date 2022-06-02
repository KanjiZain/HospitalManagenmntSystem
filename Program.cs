using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t*****************************************");
            Console.WriteLine("\t\t\t\t\t\t Welcome To Hospital Managenment System");
            Console.WriteLine("\t\t\t\t\t\t*****************************************");

            //login function
            login();

            //main menu function
            menu();

            //declaring array 
            string[] name = new string[100];
            string[] name2 = new string[100];
            string[] number = new string[100];
            string[] number2 = new string[100];
            string[] disease = new string[100];
            string[] disease2 = new string[100];
            string[] doctor = new string[100];
            string[] doctor2 = new string[100];
            string[] date = new string[100];
            string[] shift = new string[100];
            string[] shift2 = new string[100];
            int size = 0;

            char ch = Convert.ToChar(Console.ReadLine());

            //checking ch
            if (ch == '1')
            {
                //go to Appointment department
                appointment(name, number, disease, doctor, size, shift);
                bill(shift, name, size);
                size++;
                Console.WriteLine("");

                // ask again 
                Console.WriteLine("Press 1 to add More Records \tPress 2 For See Appointment Records \tPress 3 For Exit");
                char again = Convert.ToChar(Console.ReadLine());
                //go to appointment entery department
                while (again == '1' || again == '1')
                {
                    appointment(name, number, disease, doctor, size, shift);
                    bill(shift, name, size);
                    size++;
                    Console.WriteLine("Press y For Enter More Record \t Press 2 For See Appointment Records \t Press 4 For Exit ");
                    again = Convert.ToChar(Console.ReadLine());
                }

                //writing data in file
                string path = @"/Users/hasnainkanji/Desktop/Zain/C1/Filing/name.txt";
                File.WriteAllLines(path, name);
                string path1 = @"/Users/hasnainkanji/Desktop/Zain/C1/Filing/doctor.txt";
                File.WriteAllLines(path1, doctor);
                string path2 = @"/Users/hasnainkanji/Desktop/Zain/C1/Filing/diseas.txt";
                File.WriteAllLines(path2, disease);
                string path3 = @"/Users/hasnainkanji/Desktop/Zain/C1/Filing/number.txt";
                File.WriteAllLines(path3, number);
                string path4 = @"/Users/hasnainkanji/Desktop/Zain/C1/Filing/shit.txt";
                File.WriteAllLines(path4, shift);

                //read data in file
                name2 = File.ReadAllLines(path);
                doctor2 = File.ReadAllLines(path1);
                disease2 = File.ReadAllLines(path2);
                number2 = File.ReadAllLines(path3);
                shift2 = File.ReadAllLines(path4);

                //go to appointmentRecord department
                if (again == '2')
                {
                    appointmentRecord(name2, disease2, doctor2, size, shift2, number2);
                    Console.WriteLine("\n Press any key to exit");
                }
                else if (again == '3')
                {
                    menu();
                }
            }

            else if (ch == '2')
            {
                FindDoctor();
                Console.WriteLine("\n Press any key to exit");
            }

            else if (ch == '3')
            {
                pharmacy();
                Console.WriteLine("\n Press any key to exit");
            }

            Console.ReadLine();
        }

        //login function
        public static void login()
        {
            Console.WriteLine("Enter Staff Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter Your Password: ");
            string paswrd = Console.ReadLine();
        }

        //this is main menu
        public static void menu()
        {
            Console.WriteLine("\t\t\t\t\t\t\t********************************");
            Console.WriteLine("\t\t\t\t\t\t\t\tManagenment System");
            Console.WriteLine("\t\t\t\t\t\t\t********************************");

            Console.WriteLine("<-----Controler----->");
            Console.WriteLine("\n=> Enter 1 to go in Appoitnment Departnment");
            Console.WriteLine("=> Enter 2 to see List of Doctors with Schedule");
            Console.WriteLine("=> Enter 3 to go in Pharmacy Departnment");
        }

        //pharmacy function
        public static void pharmacy()
        {
            Console.WriteLine("\t\tWelcome to Pharmacy Departnment");
            Console.WriteLine("\n\nEnter 1 to see list of medicines");
            Console.WriteLine("Enter 2 to update list of things");
            Console.WriteLine("Press 3 to search in the list of Medicines");
            int phd = Convert.ToInt32(Console.ReadLine());


            if (phd == 1)
            {
                medicine();
            }

            else if (phd == 2)
            {
                required();
            }

            else if (phd == 3)
            {
                search();
            }

            Console.ReadLine();
        }

        //medicine function
        public static void medicine()
        {

            string text = System.IO.File.ReadAllText(@"/Users/hasnainkanji/Desktop/Zain/Files of Project/List.txt");
            System.Console.WriteLine(text);

        }

        //search function
        public static void search()
        {
            string path = @"/Users/hasnainkanji/Desktop/Zain/C1/Filing/List.txt";

            if (File.Exists(@"/Users/hasnainkanji/Desktop/Zain/C1/Filing/List.txt"))
            {
                Console.WriteLine("\nFile Exsist");
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                System.IO.StreamReader sr = new StreamReader(fs);
                string record;
                string input;
                Console.WriteLine("\nEnter the text you want to search");
                input = Console.ReadLine();

                record = sr.ReadLine();
                while (record != null)
                {
                    if (record.Contains(input))
                    {
                        Console.WriteLine("Word Exsist");
                        break;
                    }

                    record = sr.ReadLine();

                }
                Console.ReadLine();
                sr.Close();
            }
            else
            {
                Console.WriteLine("file doesnot exsist");
                Console.WriteLine("\n Press any key to exit");

            }
        }

        //update function
        public static void required()
        {

            Console.WriteLine("\npress 1 to see list of the things");
            Console.WriteLine("press 2 to update the file");
            char required1 = Convert.ToChar(Console.ReadLine());

            if (required1 == '1')
            {
                string text = System.IO.File.ReadAllText(@"/Users/hasnainkanji/Desktop/Zain/C1/Filing/needs.txt");
                System.Console.WriteLine(text);
                Console.WriteLine("\n Press any key to exit");
            }

            else if (required1 == '2')
            {
                using (System.IO.StreamWriter file =
       new System.IO.StreamWriter(@"/Users/hasnainkanji/Desktop/Zain/C1/Filing/needs.txt", true))
                {
                    Console.WriteLine("Enter the thing u need to update");
                    string update = Console.ReadLine();
                    file.WriteLine(update);
                    file.Close();

                    Console.WriteLine("do you want to read the file? y/n");
                    char required2 = Convert.ToChar(Console.ReadLine());

                    if (required2 == 'y')
                    {
                        string text = System.IO.File.ReadAllText(@"/Users/hasnainkanji/Desktop/Zain/C1/Filing/needs.txt");
                        System.Console.WriteLine(text);
                        file.Close();
                    }

                    else
                    {
                        required();
                    }
                }
            }
        }

        //doctor department function 
        public static void FindDoctor()
        {

            Console.WriteLine("\n----------Find The Doctor----------");

            Console.WriteLine("\nChoose Your Specialist:");
            Console.WriteLine("\n1) Enter 1 for CARDIOLOGIST");
            Console.WriteLine("2) Enter 2 for DENTISTRY ");
            Console.WriteLine("3) Enter 3 for ENT SPECIALIST");

            char dctropt = Convert.ToChar(Console.ReadLine());

            if (dctropt == '1')
            {
                Console.WriteLine("\nChoose The Doctor You Want");
                Console.WriteLine("\n\n1) Enter 1 for AAMIR HAMEED KHAN");
                Console.WriteLine("2) Enter 2 for DR. OSMAN FAHEEM ");
                Console.WriteLine("3) Enter 3 for TAJUDDIN PATEL");
                Console.WriteLine("Press 4 to go Back");

                char dctropt1 = Convert.ToChar(Console.ReadLine());

                if (dctropt1 == '1')
                {
                    Console.WriteLine("\n\t\t\tWelcome To Dr.AAMIR HAMEED KHAN ");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char aamir = Convert.ToChar(Console.ReadLine());

                    if (aamir == '1')
                    {
                        Console.WriteLine("\n\nAAMIR HAMEED KHAN");
                        Console.WriteLine("Associate Professor");
                        Console.WriteLine("Cardiology");
                        Console.WriteLine("Cardiac Electrophysiology (arrhythmia, pacemakers, defibrillators)");
                        Console.WriteLine("FCPS (Cardiology),FCPS (Medicine),MBBS");
                    }

                    else if (aamir == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\tDay \t\t\tTime");
                        Console.WriteLine("CC Nazerali Walji Building \t\tMonday	\t\t17:00");
                        Console.WriteLine("Tele-Cardiology Clinic	\t\tThursday	\t14:30");
                    }

                    else if (aamir == '3')
                    {
                        FindDoctor();
                    }
                }


                else if (dctropt1 == '2')
                {
                    Console.WriteLine("\n\t\t\tWelcome To DR. OSMAN FAHEEM ");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");

                    char osama = Convert.ToChar(Console.ReadLine());

                    if (osama == '1')
                    {
                        Console.WriteLine("\n\nDR. OSMAN FAHEEM");
                        Console.WriteLine("Assistant Professor");
                        Console.WriteLine("Cardiology");
                        Console.WriteLine("Cardiology Medicine");
                        Console.WriteLine("MBBS");
                    }

                    else if (osama == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\tDay \t\t\tTime");
                        Console.WriteLine("CLIFTON MEDICAL SERVICES \tThursday	\t14:00");
                        Console.WriteLine("Tele-Cardiology Clinic	\tSaturday	\t16:00");
                    }

                    else if (osama == '3')
                    {
                        FindDoctor();
                    }
                }

                else if (dctropt1 == '3')
                {
                    Console.WriteLine("\n\t\t\tWelcome To TAJUDDIN PATEL ");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");

                    char patel = Convert.ToChar(Console.ReadLine());

                    if (patel == '1')
                    {
                        Console.WriteLine("\n\nDR. OSMAN FAHEEM");
                        Console.WriteLine("Consultant");
                        Console.WriteLine("Cardiology");
                        Console.WriteLine("General Non Invasive Cardiology");
                        Console.WriteLine("MBBS, Diploma in Cardiology");
                    }

                    else if (patel == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\tDay \t\tTime");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	Monday	\t13:30");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	Wednesday	13:30");
                    }

                    else if (patel == '3')
                    {
                        FindDoctor();
                    }
                }

                else if (dctropt1 == '4')
                {
                    FindDoctor();
                }
            }

            else if (dctropt == '2')
            {
                Console.WriteLine("\nChoose The Doctor You Want");
                Console.WriteLine("\n\n1) Enter 1 for ROBIA GHAFOOR");
                Console.WriteLine("2) Enter 2 for FAHAD UMER ");
                Console.WriteLine("3) Enter 3 for MAHDAV RAJPUT");
                Console.WriteLine("Press 4 to go Back");

                char dctropt2 = Convert.ToChar(Console.ReadLine());


                if (dctropt2 == '1')
                {
                    Console.WriteLine("\n\t\t\tWelcome To ROBIA GHAFOOR ");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char robia = Convert.ToChar(Console.ReadLine());

                    if (robia == '1')
                    {
                        Console.WriteLine("\n\nDR. ROBIA GHAFOOR ");
                        Console.WriteLine("Assistant Professor");
                        Console.WriteLine("Dentistry");
                        Console.WriteLine("Operative Dentistry");
                        Console.WriteLine("BDS, FCPS (Operative Dentistry");
                    }

                    else if (robia == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\tDay \t\t\tTime");
                        Console.WriteLine("Dental Clinic Jena Bai Building 	Monday	 \t\t09:00");
                        Console.WriteLine("Dental Clinic Jena Bai Building 	Wednesday	   \t9:00");
                    }

                    else if (robia == '3')
                    {
                        FindDoctor();
                    }
                }

                if (dctropt2 == '2')
                {
                    Console.WriteLine("\n\t\t\tWelcome To FAHAD UMER");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char fahad = Convert.ToChar(Console.ReadLine());

                    if (fahad == '1')
                    {
                        Console.WriteLine("\n\nDR.FAHAD UMER");
                        Console.WriteLine("Assistant Professor & SL Chief");
                        Console.WriteLine("Dentistry");
                        Console.WriteLine("Operative Dentistry");
                        Console.WriteLine("BDS, FCPS (Operative Dentistry");
                    }

                    else if (fahad == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\tDay \t\tTime");
                        Console.WriteLine("GARDEN - Garden Diagnostic Centre \tTuesday	 \t12:00");
                        Console.WriteLine("GARDEN - Garden Diagnostic Centre	Saturday   \t8:00");
                    }

                    else if (fahad == '3')
                    {
                        FindDoctor();
                    }
                }

                if (dctropt2 == '3')
                {
                    Console.WriteLine("\n\t\t\tWelcome To MAHDAV RAJPUT");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char rajput = Convert.ToChar(Console.ReadLine());

                    if (rajput == '1')
                    {
                        Console.WriteLine("\n\nDR.MAHDAV RAJPUT");
                        Console.WriteLine("Consultant");
                        Console.WriteLine("Dentistry");
                        Console.WriteLine("Operative & Restorative Dentistry, Paediatric Dentistry");
                        Console.WriteLine("BDS, FCPS (Operative Dentistry");
                    }

                    else if (rajput == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\t\tDay \t\tTime");
                        Console.WriteLine("KHARADAR - Aga Khan Diagnostic Centre \t\tTuesday	 \t12:00");
                        Console.WriteLine("KHARADAR - Aga Khan Diagnostic Centre	\tSaturday  \t 8:00");
                    }

                    else if (rajput == '3')
                    {
                        FindDoctor();
                    }
                }

                else if (dctropt2 == '4')
                {
                    FindDoctor();
                }
            }

            else if (dctropt == '3')
            {
                Console.WriteLine("\nChoose The Doctor You Want");
                Console.WriteLine("\n\n1) Enter 1 for Dr. ATIF HAFEEZ");
                Console.WriteLine("2) Enter 2 for Dr . ANWAR SUHAIL");
                Console.WriteLine("3) Enter 3 for Dr. UNEEL KUMAR");
                Console.WriteLine("Press 4 to go Back");

                char dctropt3 = Convert.ToChar(Console.ReadLine());

                if (dctropt3 == '1')
                {
                    Console.WriteLine("\n\t\t\tWelcome To Dr.ATIF HAFEEZ");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char atif = Convert.ToChar(Console.ReadLine());

                    if (atif == '1')
                    {
                        Console.WriteLine("\n\nATIF HAFEEZ");
                        Console.WriteLine("Consultant");
                        Console.WriteLine("ENT");
                        Console.WriteLine("General Otolaryngology");
                        Console.WriteLine("FCPS (E.N.T),DLO,MBBS");
                    }

                    else if (atif == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\t\tDay \t\t\tTime");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	\t\tMonday	\t\t17:00");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	\t\tFriday	\t\t14:30");
                    }

                    else if (atif == '3')
                    {
                        FindDoctor();
                    }
                }

                else if (dctropt3 == '2')
                {
                    Console.WriteLine("\n\t\t\tWelcome To Dr . ANWAR SUHAIL");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char anwar = Convert.ToChar(Console.ReadLine());

                    if (anwar == '1')
                    {
                        Console.WriteLine("\n\nATIF HAFEEZ");
                        Console.WriteLine("Consultant");
                        Console.WriteLine("ENT");
                        Console.WriteLine("Endoscopic Nasal Surgery,Peadatric ENT,General Otolaryngology");
                        Console.WriteLine("FRCS (Edinburgh, UK),MBBS");
                    }

                    else if (anwar == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\t\tDay \t\t\tTime");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	\t\tMonday	\t\t17:00");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	\t\tFriday	\t\t14:30");
                    }

                    else if (anwar == '3')
                    {
                        FindDoctor();
                    }
                }

                else if (dctropt3 == '3')
                {
                    Console.WriteLine("\n\t\t\tWelcome To Dr. UNEEL KUMAR");

                    Console.WriteLine("\nPress 1 to see his Profile:  ");
                    Console.WriteLine("Press 2 to see his schedule");
                    Console.WriteLine("Press 3 to go back to doctors menu");
                    char kumar = Convert.ToChar(Console.ReadLine());

                    if (kumar == '1')
                    {
                        Console.WriteLine("\n\nUNEEL KUMAR");
                        Console.WriteLine("Consultant");
                        Console.WriteLine("ENT");
                        Console.WriteLine("General Otolaryngology");
                        Console.WriteLine("MBBS, DLO");
                    }

                    else if (kumar == '2')
                    {
                        Console.WriteLine("\nLocation \t\t\t\t\tDay \t\t\tTime");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	\t\tMonday	\t\t17:00");
                        Console.WriteLine("KARIMABAD - Karimabad Clinic	\t\tFriday	\t\t14:30");
                    }

                    else if (kumar == '3')
                    {
                        FindDoctor();
                    }
                }

                else if (dctropt3 == '4')
                {
                    FindDoctor();
                }
            }
        }


        //this is appointment entery department
        static string[] appointment(string[] name, string[] number, string[] disease,
        string[] doctor, int size, string[] shift)
        {
            Console.WriteLine("\n-------------Welcome To Appoitnment Departnment-----------");
            Console.WriteLine("\n\nEnter Patient's Name:");
            name[size] = Console.ReadLine();
            Console.WriteLine("\nEnter Patient's Disease:");
            disease[size] = Console.ReadLine();
            Console.WriteLine("\nEnter Doctor's name:");
            doctor[size] = Console.ReadLine();
            Console.WriteLine("\nEnter Shift: ");
            shift[size] = Console.ReadLine();
            Console.WriteLine("\nEnter Contact Number");
            number[size] = Console.ReadLine();

            return name;
        }

        //this is appointmentRecord department
        static void appointmentRecord(string[] name2, string[] disease2,
        string[] doctor2, int size, string[] shift2, string[] number2)
        {
            Console.WriteLine("\nPatient name \t disease \t doctor \t shift \t contact no");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("\n");
                Console.Write(name2[i]);
                Console.Write("\t\t{0}", disease2[i]);
                Console.Write("\t\t{0}", doctor2[i]);
                Console.Write("\t\t{0}", shift2[i]);
                Console.Write("\t\t{0}", number2[i]);
                Console.WriteLine("\n");
            }
        }
        //this is bill department
        static void bill(string[] shift, string[] name, int size)
        {
            Console.WriteLine("\n\t\tBILL");
            Console.WriteLine("------------------------------------------");
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString());
            Console.WriteLine("\nPatient Name: \t\t{0}", name[size]);
            Console.WriteLine("Shift: \t\t\t{0}", shift[size]);
            Console.WriteLine("Doctor Fees : \t {0}/- PKR", 500);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Total Amount : \t\t{0}", 500);
            Console.WriteLine("\n");
        }
    }
}