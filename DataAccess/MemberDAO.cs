using BusinessObject;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class MemberDAO
    {

        private static MemberDAO instance;
        private static readonly object instanceLock = new object();
        private AssignmentPRN211DBContext context = new AssignmentPRN211DBContext();

        //Use singleton design pattern
        public MemberDAO()
        {

        }

        public bool CreateMember(Member newMember)
        {
                try
                {
                    context.Members.Add(newMember);
                    context.SaveChanges();
                    return true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return false;
                }
                catch (DbUpdateException ex)
                {
                    return false;
                }
        }

        public bool DeleteMember(int id)
        {
                try
                {
                    Member deleteMember = GetMemberById(id);
                    if (deleteMember != null)
                    {
                        context.Members.Remove(deleteMember);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return false;
                }
                catch (DbUpdateException ex)
                {
                    return false;
                }
        }

        public bool UpdateMember(int id, Member updatedMemberInfo)
        {
                try
                {
                    Member updateMember = GetMemberById(id);
                    if (updateMember != null)
                    {
                        context.Members.Update(updatedMemberInfo);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return false;
                }
                catch (DbUpdateException ex)
                {
                    return false;
                }
        }

        public bool ChangePassword(int id, string oldPassword, string newPassword)
        {
                try
                {
                    Member updateMember = GetMemberById(id);
                    if (updateMember != null && updateMember.Password.Equals(oldPassword))
                    {
                        updateMember.Password = newPassword;
                        context.Members.Update(updateMember);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return false;
                }
                catch (DbUpdateException ex)
                {
                    return false;
                }
        }

        public Member GetMemberById(int id)
        {
                return context.Members.SingleOrDefault<Member>((m) => m.MemberId == id);
        }

        public List<Member> GetAllMembers()
        {
                return context.Members.ToList<Member>();
        }

        public Member CheckLogin(string email, string password) {
            
                //get default account
                using StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + @"\appsettings.json");
                string json = streamReader.ReadToEnd();
                Admin admin = JsonConvert.DeserializeObject<Admin>(json);

                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    return admin;
                }

                return context.Members.SingleOrDefault<Member>(m => m.Email.Equals(email) && m.Password.Equals(password));

        }
    }
}
