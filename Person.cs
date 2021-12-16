/** 
 * Author1:  Philip Rönnmark 990513-4392 (phrinn-1@student.ltu.se) 
 * Course:   L0002B
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inlupp_3
{
    class Person
    {
        private string firstName;
        private string lastName;
        private string idNumber;


        public Person(string firstName, string lastName, string idNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.idNumber = idNumber;

        }

        /// <summary>
        /// display output
        /// </summary>
        /// <returns>Result if valid id number, and gender, and name</returns>
        public String checkPerson()
        {
            return displayResult(checkValidIdNumber(), checkIfMan());
        }

        /// <summary>
        /// Checks if id number is valid, removes all chars except numbers
        /// using the 21algorithm
        /// </summary>
        /// <returns></returns>
        private bool checkValidIdNumber()
        {
            string clean = Regex.Replace(idNumber, "[^0-9 ]", "");
            char[] id = clean.ToCharArray();
            int count = 0;
            int sum = 0;
            foreach(char c in id)
            {
                
                if(count % 2 == 0)
                {
                    if((int)Char.GetNumericValue(c) * 2 > 9)
                    {
                        char[] dubbel = ((int)Char.GetNumericValue(c) * 2).ToString().ToCharArray();
                        sum = sum + (int)Char.GetNumericValue(dubbel[0]) + (int)Char.GetNumericValue(dubbel[1]);
                    } else
                    {
                        sum = sum + (int)Char.GetNumericValue(c) * 2;
                    }
                    
                }else
                {
                    sum = sum + (int)Char.GetNumericValue(c);
                }
                count++;

            }

            char[] check = sum.ToString().ToCharArray();
            if (check[check.Length - 1] == '0') //Ifall sista talet är 0 är det jämt delbart med 10
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if person is a man or female depending on 7 number in idnumber.
        /// </summary>
        /// <returns></returns>
        private bool checkIfMan()
        {
            string clean = Regex.Replace(idNumber, "[^0-9 ]", "");
            char[] id = clean.ToCharArray();
            int controlNumber = id[8] - '0';
            if (controlNumber % 2 == 0)
            {
                return false;
            }
            else { return true; };
        }

        /// <summary>
        /// Display accordingly depending on result of checks.
        /// </summary>
        /// <param name="correctId">If id number is correct</param>
        /// <param name="isMan">If person is man or female</param>
        /// <returns></returns>
        private string displayResult(bool correctId, bool isMan)
        {
            string output;

            if (correctId)
            {
                if (isMan)
                {
                    output = "Ditt personnummer är korrekt "+ Environment.NewLine + "Du är en man "+ Environment.NewLine + "Du heter " + firstName + " " + lastName;
                } else
                {
                    output = "Ditt personnummer är korrekt " + Environment.NewLine + "Du är en kvinna " + Environment.NewLine + "Du heter " + firstName + " " + lastName;
                }
            } 
            else
            {
                output = "Du angav inte ett correct personnummer";
            }

            return output;
        }
    }
}
