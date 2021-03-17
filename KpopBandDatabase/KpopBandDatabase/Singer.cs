/*
 * Singer
 * Hank Yang 
 * January 6, 2020
 * ICS4U_Period_2
 * This class takes care of the contruction of a singer, as well as various variable infromation attached to each singer
 * Consists of the get & set of each variable attached to a singer which allows other class to access and edit these data
 * Includes numerous singer fucntions that are yet to be used
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace KpopBandDatabase
{
    class Singer
    {
        private string name, gender, hobbies;
        private int age, height, weight;

        // Delcare a bitmap variable which is the profile picture of the band
        private Bitmap singerPfp = null;
        // Create string variable to store the band ID
        private string singerId = "";

        // Constructor that takes in a variable infor that a singer consist of
        // Saves the information passed in, into the individual singer
        public Singer(string name)
        {
            this.name = name;
        }

        // Constructor that takes in all variable info that a singer consists of
        // Saves all the information passed in, into the individual singer
        public Singer(string name, string gender, int age, int height, int weight, string hobbies) 
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.hobbies = hobbies;
        }
        public string Name // Allow the other class to have acces and edit name information
        {
            get
            {
                string formattedName = name;
                formattedName = formattedName.ToLower();
                formattedName = formattedName.Substring(0, 1).ToUpper() + formattedName.Substring(1);
                name = formattedName; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
                return name;
            }
            set
            {
                string formattedName = value;
                formattedName = formattedName.ToLower();
                formattedName = formattedName.Substring(0, 1).ToUpper() + formattedName.Substring(1);
                name = formattedName; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
            }
        }
        public string Gender // Allow other class to have access and edit gender information
        {
            get
            {
                string formatteGender = gender;
                formatteGender = formatteGender.ToLower();
                formatteGender = formatteGender.Substring(0, 1).ToUpper() + formatteGender.Substring(1);
                gender = formatteGender; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
                return gender;
            }
            set
            {
                string formatteGender = value;
                formatteGender = formatteGender.ToLower();
                formatteGender = formatteGender.Substring(0, 1).ToUpper() + formatteGender.Substring(1);
                gender = formatteGender; // format the name informatio properly with the first letter captialized & the rest of the letters lowercased
            }
        }
        public int Age // Allow other class to have access and edit age information
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public int Height // Allow other class to have access and edit height information
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int Weight // Allow other class to have access and edit weight information
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public string Hobbies // Allow other class to have access and edit hobbies information
        {
            get
            {
                return hobbies;
            }
            set
            {
                hobbies = value;
            }
        }

        public Bitmap SingerPfp // Allow the other class to have access and edit profile picture information
        {
            get
            {
                return singerPfp;
            }
            set
            {
                singerPfp = value;
            }
        }
        public string SingerId // Allow the other class to have access and edit the band id
        {
            get
            {
                return singerId;
            }
            set
            {
                singerId = value;
            }
        }
    }
}
