using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*
 * by Mark Hawes
 * Week 11
 * 
 * StudentGradeDemo - Program to demonstrate the use of exception handling
 * 
 * I'd like to thank Microsoft for their documentation of the ArgumentException
 * without which I wouldn't have been able to make this error as pretty as I did.
 * Microsoft documentation you the real MVP.
 */ 

namespace StudentGradeDemo
{
    /****************
     * main program *
     ****************/
    class Program
    {
        private static string[] names = { "Jeremy", "Courtney", "Morgen",
        "J.D." };
        private static int[] midterms = { 90, 75, -10, 82 };
        private static int[] finals = { 92, 88, 90, 104 };

        // main method
        static void Main(string[] args)
        {
            // create a new report card object for each test/tester
            for(int i = 0; i < names.Length; i++)
            {
                try
                {
                    ReportCard test = new ReportCard(names[i], midterms[i],
                        finals[i]);

                    WriteLine("{0} scored {1} on midterm, and {2} on final " +
                        "exam, giving them a letter grade of {3}", test.Name, 
                        test.MidtermGrade, test.FinalExamGrade, test.LetterGrade);
                } catch(ArgumentException e)
                {
                    WriteLine("{0} thrown: {1}. At test {2}", e.GetType().Name, 
                        e.Message, (i + 1).ToString());
                } // end try/catch
            } // end for

            // spaces for formatting!
            Write("\n\n");

            // start user created test for exceptions
            UserCreatedTest();

            // stop program from auto closing the console
            StopAutoClose();
        } // end Main

        static void UserCreatedTest()
        {
            string name;
            int midterm, final;

            try
            {
                WriteLine("Enter student's name: ");
                name = ReadLine();

                WriteLine("Enter student's midterm score: ");
                midterm = Convert.ToInt32(ReadLine());

                WriteLine("Enter student's final exam score: ");
                final = Convert.ToInt32(ReadLine());

                ReportCard userTest = new ReportCard(name, midterm, final);
            } catch (FormatException d)
            {
                WriteLine("{0} thrown: {1}.", d.GetType().Name,
                        d.Message);
            } catch (ArgumentException e)
            {
                WriteLine("{0} thrown: {1}.", e.GetType().Name,
                        e.Message);
            } // end try/catch
        } // end UserCreatedTest


        // StopAutoClose - stops console window from closing automatically
        static void StopAutoClose()
        {
            Write("\n\nPress 'Enter' to close program\n");
            ReadLine();
        }
    } // end class Program



    /************************************************************
     * ReportCard class holds the report card for a student     *
     * based on midterm and final exam grades                   *
     ************************************************************/
    class ReportCard
    {
        private string name;
        private char letterGrade;
        private int midtermGrade, finalExamGrade;
    
        /********************
         * main constructor *
         ********************/
        public ReportCard(string nameInput, int midtermInput, int finalExamInput)
        {
            Name = nameInput;

            MidtermGrade = midtermInput;
            FinalExamGrade = finalExamInput;

            CalculateLetterGrade();
        } // end constructor

        /**********************
         * name getter/setter *
         **********************/
        public string Name
        {
            get { return name; }
            set { name = value; }
        } // end Name

        /*******************************
         * midtermGrade getter/setter  *
         *******************************/
        public int MidtermGrade
        {
            get { return midtermGrade; }
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("Midterm grade entered is invalid!");
                } // end if
                else
                    midtermGrade = value;
            }
        } // end MidtermGrade

        /*********************************
         * finalExamGrade getter/setter  *
         *********************************/
        public int FinalExamGrade
        {
            get { return finalExamGrade; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Final exam grade entered is invalid!");
                } // end if
                else
                    finalExamGrade = value;
            }
        } // end FinalExamGrade

        /******************************
         * letterGrade getter/setter  *
         ******************************/
        public char LetterGrade
        {
            get { return letterGrade; }
            set { letterGrade = value; }
        } // end LetterGrade

        /***************************************************************************
         * calculates final exam based on average of midterm and final exam grades *
         ***************************************************************************/
        private void CalculateLetterGrade()
        {
            int finalGrade = (MidtermGrade + FinalExamGrade) / 2; // get average grade

            if (finalGrade >= 90)
                LetterGrade = 'A';
            else if (finalGrade < 90 && finalGrade >= 80)
                LetterGrade = 'B';
            else if (finalGrade < 80 && finalGrade >= 70)
                LetterGrade = 'C';
            else if (finalGrade < 70 && finalGrade >= 60)
                LetterGrade = 'D';
            else
                LetterGrade = 'F';
        } // end CalculateLetterGrade
    } // end class ReportCard
}
