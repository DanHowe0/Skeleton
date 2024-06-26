﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if this is te first time th page is displayed
        if (IsPostBack == false)
        {
            //update the list box
            DisplayCustomers();
        }

        //create a new instance of clsCustomerUser
        clsCustomerUser AnUser = new clsCustomerUser();
        //get the data from the session object
        AnUser = (clsCustomerUser)Session["AnUser"];
        //display the user name
        Response.Write("Logged in as: " + AnUser.UserName);
    }

    void DisplayCustomers()
    {
        //create an instance of the customer collection
        clsCustomerCollection Customers = new clsCustomerCollection();
        //set the data source to list of addresses in the collection
        lstCustomerList.DataSource = Customers.CustomerList;
        //set the name of the PK
        lstCustomerList.DataValueField = "CustomerNo";
        //set the data field to display
        lstCustomerList.DataTextField = "CustFirstName";
        //bind the data to the list 
        lstCustomerList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate this is a new record
        Session["CustomerNo"] = -1;
        //redirect to the data entry page
        Response.Redirect("CustomerDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //varaible to store the PK value of the recordto be edited
        Int32 CustomerNo;
        //if the record has been selected fro the list
        if(lstCustomerList.SelectedIndex != -1)
        {
            //get the PK value of the record to edit
            CustomerNo = Convert.ToInt32(lstCustomerList.SelectedValue);
            //store the data in the session object
            Session["CustomerNo"] = CustomerNo;
            //redirect to the edit page
            Response.Redirect("CustomerDataEntry.aspx");
        }
        else    //if no record has been selected
        {
            lblError.Text = "Plese select a record from the list to edit";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //varaible to store the PK value of the recordto be edited
        Int32 CustomerNo;
        if (lstCustomerList.SelectedIndex != -1)
        {
            //get the PK value of the record to edit
            CustomerNo = Convert.ToInt32(lstCustomerList.SelectedValue);
            //store the data in the session object
            Session["CustomerNo"] = CustomerNo;
            //redirect to the edit page
            Response.Redirect("CustomerConfirmDelete.aspx");
        }
        else    //if no record has been selected
        {
            lblError.Text = "Plese select a record from the list to edit";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        //create an instance of the Customer object
        clsCustomerCollection AnCustomer = new clsCustomerCollection();
        //retrieve the value of the address from the presentation layer
        AnCustomer.ReportByAddress(txtEnterAddress.Text);
        //set the data source to the list of customers in the collection
        lstCustomerList.DataSource = AnCustomer.CustomerList;
        //set the name of the PK
        lstCustomerList.DataValueField = "CustomerNo";
        //set the name of the field to display
        lstCustomerList.DataTextField = "CustAddress";
        //bind the data to the list
        lstCustomerList.DataBind();
        
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //create an instance of the Customer object
        clsCustomerCollection AnCustomer = new clsCustomerCollection();
        //set an empty string
        AnCustomer.ReportByAddress("");
        //clear any exsiting filter
        txtEnterAddress.Text = "";
        //set the data source to the list of customers in the collection
        lstCustomerList.DataSource = AnCustomer.CustomerList;
        //set the name of the PK
        lstCustomerList.DataValueField = "CustomerNo";
        //set the name of the field to display
        lstCustomerList.DataTextField = "CustFirstName";
        //bind the data to the list
        lstCustomerList.DataBind();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }
}