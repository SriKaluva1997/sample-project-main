using System.Collections.Generic;
using BusinessEntities;
using Common;
using System;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type,int age, decimal? annualSalary, IEnumerable<string> tags)
        {
                user.SetEmail(email);
                user.SetName(name);
                user.SetType(type);
                user.SetAge(age);
            if (annualSalary == null)
            {
                user.SetMonthlySalary(annualSalary);
            }
            else
            {
                user.SetMonthlySalary(annualSalary.Value / 12);
            }
                user.SetTags(tags);
 

            }
           
        }
}