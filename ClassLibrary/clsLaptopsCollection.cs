﻿using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsLaptopsCollection
    {
        //private data members
        List<clsLaptops> mLaptopsList = new List<clsLaptops>();
        clsLaptops mThisLaptop = new clsLaptops();

        public List<clsLaptops> LaptopsList 
        {
            get 
            { 
                //set the private data
                return mLaptopsList;
            }
            set 
            {
                //set the private data
                mLaptopsList = value;
            }
        }
        public int Count
        {
            get
            {
                //return the count of the list
                return LaptopsList.Count;
            }
            set
            {
                //i was told to not worry about this -\_o_/-
            }
        }
        public clsLaptops ThisLaptop 
        {
            get 
            {
                //return the private data
                return mThisLaptop;
            }
            set 
            {
                //set the private data
                mThisLaptop = value;
            }
        }

        //constructor for the class
        public clsLaptopsCollection() 
        { 
            //object for the data connect
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblLaptops_SelectAll");
            //populate the array
            PopulateArray(DB);
        }

        public int Add()
        {
            //adds a record to the database based on the values of mThisAddress
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@LaptopModel", mThisLaptop.LaptopModel);
            DB.AddParameter("@LaptopManufacturer", mThisLaptop.LaptopManufacturer);
            DB.AddParameter("@LaptopQuantity", mThisLaptop.LaptopQuantity);
            DB.AddParameter("@LaptopPrice", mThisLaptop.LaptopPrice);
            DB.AddParameter("@LaptopReorder", mThisLaptop.LaptopReorder);
            DB.AddParameter("@LaptopReorderDate", mThisLaptop.LaptopReorderDate);

            //execute the query returning the primary key value
            return DB.Execute("sproc_tblLaptops_Insert");
        }

        public void Update()
        {
            //update an existing record based on values of thisAddress
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the new sproc
            DB.AddParameter("@LaptopId", mThisLaptop.LaptopID);
            DB.AddParameter("@LaptopModel", mThisLaptop.LaptopModel);
            DB.AddParameter("@LaptopManufacturer", mThisLaptop.LaptopManufacturer);
            DB.AddParameter("@LaptopQuantity", mThisLaptop.LaptopQuantity);
            DB.AddParameter("@LaptopPrice", mThisLaptop.LaptopPrice);
            DB.AddParameter("@LaptopReorder", mThisLaptop.LaptopReorder);
            DB.AddParameter("@LaptopReorderDate", mThisLaptop.LaptopReorderDate);
            //execute the sproc
            DB.Execute("sproc_tblLaptops_Update");
        }

        public void Delete()
        {
            //deletes the record pointed to by ThisLaptop
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@LaptopId", mThisLaptop.LaptopID);
            //execute the sproc
            DB.Execute("sproc_tblLaptops_Delete");
        }

        public void ReportByManufacturer(string LaptopManufacturer)
        {
            //filters the records based on a full or partial manufacturer
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //send the manufacturer paramater to the sproc
            DB.AddParameter("@LaptopManufacturer", LaptopManufacturer);
            //execute the sproc
            DB.Execute("sproc_tblLaptops_FilterByManufacturer");
            //populate the array
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array based on the data in the table DB
            //var for index
            Int32 Index = 0;
            //variable for the record count
            Int32 RecordCount;
            //get the count of records
            RecordCount = DB.Count;
            //clear the private array list
            mLaptopsList = new List<clsLaptops>();
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsLaptops aLaptop = new clsLaptops();
                //read in the fields
                aLaptop.LaptopID = Convert.ToInt32(DB.DataTable.Rows[Index]["LaptopID"]);
                aLaptop.LaptopModel = Convert.ToString(DB.DataTable.Rows[Index]["LaptopModel"]);
                aLaptop.LaptopManufacturer = Convert.ToString(DB.DataTable.Rows[Index]["LaptopManufacturer"]);
                aLaptop.LaptopQuantity = Convert.ToInt32(DB.DataTable.Rows[Index]["LaptopQuantity"]);
                aLaptop.LaptopPrice = Convert.ToDouble(DB.DataTable.Rows[Index]["LaptopPrice"]);
                aLaptop.LaptopReorder = Convert.ToBoolean(DB.DataTable.Rows[Index]["LaptopReorder"]);
                aLaptop.LaptopReorderDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["LaptopReorderDate"]);
                //add the record to the private data member
                mLaptopsList.Add(aLaptop);
                //point at the next record
                Index++;
            }
        }
    }
}