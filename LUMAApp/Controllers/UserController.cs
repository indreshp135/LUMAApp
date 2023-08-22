﻿using LUMAApp.Entities;
using LUMAApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LUMAApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private LmaContext _context;
        public UserController(LmaContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetContents([FromQuery] UserTablesRequest userTablesRequest)
        {
            var employeeId = userTablesRequest.EmployeeId;

            var employeeCard = await _context.EmployeeCardDetails.Where(e => e.EmpId == employeeId).ToListAsync();
            var employeeIssue = await _context.EmployeeIssueDetails.Where(e => e.EmpId == employeeId).ToListAsync();


            return Ok(new
            {
                employeeCard,
                employeeIssue
            });

        }

        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }

        [HttpPost]
        public async Task<ActionResult> SetContents([FromBody] UserFormRequest userFormRequest)
        {
            var cardDetail = new EmployeeCardDetail
            {
                EmpId = userFormRequest.EmployeeId,
                LoanId = userFormRequest.LoanId,
                CardIssueDate = DateTime.Now
            };

            cardDetail.Emp = await _context.EmpMasters.FindAsync(userFormRequest.EmployeeId);
            cardDetail.Loan = await _context.LoanCardMasters.FindAsync(userFormRequest.LoanId);

            Console.WriteLine(cardDetail.Emp.EmpId);

            var issueDetail = new EmployeeIssueDetail
            {
                IssueId = GenerateRandomString(6),
                EmpId = userFormRequest.EmployeeId,
                ItemId = userFormRequest.ItemId,
                IssueDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };

            issueDetail.Emp = await _context.EmpMasters.FindAsync(userFormRequest.EmployeeId);
            issueDetail.Item = await _context.ItemMasters.FindAsync(userFormRequest.ItemId);

            // Add the new EmployeeCardDetail to the context and save changes
            _context.EmployeeCardDetails.Add(cardDetail);
            _context.EmployeeIssueDetails.Add(issueDetail);
            _context.SaveChanges();

            return Ok("Employee card created and linked successfully." + cardDetail.Emp.EmpId);
        }                                                       
    }
}
