using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class AddressBook
    {
        //line below includes constructor
        public Dictionary<string, Contact> ContactList { get; set; } = new Dictionary<string, Contact>();


        public void AddContact(Contact newContact)
        {

            try
            {
                ContactList.Add(newContact.Email, newContact);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error trying to add the same contact twice.");
            }

        }
        public Contact GetByEmail(string checkEmail)
        {
            // Contact result = new Contact();
            // foreach (KeyValuePair<string, Contact> contact in ContactList)
            // {
            //     if (contact.Key == checkEmail)
            //     {
            //         result = contact.Value;
            //     }


            // }
            // return result;
            return ContactList[checkEmail];


        }

    }
}

