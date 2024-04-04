﻿using System;

namespace LegacyApp
{
    public class UserService
    {
        private bool validateUserName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return false;
            return true;
        }
        private bool validateUserEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
                return false;
            return true;
        }

        private bool validateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
                return false;
            return true;
        }

        private void setCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
        }

        private bool validateUsersCredit(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
                return false;
            return true;
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!validateUserName(firstName, lastName))
                return false;

            if (!validateUserEmail(email))
                return false;

            if (!validateAge(dateOfBirth))
                return false;

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            setCreditLimit(user, client);

            if (!validateUsersCredit(user))
                return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
