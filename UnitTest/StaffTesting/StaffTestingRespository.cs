using Microsoft.AspNetCore.Mvc;
using Moq;
using StaffServices.Models;
using StaffServices.Respository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace StaffTesting
{
    public class StaffTestingRespository
    {
        private readonly Mock<StaffContex> _mockContext;

        Mock<IEmployeeRespository> employeeRespoMock;

        StaffContex staffContext;

        IEmployeeRespository employeeRespo;

        public static List<EmployeeModel> expectedList {  get; set; }

        public static List<EmployeeModel> debuggingList { get; set; }

        public static List<EmployeeModel> dbList { get; set; }

        public StaffTestingRespository() 
        {
            employeeRespoMock = new Mock<IEmployeeRespository>();
            
            staffContext = new StaffContex();
            
            employeeRespo = new EmployeeRespository(staffContext);

            expectedList = new List<EmployeeModel>();

            debuggingList = new List<EmployeeModel>();

            dbList = new List<EmployeeModel>();

            dbList.Add(new EmployeeModel()
            {
                EmployeeID = 1,
                FirstName = "John",
                LastName = "Lee",
                Email = "johnTheRockPillar@gmail.com",
                DateOfBirth = new DateTime(1990, 10, 03),
                GenderID = 1,
                DepartmentID = 5
            });

            dbList.Add(new EmployeeModel()
            {
                EmployeeID = 2,
                FirstName = "Porjasky",
                LastName = "Domskoi",
                Email = "PDMru564376@gmail.com",
                DateOfBirth = new DateTime(1995, 03, 04),
                GenderID = 1,
                DepartmentID = 6
            });

            dbList.Add(new EmployeeModel()
            {
                EmployeeID = 3,
                FirstName = "Wuan",
                LastName = "Si",
                Email = "handsomeQuan69420@gmail.com",
                DateOfBirth = new DateTime(2000, 05, 06),
                GenderID = 1,
                DepartmentID = 3
            });

            dbList.Add(new EmployeeModel()
            {
                EmployeeID = 4,
                FirstName = "May",
                LastName = "Silla",
                Email = "SillyMayXD@yahoo.com",
                DateOfBirth = new DateTime(2002, 10, 02),
                GenderID = 2,
                DepartmentID = 2
            });

            dbList.Add(new EmployeeModel()
            {
                EmployeeID = 4,
                FirstName = "Niko",
                LastName = "Oneshot",
                Email = "NikodefNotaCat@TWM.protocol.com",
                DateOfBirth = new DateTime(2014, 6, 30),
                GenderID = 4,
                DepartmentID = 4
            });

            // Test
            expectedList.Add(new EmployeeModel() 
            {
               EmployeeID = 1,
               FirstName = "John",
               LastName = "Lee",
               Email = "johnTheRockPillar@gmail.com",
               DateOfBirth = new DateTime(1990,10,03),
               GenderID = 1,
               DepartmentID = 5
            });

            expectedList.Add(new EmployeeModel() 
            { 
                EmployeeID = 2,
                FirstName = "Porjasky",
                LastName = "Domskoi",
                Email = "PDMru564376@gmail.com",
                DateOfBirth= new DateTime(1995,03,04),
                GenderID = 1,
                DepartmentID = 6
            });

            expectedList.Add(new EmployeeModel()
            {
                EmployeeID = 69,
                FirstName = "Absolutely",
                LastName = "Useless",
                Email = "failure@suckmail.io",
                DateOfBirth = new DateTime(1970, 10, 10),
                GenderID = 1,
                DepartmentID = 1
            });
            

            debuggingList.Add(new EmployeeModel()
            { 
                FirstName = "Bao",
                LastName = "Le Nguyen",
                Email = "baob2203541@student.ctu.edu.vn",
                DateOfBirth = new DateTime(2004,02,02),
                GenderID = 1,
                DepartmentID = 5
            });

            debuggingList.Add(new EmployeeModel()
            {   
                FirstName = "Nam",
                LastName = "Nhat Nam",
                Email = "namb2203568@student.ctu.edu.vn",
                DateOfBirth = new DateTime(2004, 05, 19),
                GenderID = 1,
                DepartmentID = 3
            });

        }
        [Fact]
        public async Task DumpEmployeeData() 
        {
            var result = await employeeRespo.GetEmployee();

            Assert.NotNull(result);
            Assert.Equal(dbList.Count, result.Count());
        }

        [Fact]
        public async void GetEmployee() 
        { 
            var staff = from e in expectedList where e.EmployeeID == 1 select e;

            var expected = (staff == null) ? null : staff.FirstOrDefault();

            employeeRespoMock.Setup(m => m.GetEmployee(1)).ReturnsAsync(expected);

            var res = await employeeRespo.GetEmployee(1);
            
            
            Assert.Equal(expected.EmployeeID, res.EmployeeID);
        }

        [Fact]
        public async void AddEmployee()
        {
            foreach (var e in debuggingList)
            {
                var addE = await employeeRespo.AddEmployee(e);

                Assert.NotNull(addE);
                Assert.True(addE.EmployeeID > 0 || addE.EmployeeID != null, "Expected non null or > 0 ID");
                Assert.Equal(addE.FirstName, e.FirstName);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)] // Fail expected
        [InlineData(99)] // Fail expected
        public async void GetEmployeeByID(int id) 
        {
            // Find correct expected item
            var staff = from e in expectedList where e.EmployeeID == id select e;
           
            var expected = staff.FirstOrDefault();

            // Init mock
            employeeRespoMock.Setup(m => m.GetEmployee(id)).ReturnsAsync(expected);

            var result = await employeeRespo.GetEmployee(id);

            if (expected == null || result == null)
            {
                Assert.True(result == null || expected == null, "The values were expected to be null.");
            }
            else 
            { 
                Assert.True(expected.EmployeeID == result.EmployeeID, $"Where {expected.EmployeeID} =? {result.EmployeeID}");
            }
        
        }

        [Fact]
        public async void DeleteDebugEmployee()
        {
            foreach (var e in debuggingList) {
                var staff = await employeeRespo.GetEmployee(e.Email);
                int id = (int)staff.EmployeeID;
                
                employeeRespoMock.Setup(m => m.DeleteEmployee(id)).ReturnsAsync(staff);

                var res = await employeeRespo.DeleteEmployee(id);

                if (res == null || staff == null)
                {
                    Assert.True(res == null || staff == null, "The values were expected to be null.");
                }
                else 
                {
                    Assert.True(staff.EmployeeID == res.EmployeeID, $"Where {staff.EmployeeID} =? {res.EmployeeID}");
                }
            }

        }


        [Theory]
        [InlineData(69)]
        public async void DeleteEmployeeNonExist(int id) 
        {
            var staff = from e in expectedList where e.EmployeeID == id select e;

            var expected = staff.FirstOrDefault();

            employeeRespoMock.Setup(m => m.DeleteEmployee(id)).ReturnsAsync(expected);

            var result = await employeeRespo.DeleteEmployee(id);

            if (expected == null || result == null)
            {
                Assert.True(expected == null || result == null);
            }
            else
            {
                Assert.True(result.EmployeeID == expected.EmployeeID);
            }

        }

        [Fact]

    }
}
