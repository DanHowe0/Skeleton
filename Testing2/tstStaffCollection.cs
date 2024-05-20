﻿using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing2
{
    [TestClass]
    public class tstStaffCollection
    {
        public List<clsStaff> StaffList { get; private set; }

        [TestMethod]
        public void InstanceOk()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            Assert.IsNotNull(AllStaff);

        }
        [TestMethod]
        public void ThisStaffPropertyOk()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestStaff = new clsStaff();
            TestStaff.Active = true;
            TestStaff.StaffId = 1;
            TestStaff.StaffName = "Divyansh";
            TestStaff.StaffPhoneNumber = "07867029044";
            TestStaff.StaffEmail = "divyanshsingh1800@gmail.com";
            TestStaff.DateAdded = DateTime.Now;
            TestStaff.StaffAddress = "Ben Russell";
            AllStaff.ThisStaff = TestStaff;
            Assert.AreEqual(AllStaff.ThisStaff, TestStaff);

        }
        [TestMethod]
        public void SatffListOk() {
            clsStaffCollection AllStaff = new clsStaffCollection();
            List<clsStaff>TestList = new List<clsStaff>();
            clsStaff TestItem = new clsStaff();
            TestItem.DateAdded = DateTime.Now;
            TestItem.StaffAddress = "Ben Russell";
            TestItem.StaffName = "Abdullah";
            TestItem.StaffPhoneNumber = "07867029043";
            TestItem.StaffEmail = "abdullah@gmail.com";
            TestItem.StaffId = 1;
            TestItem.Active = true;
            TestList.Add(TestItem); 
            AllStaff.StaffList= TestList;
            Assert.AreEqual(AllStaff.StaffList, TestList);
        }
        [TestMethod]
        public void ListAndCountOk()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            List<clsStaff> TestList = new List<clsStaff>();
            clsStaff TestItem = new clsStaff();
            TestItem.DateAdded = DateTime.Now;
            TestItem.StaffAddress = "Ben Russell";
            TestItem.StaffName = "Abdullah";
            TestItem.StaffPhoneNumber = "07867029043";
            TestItem.StaffEmail = "abdullah@gmail.com";
            TestItem.StaffId = 1;
            TestItem.Active = true;
            TestList.Add(TestItem);
            AllStaff.StaffList = TestList;
            Assert.AreEqual(AllStaff.Count, TestList.Count);
        }
        [TestMethod]
        public void AddMethodOk()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            TestItem.DateAdded = DateTime.Now;
            TestItem.StaffAddress = "Ben Russell";
            TestItem.StaffName = "Abdullah";
            TestItem.StaffPhoneNumber = "07867029043";
            TestItem.StaffEmail = "abdullah@gmail.com";
            TestItem.StaffId = 1;
            TestItem.Active = true;
            AllStaff.ThisStaff = TestItem;//TestItem has been assigned to ThisStaff
            //mThisStaff is being assigned all the properties of clsStaff
            PrimaryKey = AllStaff.Add();//return an int value (Primary Key value) after inserting the above declared properties in the database 
            TestItem.StaffId = PrimaryKey;//StaffId property in clsStaff has been assigned the value stored in the PrimaryKey var i.e. returned by execute method in add method 


            AllStaff.ThisStaff.Find(PrimaryKey);
            Assert.AreEqual(AllStaff.ThisStaff, TestItem);


        }
      
   
    }
}
